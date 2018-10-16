using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Documents
{
    public abstract class Document_TaxModel : Taxes.TaxModel, IBaseModel<Document_TaxModel>
    {
        public Document_TaxModel(Document_ItemModel Item, Taxes.TaxModel Tax)
        {   
            if(Item == null)
                return;

            this.DocType = Item.DocType;
            this.LineId = Item.Id;
            this.FatherId = Item.FatherId;
            this.TaxId = Tax.Id;
            this.TaxName = Tax.TaxName;
            this.Fee = Tax.Fee;
            this.Discont = Tax.Discont;
            this.AddTotalLine = Tax.AddTotalLine;
            this.Base = Tax.Base;

            var priceBase = Item.TotalLine;
            
            priceBase = priceBase - this.Discont;
            priceBase = priceBase * this.Base;

            this.TaxValue = priceBase * Fee / 100;
            this.TaxTotal = AddTotalLine ? TaxValue + Item.TotalLine : TaxValue;
        }

        public int TaxId {get; protected set;}

        [Required]
        [Display(Name="Linha Item")]
        public int LineId {get; protected set;}

        [Required]
        [Display(Name="Documento")]
        public Enums.DocumentType DocType {get; protected set;}
        
        [Display(Name="Valor Imposto")]
        public double TaxValue {get; protected set;}

        [Display(Name="Valor Total")]
        public double TaxTotal {get; protected set;}

        public void Update(Document_TaxModel model)
        {
            throw new Exception("Não é possivel atualizar o imposto, desabilite esta linha e faça uma nova");
        }

        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }

    }
}