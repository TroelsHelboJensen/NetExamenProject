using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class CategoryModel
    {
        public int CategoryModelId { get; set; }
        [Required]
        public string Name { get; set; }

        // Relational Multiple connection to CategoryHeaderModel
        public int CategoryHeaderModelId { get; set; }
        public virtual CategoryHeaderModel CategoryHeaderModel { get; set; }
    }
}