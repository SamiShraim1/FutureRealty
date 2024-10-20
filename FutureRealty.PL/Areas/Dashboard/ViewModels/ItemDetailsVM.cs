namespace FutureRealty.PL.Areas.Dashboard.ViewModels
{
    public class ItemDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
