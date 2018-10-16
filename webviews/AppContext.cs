using Microsoft.EntityFrameworkCore;

namespace webviews
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Models.Administration.ModuleModel.ModelCreating(modelBuilder);
            Models.Administration.PerfilModel.ModelCreating(modelBuilder);
            Models.Administration.UserModel.ModelCreating(modelBuilder);
            Models.Documents.SalesOrderModel.ModelCreating(modelBuilder);
            Models.Documents.SalesOrder_ItemModel.ModelCreating(modelBuilder);
            Models.Documents.SalesOrder_TaxModel.ModelCreating(modelBuilder);
            Models.Invariable.CityModel.ModelCreating(modelBuilder);
            Models.Partners.BusinessPartnerModel.ModelCreating(modelBuilder);
            Models.Invariable.AddressModel.ModelCreating(modelBuilder);
            Models.Administration.SyncModel.ModelCreating(modelBuilder);
            Models.Invariable.ItemsModel.ModelCreating(modelBuilder);
            Models.Invariable.PriceListModel.ModelCreating(modelBuilder);
            Models.Invariable.VendorModel.ModelCreating(modelBuilder);
            Models.Invariable.UfToPriceListModel.ModelCreating(modelBuilder);
        }
    }
}