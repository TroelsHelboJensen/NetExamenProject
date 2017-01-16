using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class CategoryHeaderModel
    {
        public int CategoryHeaderModelId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<CategoryModel> Categories { get; set; }
    }
}