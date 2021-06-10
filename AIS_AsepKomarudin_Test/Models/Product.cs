using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AIS_AsepKomarudin_Test.Models
{
    public class Product
    {
        private int _id;

        [Display(Name = "Product Code")]
        public int Id { get => _id; set => _id = value; }

        [Required(ErrorMessage = "Barcode is required.")]
        public int Barcode { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }
    }

    public class ReportProduct
    {
        [Required(ErrorMessage = "Barcode is required.")]
        public int Barcode { get; set; }
        public int Jumlah { get; set; }
        public decimal Total_harga { get; set; }
        public int ready { get; set; }
        public int onhold { get; set; }
        public int delivered { get; set; }
        public int packing { get; set; }
        public int sent { get; set; }
    }
}