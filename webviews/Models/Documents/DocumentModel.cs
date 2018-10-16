using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Documents
{
    public abstract class DocumentModel : BaseModel, IBaseModel<DocumentModel>
    {

        public DocumentModel(Enums.DocumentType DocType)
        {
            this.DocType = DocType;
            this.ValidUntil = DateTime.Now.AddMonths(1);
        }

        [Required]
        [Display(Name = "Número")]
        public virtual int DocNumber { get; set; }
        [Required]
        [Display(Name = "Série")]
        public int Serie { get; set; }

        [Display(Name = "Número Externo")]
        public virtual int ExtNumber { get; set; }
        [Required]
        [Display(Name = "Documento")]
        public Enums.DocumentType DocType { get; protected set; }
        [Required]
        [Display(Name = "Data")]
        public DateTime DocDate { get; set; }
        
        [Display(Name = "Prazo")]
        public DateTime? DueDate { get; set; }

        [Required]
        [Display(Name = "Código")]
        public int PartnerId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string PartnerName { get; set; }

        [Display(Name = "Transportadora")]
        public int ShippingCompany {get;set;}


        [Display(Name = "Endereço")]
        public string Address { get; set; }
        [Display(Name = "Número")]
        public string Number { get; set; }
        [Display(Name = "Complemento")]
        public string Complement { get; set; }
        [Display(Name = "Bairro")]
        public string Block { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Estado")]
        public string State { get; set; }
        [Display(Name = "País")]
        public string Country { get; set; }
        [Display(Name = "CEP")]
        public string ZipCode { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Contato")]
        public string Contact { get; set; }
        [Display(Name = "Comentários")]
        public string CommentsHeader { get; set; }
        [Display(Name = "Comentários")]
        public string CommentsFooter { get; set; }

        public void Update(DocumentModel model)
        {
            base.Update(model);
            ExtNumber = model.ExtNumber;
            Serie = model.Serie;
            DocType = model.DocType;
            DocDate = model.DocDate;
            DueDate = model.DueDate;
            PartnerId = model.PartnerId;
            PartnerName = model.PartnerName;
            Address = model.Address;
            Number = model.Number;
            Complement = model.Complement;
            Block = model.Block;
            City = model.City;
            State = model.State;
            Country = model.Country;
            ZipCode = model.ZipCode;
            Phone = model.Phone;
            Contact = model.Contact;
            CommentsHeader = model.CommentsHeader;
            CommentsFooter = model.CommentsFooter;
        }

        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }

    }
}