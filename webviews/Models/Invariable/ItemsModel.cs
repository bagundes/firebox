using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Invariable
{
    [Table("ITEMS0")]
    public class ItemsModel : BaseModel, IBaseModel<ItemsModel>
    {
        public ItemsModel(){}
        
        [NotMapped]
        [Required]
        [Display(Name="Código Interno")]
        public int InternCode {get => (int) Code;set => Code = value;}
        [Required]
        [Display(Name="Nome")]
        public override string Name {get;set;}
        [Required]
        [Display(Name="Nome resumido")]
        public string SimpleName {get;set;}
        [Required]
        [Display(Name="Unidade")]
        public string Unit {get;set;}
        [Required]
        [Display(Name="Código de barras")]
        public string Barcode {get;set;}

        public void Update(ItemsModel model)
        {
            InternCode = model.InternCode;
            Name = model.Name;
            SimpleName = model.SimpleName;
            Unit = model.Unit;
            Barcode = model.Barcode;
        
            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<ItemsModel>();
            e.HasIndex(x => x.Code).IsUnique();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<ItemsModel>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new ItemsModel()).OnModelCreating(modelBuilder);
        }

    }
}