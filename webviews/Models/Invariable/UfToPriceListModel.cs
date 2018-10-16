using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Invariable
{
    [Table("UFTPL0")]
    public class UfToPriceListModel : BaseModel, IBaseModel<UfToPriceListModel>
    {
        [Required]
        [Display(Name="Lista de Preço (ID)")]
        public int PriceListCode {get => (int) Code; set => Code = value;}
        
        [NotMapped]
        [Required]
        [Display(Name="Lista de Preço")]
        public PriceListModel PriceList {get;set;} = new PriceListModel();

        [Display(Name="UF")]
        public string UFs {get => Name; set => Name = value;}

        public void Update(UfToPriceListModel model)
        {
            PriceListCode = model.PriceListCode;
            PriceList = model.PriceList;
            UFs = model.UFs;
        
            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<UfToPriceListModel>();
            e.HasIndex(x => x.Code).IsUnique();
            base.OnModelCreating<UfToPriceListModel>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new UfToPriceListModel()).OnModelCreating(modelBuilder);
        }
    }
}