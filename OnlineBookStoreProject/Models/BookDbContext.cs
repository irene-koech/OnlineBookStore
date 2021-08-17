using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStoreProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace OnlineBookStoreProject.Models
{
   // public class BookDbContext { }
    public class BookDbContext : IdentityDbContext<IdentityUser>
    {
         public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
          {

          }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Comedy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Fiction" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Romance" });

            //seed pies

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                Title = "How Long 'til Black Future Month?",
                Author = "N. K. Jemisin",
                Publisher = "Orbit",
                Price = 18.30M,
                Pages = 416,
                ShortDescription = "In these stories, Jemisin sharply examines modern society, infusing magic into the mundane, and drawing deft parallels in the fantasy realms of her imagination",
                LongDescription = "Dragons and hateful spirits haunt the flooded city of New Orleans in the aftermath of Hurricane Katrina. In a parallel universe, a utopian society watches our world, trying to learn from our mistakes. A black mother in the Jim Crow south must figure out how to save her daughter from a fey offering impossible promises. And in the Hugo award-nominated short story “The City Born Great,” a young street kid fights to give birth to an old metropolis’s soul.",
                CategoryId = 3,
                ImageUrl = "https://i.postimg.cc/TwB8jDm1/blackfuture.jpg",
                Onsale = false,
                ImageThumbnailUrl = "https://i.postimg.cc/rs2nFCx1/resize-1624460602616016643blackfuture.jpg"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                Title = "The Secret",
                Author = "Rhonda Byrne",
                Publisher = "Atria",
                Price = 14.95M,
                Pages = 198,
                ShortDescription = "The worldwide bestselling phenomenon that has helped millions tap the power of the law that governs all our lives to create—intentionally and effortlessly—a joyful life.",
                LongDescription = "In this book, you’ll learn how to use The Secret in every aspect of your life—money, health, relationships, happiness, and in every interaction you have in the world. You’ll begin to understand the hidden, untapped power that’s within you, and this revelation can bring joy to every aspect of your life",
                CategoryId = 3,
                ImageUrl = "https://i.postimg.cc/TwB8jDm1/blackfuture.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/rs2nFCx1/resize-1624460602616016643blackfuture.jpg"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                Title = "To kill a mockingbird",
                Author = "Harper Lee ",
                Publisher = "HarperCollins Espanol",
                Price = 15.95M,
                Pages = 336,
                ShortDescription = "Harper Lee's Pulitzer Prize-winning masterwork of honor and injustice in the deep South—and the heroism of one man in the face of blind and violent hatred",
                LongDescription = "One of the most cherished stories of all time, To Kill a Mockingbird has been translated into more than forty languages, sold more than forty million copies worldwide, served as the basis for an enormously popular motion picture, and was voted one of the best novels of the twentieth century by librarians across the country. A gripping, heart-wrenching, and wholly remarkable tale of coming-of-age in a South poisoned by virulent prejudice, it views a world of great beauty and savage inequities through the eyes of a young girl, as her father—a crusading local lawyer—risks everything to defend a black man unjustly accused of a terrible crime.",
                CategoryId = 1,
                ImageUrl = "https://i.postimg.cc/MTFVKWB1/Mocking-Bird.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/15H6fcD9/resize-1624455785560465313-Mocking-Bird.jpg"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                Title = "Everything is F*cked",
                Author = "Mark Manson",
                Publisher = "Harper",
                Price = 13.47M,
                Pages = 288,
                ShortDescription = "From the author of the international mega-bestseller The Subtle Art of Not Giving A F*ck comes a counterintuitive guide to the problems oThis Hugo Award-winning graphic novel chronicles the fall from grace of a group of super-heroes plagued by all-too-human failings",
                LongDescription = "We live in an interesting time. Materially, everything is the best it’s ever been—we are freer, healthier and wealthier than any people in human history. Yet, somehow everything seems to be irreparably and horribly f*cked—the planet is warming, governments are failing, economies are collapsing, and everyone is perpetually offended on Twitter. At this moment in history, when we have access to technology, education and communication our ancestors couldn’t even dream of, so many of us come back to an overriding feeling of hopelessness.",
                CategoryId = 1,
                ImageUrl = "https://i.postimg.cc/BQx4Jm9v/7195f4cd-AVL.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/ZYQCW7MF/resize-162445596718953540257195f4cd-AVL.jpg"

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 5,
                Title = "Bird Box",
                Author = "Josh Malerman",
                Publisher = "Ecco",
                Price = 40.00M,
                Pages = 272,
                ShortDescription = "Something is out there, something terrifying that must not be seen. One glimpse of it, and a person is driven to deadly violence. No one knows what it is or where it came from.",
                LongDescription = "Written with the narrative tension of The Road and the exquisite terror of classic Stephen King, Bird Box is a propulsive, edge-of-your-seat horror thriller, set in an apocalyptic near-future world—a masterpiece of suspense from the brilliantly imaginative Josh Malerman.",
                CategoryId = 2,
                ImageUrl = "https://i.postimg.cc/B6QRfC5X/birdbox.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/XJHmjyxx/resize-16244603561083887654birdbox.jpg"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 6,
                Title = "Watchmen",
                Author = "Alan Moore",
                Publisher = "DC Comics",
                Price = 9.08M,
                Pages = 416,
                ShortDescription = "This Hugo Award-winning graphic novel chronicles the fall from grace of a group of super-heroes plagued by all-too-human failings. Along the way, the concept of the super-hero is dissected as the heroes are stalked by an unknown assassin",
                LongDescription = "One of the most influential graphic novels of all time and a perennial best-seller, Watchmen has been studied on college campuses across the nation and is considered a gateway title, leading readers to other graphic novels such as V for Vendetta, Batman: The Dark Knight Returns and The Sandman series.",
                CategoryId = 2,
                ImageUrl = "https://i.postimg.cc/HjGYBNqq/watchmen.jpg",
                Onsale = true,
                ImageThumbnailUrl =
                    "https://i.postimg.cc/yYFg2hLm/resize-16244576981109173577watchmen.jpg"

            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 7,
                Title = "The Guardians",
                Author = "John Grisham",
                Publisher = "Doubleday",
                Price = 15.99M,
                Pages = 384,
                ShortDescription = "“A suspenseful thriller mixed with powerful themes.”—Associated Press",
                LongDescription = "Guardian accepts only a few innocence cases at a time.  Cullen Post travels the country fighting wrongful convictions and taking on clients forgotten by the system. With Quincy Miller, though, he gets far more than he bargained for. Powerful, ruthless people murdered Keith Russo, and they do not want Quincy Miller exonerated.",
                CategoryId = 3,
                ImageUrl = "https://i.postimg.cc/fTtyhc52/guardance.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/wTmqr6Tn/resize-1624460902996092956guardance.jpg"

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 8,
                Title = "My Sister, the Serial Killer",
                Author = "Oyinkan Braithwaite",
                Publisher = "",
                Price = 9.70M,
                Pages = 228,
                ShortDescription = "A short, darkly funny, hand grenade of a novel about a Nigerian woman whose younger sister has a very inconvenient habit of killing her boyfriends",
                LongDescription = "Korede's practicality is the sisters' saving grace. She knows the best solutions for cleaning blood, the trunk of her car is big enough for a body, and she keeps Ayoola from posting pictures of her dinner to Instagram when she should be mourning her 'missing' boyfriend. Not that she gets any credit.",
                CategoryId = 1,
                ImageUrl = "https://i.postimg.cc/NG1Y8dJw/killer.jpg",
                Onsale = true,
                ImageThumbnailUrl = "https://i.postimg.cc/s2kd7W5X/resize-16244610312012456653killer.jpg"
            });


        }

    }
}
