

using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly BethanysPieShopDbContext _dbContext;

        public PieRepository(BethanysPieShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Pie> AllPies => this._dbContext.Pies.Include(pie => pie.Category);

        public IEnumerable<Pie> PiesOfTheWeek => this._dbContext.Pies.Include(pie => pie.Category).Where(pie => pie.IsPieOfTheWeek == true);


        public Pie? GetPieById(int pieId) => this._dbContext.Pies.FirstOrDefault(pie => pie.PieId == pieId);

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            var result = this._dbContext.Pies.Where(pie => pie.Name.Contains(searchQuery));
            return result;
        }
    }
}
