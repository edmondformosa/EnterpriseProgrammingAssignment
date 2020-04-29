using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.Models
{
    [Table("AspNetItemDetails", Schema = "dbo")]
    public class ItemDetails
    {
        [Key]
        public Guid Item_Id { get; set; }
        public Guid ItemType_Id { get; set; }
        public int Quality_Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Guid User_Id { get; set; }

    }
}