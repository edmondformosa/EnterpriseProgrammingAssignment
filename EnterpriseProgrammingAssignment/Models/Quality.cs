using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnterpriseProgrammingAssignment.Models
{
    [Table("AspNetQuality", Schema = "dbo")]
    public class Quality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Quality_Id { get; set; }
        public string QualityType { get; set; }

        public virtual ICollection<ItemDetails> itemDetails { get; set; }
    }
}