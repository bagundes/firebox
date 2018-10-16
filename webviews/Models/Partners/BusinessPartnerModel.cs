using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using webviews.Models.Invariable;

namespace webviews.Models.Partners
{
    [Table("BPART0")]
     public class BusinessPartnerModel : BaseModel, IBaseModel<BusinessPartnerModel>
     {

         public BusinessPartnerModel(Enums.BPartnerType type = Enums.BPartnerType.None)
         {
             AddressShip = new AddressModel(Enums.AddressType.BPartnerShip);
             AddressBill = new AddressModel(Enums.AddressType.BPartnerShip);
             Salesman = -1;
             ZonaFranca = false;
             Type = type;
             PriceList = -1;
         }

        [Required]
        [Display(Name="Código Interno")]
        public  int InterCode {get => (int) Code;set => Code = value;}
        [Required]
        [Display(Name="Código SAP")]
        public string CardCode { get => Name; set => Name = value;}

        [Required]
        [Display(Name="Tipo Parceiro")]
        public Enums.BPartnerType Type { get; protected set;}

        [Required]
        [Display(Name="Nome Social")]
        public string CompanyName {get;set;}
        [Display(Name="Nome Fantasia")]
        public string TradingName {get;set;}
        [Required]
        [Display(Name="CNPJ")]
        public string TaxId1 {get;set;}
        [Display(Name="IE")]
        public string TaxId2 {get;set;}
        [Display(Name="IM")]
        public string TaxId3 {get;set;}

        [Display(Name="Endereço Entrega (ID)")]
        public int AddressShipId {get;set;}
        [NotMapped]
        [Display(Name="Endereço Entrega")]
        public AddressModel AddressShip {get;set;}

        [Display(Name="Endereço Cobrança (ID)")]
        public int AddressBillId {get;set;}
        [NotMapped]
        [Display(Name="Endereço de Cobrança")]
        public AddressModel AddressBill {get;set;}
                
        [Display(Name="Zona Franca")]
        public bool ZonaFranca {get;set;}
        
        [Display(Name="Lista de Preço")]
        public int PriceList {get;set;}
        
        [Display(Name="Transportadora")]
        public int TransporterId {get;set;}
        
        [Display(Name="Vendedor")]
        public int Salesman {get;set;}
        
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-mail")]
        public string Email {get;set;}
        public void Update(BusinessPartnerModel model)
        {
            InterCode = model.InterCode;
            CardCode = model.CardCode;
            Type = model.Type;
            CompanyName = model.CompanyName;
            TradingName = model.TradingName;
            TaxId1 = model.TaxId1;
            TaxId2 = model.TaxId2;
            TaxId3 = model.TaxId3;
            AddressShip = model.AddressShip;
            AddressBill = model.AddressBill;
            ZonaFranca = model.ZonaFranca;
            PriceList = model.PriceList;
            TransporterId = model.TransporterId;
            Salesman = model.Salesman;
            Email = model.Email;
        
            base.Update(model);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<BusinessPartnerModel>();
            e.HasIndex(x => x.Code).IsUnique();
            e.HasIndex(x => x.CardCode).IsUnique();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<BusinessPartnerModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new BusinessPartnerModel()).OnModelCreating(modelBuilder);
        }
    }
}