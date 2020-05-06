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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemType_Id { get; set; }
        public long Category_Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Categories category { get; set; }

        public virtual ICollection<ItemDetails> ItemDetails { get; set; }
    }
}