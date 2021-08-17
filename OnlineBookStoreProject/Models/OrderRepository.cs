using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookDbContext _bookDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(BookDbContext bookDbContext, ShoppingCart shoppingCart)
        {
            _bookDbContext = bookDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    BookId = shoppingCartItem.Book.BookId,
                    Price = shoppingCartItem.Book.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bookDbContext.Orders.Add(order);

            _bookDbContext.SaveChanges();
        }
    }
}
