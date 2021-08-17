using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStoreProject.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _bookDbContext;
        public CategoryRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IEnumerable<Category> GetAllCategories => _bookDbContext.Categories;

    }
}
