using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;
using System.Collections.Generic;

namespace webviews.Models.Documents
{
    [Table("ORDER0")]
    public class SalesOrderModel : DocumentModel
    {
        public SalesOrderModel() : base(Enums.DocumentType.None)
        {

        }
        public SalesOrderModel(SalesOrderModel model) : base(Enums.DocumentType.SalesOrder)
        {
            if(model.DocType != Enums.DocumentType.SalesOrder)
            {
                throw new Exception($"Este model não pertence ao documento {Enums.DocumentType.SalesOrder.ToString()}");
            }
        }


        public override int DocNumber {get => Id; }

        [NotMapped]
        public List<SalesOrder_ItemModel> Items = new List<SalesOrder_ItemModel>();
      
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new SalesOrderModel()).OnModelCreating<SalesOrderModel>(modelBuilder);
        }
    }
}