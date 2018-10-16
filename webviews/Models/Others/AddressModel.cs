using System.ComponentModel.DataAnnotations;

namespace webviews.Models.Others
{
    public abstract class AddressModel
    {
        [Display(Name="Endereço")]
        public string Address {get;set;}
        [Display(Name="Número")]
        public string Number {get;set;}
        [Display(Name="Complemento")]
        public string Complement {get;set;}
        [Display(Name="Bairro")]
        public string Block {get;set;}
        [Display(Name="Cidade")]
        public string City {get;set;}
        [Display(Name="Estado")]
        public string State {get;set;}
        [Display(Name="País")]
        public string Country {get;set;}
        [Display(Name="CEP")]
        public string ZipCode {get;set;}
         
    }
}