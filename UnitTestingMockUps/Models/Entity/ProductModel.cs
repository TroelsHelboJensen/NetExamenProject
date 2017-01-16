using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class ProductModel
    {
        [Key] /* To set this to the Primary key of this property,
                 if the prop name isn't 
                                        [className] + Id 
                                        or
                                        Id
              */
        public int ProductModelId { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Name should more then 4 and less then 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ProductPrice should be included!")]
        public float ProductPrice { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Put in some instructions")]
        public string Instruction { get; set; }
    }
}