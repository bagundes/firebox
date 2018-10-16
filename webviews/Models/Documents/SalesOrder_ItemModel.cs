using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Documents
{
    [Table("ORDER1")]
    public class SalesOrder_ItemModel : Document_ItemModel
    {
        public SalesOrder_ItemModel() : base(-1, Enums.DocumentType.None)
        {

        }
        public SalesOrder_ItemModel(SalesOrder_ItemModel model) : base(model.Id, Enums.DocumentType.SalesOrder)
        {
            if(model.DocType != Enums.DocumentType.SalesOrder)
            {
                throw new Exception($"Este model não pertence ao documento {Enums.DocumentType.SalesOrder.ToString()}");
            }
        }

        [NotMapped]
        public List<SalesOrder_TaxModel> Taxes = new List<SalesOrder_TaxModel>();

        public override void OnModelCreating<T>(ModelBuilder modelBuilder)
        {

            var e = modelBuilder.Entity<T>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<T>(modelBuilder);
        }

        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new SalesOrder_ItemModel()).OnModelCreating<SalesOrder_ItemModel>(modelBuilder);
        }
    }
}