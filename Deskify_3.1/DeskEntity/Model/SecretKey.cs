using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeskEntity.Model
{
    [Table("secretKeys")]
    public class SecretKey
    {
        [Key]
        public int SecretId { get; set; }

        public string SecretKeyGen { get; set; }

        public string SecretKeyType { get; set;}


        [ForeignKey("BookingSeat")]
        public int BookingSeatId { get; set; }
        public BookingSeat BookingSeat { get; set; }
    }
}
