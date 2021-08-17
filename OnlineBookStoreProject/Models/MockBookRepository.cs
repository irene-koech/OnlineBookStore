using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class MockBookRepository : IBookRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Book> GetAllBooks =>
            new List<Book>
            {
                new Book {BookId = 1,Title="Everything Is F*cked", Author="Mark Manson",Publisher="Harper", Price=15.95M,Pages=288, ShortDescription="From the author of the international mega-bestseller The Subtle Art of Not Giving A F*ck comes a counterintuitive guide to the problems of hope.", LongDescription="We live in an interesting time. Materially, everything is the best it’s ever been—we are freer, healthier and wealthier than any people in human history. Yet, somehow everything seems to be irreparably and horribly f*cked—the planet is warming, governments are failing, economies are collapsing, and everyone is perpetually offended on Twitter. At this moment in history, when we have access to technology, education and communication our ancestors couldn’t even dream of, so many of us come back to an overriding feeling of hopelessness.", Category = _categoryRepository.GetAllCategories.ToList()[1],ImageUrl="https://i.postimg.cc/BQx4Jm9v/7195f4cd-AVL.jpg", Onsale=true, ImageThumbnailUrl="https://i.postimg.cc/ZYQCW7MF/resize-162445596718953540257195f4cd-AVL.jpg"},
                new Book {BookId = 2,Title="Watchedmen", Author="Alan Moore", Publisher="DC Comics", Price=18.95M, Pages=416, ShortDescription="From the author of the international mega-bestseller The Subtle Art of Not Giving A F*ck comes a counterintuitive guide to the problems oThis Hugo Award-winning graphic novel chronicles the fall from grace of a group of super-heroes plagued by all-too-human failings", LongDescription="Along the way, the concept of the super-hero is dissected as the heroes are stalked by an unknown assassin.One of the most influential graphic novels of all time and a perennial bestseller, WATCHMEN has been studied on college campuses across the nation and is considered a gateway title, leading readers to other graphic novels such as V FOR VENDETTA, BATMAN: THE DARK KNIGHT RETURNS and THE SANDMAN series.", Category = _categoryRepository.GetAllCategories.ToList()[1],ImageUrl="https://i.postimg.cc/HjGYBNqq/watchmen.jpg", Onsale=true, ImageThumbnailUrl="https://i.postimg.cc/yYFg2hLm/resize-16244576981109173577watchmen.jpg"},
                new Book {BookId = 3,Title="To kill a mockingbird", Author="Harper Lee ", Publisher="HarperCollins Espanol", Price=15.95M, Pages=336, ShortDescription="Harper Lee's Pulitzer Prize-winning masterwork of honor and injustice in the deep South—and the heroism of one man in the face of blind and violent hatred", LongDescription="One of the most cherished stories of all time, To Kill a Mockingbird has been translated into more than forty languages, sold more than forty million copies worldwide, served as the basis for an enormously popular motion picture, and was voted one of the best novels of the twentieth century by librarians across the country. A gripping, heart-wrenching, and wholly remarkable tale of coming-of-age in a South poisoned by virulent prejudice, it views a world of great beauty and savage inequities through the eyes of a young girl, as her father—a crusading local lawyer—risks everything to defend a black man unjustly accused of a terrible crime.", Category = _categoryRepository.GetAllCategories.ToList()[0],ImageUrl="https://i.postimg.cc/MTFVKWB1/Mocking-Bird.jpg", Onsale=true,  ImageThumbnailUrl="https://i.postimg.cc/15H6fcD9/resize-1624455785560465313-Mocking-Bird.jpg"},
                new Book {BookId = 4, Title="The Secret", Author="Pumpkin Pie",Publisher="Simon & Schuster Audio", Price=12.95M, Pages=206,ShortDescription="Enjoy more joy, abundance, and blessings with this 365-day guide—with removable pages—building on The Secret’s powerful truths. Perfect for your work desk or your bedside table.", LongDescription="All around the world, The Secret is helping millions achieve the lives of their dreams. Now, with The Secret Daily Teachings, Rhonda Byrne takes readers through the next vital steps in living The Secret. Byrne illuminates facets of the law of attraction that lead to more joy, abundance, and blessings—every single day of the year. This beautifully designed book has removable pages so you can share your favorite teachings or take your most cherished inspirations with you as you go about the day.", Category = _categoryRepository.GetAllCategories.ToList()[2],ImageUrl="https://i.postimg.cc/2Syq3pzw/81-MAr-Waiw1-L.jpg", Onsale=true, ImageThumbnailUrl="https://i.postimg.cc/HW3sMSvP/resize-1624456054195784498781-MAr-Waiw1-L.jpg"}
            };

        public IEnumerable<Book> BooksOnSale { get; set; }

        public Book GetBookById(int bookId)
        {
            return GetAllBooks.FirstOrDefault(b => b.BookId == bookId);
        }

    }
}
