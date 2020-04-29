using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.Models
{
    [Table("AspNetCategories", Schema = "dbo")]
    public class Categories
    {
        [Key]
        public Guid Category_Id { get; set; }
        public string CategoryName { get; set; }
    }
}