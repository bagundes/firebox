using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Invariable
{
    [Table("VENDR0")]
    public class VendorModel : BaseModel, IBaseModel<VendorModel>
    {
        [Required]
        [Display(Name="Código Vendedor")]
        public int VendorCode {get => (int) Code;set => Code = value;}
        [Required]
        [Display(Name="Vendedor")]
        public string VendorName {get => Name; set => Name = value;}


        public void Update(VendorModel model)
        {
            VendorCode = model.VendorCode;
            VendorName = model.VendorName;
        
            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<VendorModel>();
            e.HasIndex(t => t.Code).IsUnique();
            base.OnModelCreating<VendorModel>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new VendorModel()).OnModelCreating(modelBuilder);
        }
    }
}