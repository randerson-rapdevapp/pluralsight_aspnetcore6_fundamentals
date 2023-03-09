using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _dbContext;

        public CategoryRepository(BethanysPieShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Category> AllCategories => this._dbContext.Categories;
    }
}
