using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories =>
     new List<Category>
     {
                new Category{CategoryId=1, CategoryName="Comedy", Description="To prove our point, here is a selection of some of the funniest titles ever written to make you cackle, snort, giggle or titter, whether you’re on a train, in a library, or just at home with your cat"},
                new Category{CategoryId=2, CategoryName="Fiction", Description="Though it can be seen as a broad genre that encompasses many others, literary fiction refers to the perceived artistic writing style of the author"},
                new Category{CategoryId=3, CategoryName="Poetry", Description="With poetry—a form of written art—authors choose a particular rhythm and style to evoke and portray various emotions and ideas"}
     };

    }
}
