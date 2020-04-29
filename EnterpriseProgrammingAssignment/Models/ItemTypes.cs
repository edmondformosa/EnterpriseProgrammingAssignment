using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.Models
{
    [Table("AspNetItemType", Schema = "dbo")]
    public class ItemTypes
    {
        [Key]
        public Guid ItemType_Id { get; set; }
        public Guid Category_Id { get; set; }
        public string ItemName { get; set; }
        public string ImageUrl { get; set; }
    }
}