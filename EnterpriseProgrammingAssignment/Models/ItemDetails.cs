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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Item_Id { get; set; }
        public long ItemType_Id { get; set; }
        public int Quality_Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity cannot be negative number!")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price cannot be negative number!")]
        public decimal Price { get; set; }
        public string User_Id { get; set; }

        [ForeignKey("ItemType_Id")]
        public virtual ItemTypes itemType { get; set; }
        [ForeignKey("Quality_Id")]
        public virtual Quality quality { get; set; }
        [ForeignKey("User_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}