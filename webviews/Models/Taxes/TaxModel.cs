using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Taxes
{
    [Table("TAXES0")]
    public class TaxModel : BaseModel, IBaseModel<TaxModel>
    {
        [Required]
        [Display(Name = "Imposto")]
        public string TaxName {get => Name; set => Name = value;}
        
        [Display(Name = "Taxa")]
        public double Fee {get;set;}
        [Required]
        [Display(Name = "Base de Calculo")]
        public double Base {get;set;}
        [Display(Name = "Desconto")]
        public double Discont {get;set;}
        [Required]
        [Display(Name = "Acrescentar valor da linha?")]
        public bool AddTotalLine {get;set;}

        public void Update(TaxModel model)
        {
            base.Update(model);
            Fee = model.Fee;
            Base = model.Base;
            Discont = model.Discont;
            AddTotalLine = model.AddTotalLine;
        }

        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }
    }
}