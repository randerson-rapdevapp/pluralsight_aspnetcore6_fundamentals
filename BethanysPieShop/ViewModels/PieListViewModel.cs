namespace BethanysPieShop.ViewModels
{
    public class PieListViewModel
    {
        public PieListViewModel(string currentCategory, IEnumerable<Models.Pie> pies)
        {
            this.CurrentCategory = currentCategory;
            this.Pies = pies;
        }

        public string? CurrentCategory { get; }
        public IEnumerable<Models.Pie> Pies { get; }
    }
}
