using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Administration
{
    [Table("LICNS0")]
    public class LicenseModel : BaseModel, IBaseModel<PerfilModel>
    {
        [Required]
        [Display(Name="Chave licença")]
        public string LicenseKey {get; set;}
        [Required]
        [Display(Name="Quantidade")]
        public int Qtty {get; protected set;}
        [Required]
        [Display(Name="Vencimento")]
        public DateTime DueDate {get; protected set;}
        [Required]
        [Display(Name="Empresa")]
        public int CompanyId {get; protected set;}

        public void Update(PerfilModel model)
        {
            throw new System.NotImplementedException();
        }
        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<LicenseModel>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<LicenseModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new LicenseModel()).OnModelCreating(modelBuilder);
        }
    }
}