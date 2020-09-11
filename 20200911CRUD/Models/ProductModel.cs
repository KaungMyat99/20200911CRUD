using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _20200911CRUD.Models
{
    public class ProductModel
    {
        public List<ProductEntity> lstProduct { get; set; }

        public _MessageModel Msg { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }
}