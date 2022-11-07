using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category ProductCategory { get; set; }
        public string ImageSrc { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
    }
}