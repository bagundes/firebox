using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Invariable
{
    [Table("PRLIST0")]
    public class PriceListModel : BaseModel, IBaseModel<PriceListModel>
    {
        [Required]
        [Display(Name="Lista de Preço (ID)")]
        public int PriceList {get => (int)Code; set => Code = value;}
        [Required]
        [Display(Name="Lista de Preço")]
        public string ListName {get => Name; set => Name = value;}
        [Required]
        [Display(Name="Cód. Item")]
        public int InternItemCode {get;set;}
        [Required]
        [Display(Name="Código de barras")]
        public string Barcode {get;set;}
        [Required]
        [Display(Name="Preço")]
        public double Price {get;set;}

        public void Update(PriceListModel model)
        {
            PriceList = model.PriceList;
            ListName = model.ListName;
            InternItemCode = model.InternItemCode;
            Barcode = model.Barcode;
            Price = model.Price;
        
            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<PriceListModel>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<PriceListModel>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new PriceListModel()).OnModelCreating(modelBuilder);
        }

    }
}