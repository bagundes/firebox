using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Documents
{
    [Table("ORDER2")]
    public class SalesOrder_TaxModel : Document_TaxModel
    {
        public SalesOrder_TaxModel() : base(null, null)
        {

        }
        public SalesOrder_TaxModel(SalesOrder_ItemModel model, Taxes.TaxModel tax ) : base(model, tax)
        {
            if(model.DocType != Enums.DocumentType.SalesOrder)
            {
                throw new Exception($"Este model não pertence ao documento {Enums.DocumentType.SalesOrder.ToString()}");
            }
        }


        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new SalesOrder_TaxModel()).OnModelCreating<SalesOrder_TaxModel>(modelBuilder);
        }
    }
}