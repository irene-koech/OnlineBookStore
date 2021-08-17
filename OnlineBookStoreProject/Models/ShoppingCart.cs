using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class ShoppingCart
    {
        private readonly BookDbContext _bookDbContext;

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<BookDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book, int amount)
        {
            var shoppingCartItem =
                    _bookDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };

                _bookDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _bookDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem =
                    _bookDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _bookDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _bookDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _bookDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Book)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _bookDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _bookDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _bookDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _bookDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Book.Price * c.Amount).Sum();
            return total;
        }
    }
}
