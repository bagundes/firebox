using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Administration
{
    [Table("SYNCM0")]
    public class SyncModel : BaseModel, IBaseModel<SyncModel>
    {
        [Required]
        [Display(Name="Tabela")]
        public string Table {get;set;}
        [Display(Name="Chave")]
        public string Key {get;set;}

        [Display(Name="Lidos")]
        public int Count  {get;set;}
        [Required]
        [Display(Name="Integrado")]
        public DateTime Updated {get;set;}

        public void Update(SyncModel model)
        {
            throw new NotImplementedException();
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var e = modelBuilder.Entity<SyncModel>();
            e.HasIndex(t => t.Table).IsUnique();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<SyncModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new SyncModel()).OnModelCreating(modelBuilder);
        }
    }
}