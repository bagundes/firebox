using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Documents
{
    public abstract class Document_ItemModel : BaseModel, IBaseModel<Document_ItemModel>
    {

        public Document_ItemModel(int FatherId, Enums.DocumentType DocType)
        {
            this.DocType = DocType;
            this.FatherId = FatherId;
        }

        [Required]
        [Display(Name="Documento")]
        public Enums.DocumentType DocType {get;set;}
        
        [Required]
        [Display(Name = "Código")]
        public int ItemId {get;set;}
        [Required]
        [Display(Name = "Nome")]
        public string ItemName {get;set;}
        [Required]
        [Display(Name = "Quantidade")]
        public double Qtty {get;set;}
        [Required]
        [Display(Name = "Preço")]
        public double Price {get;set;}
        
        [Display(Name = "Desconto (%)")]
        public double DescPerc {get;set;}
        [Required]
        [Display(Name = "Número Externo")]
        public double DescValue {get;set;}

        [Display(Name = "Valor Linha")]
        /// <summary>
        /// Value total without taxes
        /// </summary>
        /// <value></value>
        public double TotalLine 
        {
            get => Qtty * (Price - (Price * DescPerc / 100) - DescValue);
        }
        /// <summary>
        /// Value total with taxes
        /// </summary>
        /// <value></value>
        public double Total
        {
            // Acrecentar os impostos
            get => TotalLine;
        }

        [StringLength(100)]
        public string Comments { get; set; }

        #region Comissão
        public int RuleId {get; set;}  
        [Display(Name = "Comissão (%)")]  
        public double CommPerc {get; set;}

        [Display(Name = "Comissão (R$)")]  
        public double CommValue {get => TotalLine * CommPerc / 100;}
        
        #endregion

        public void Update(Document_ItemModel model)
        {
            base.Update(model);
            DocType = model.DocType;
            ItemId = model.ItemId;
            ItemName = model.ItemName;
            Qtty = model.Qtty;
            Price = model.Price;
            DescPerc = model.DescPerc;
            DescValue = model.DescValue;
            Comments = model.Comments;
            RuleId = model.RuleId;
            CommPerc = model.CommPerc;
        }

        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }
    }
}