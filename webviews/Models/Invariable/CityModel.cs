using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models.Invariable
{
    [Table("CITIS0")]
    public class CityModel : BaseModel, IBaseModel<CityModel>
    {
        public CityModel()
        {
            UserIdProper = -1;
            UserIdUpdate = 1;
        }

        [Required]
        [Display(Name="País")]
        public string Country {get;set;}
        [Required]
        [Display(Name="País (ID)")]
        public int CountryId {get; set;}
        [Required]
        [Display(Name="País")]
        public string CountryShort {get;set;}

        [Required]
        [Display(Name="Estado")]
        public string State {get;set;}
        [Required]
        [Display(Name="Estado (ID)")]
        public string StateId {get;set;}
        [Required]
        [Display(Name="Estado")]
        public string StateShort {get;set;}
        [Required]
        [Display(Name="Cidade")]
        public string City {get;set;}
        [Required]
        [Display(Name="Cidade (ID)")]
        public string CityId {get;set;}
        
        [Display(Name="Cidade")]
        public string CityShort {get;set;}

        public void Update(CityModel model)
        {
            Country = model.Country;
            CountryId = model.CountryId;
            State = model.State;
            StateId = model.StateId;
            City = model.City;
            CityId = model.CityId;

            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<CityModel>();
            e.HasIndex(t => t.Code).IsUnique();
            base.OnModelCreating<CityModel>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new CityModel()).OnModelCreating(modelBuilder);
        }
    }
}