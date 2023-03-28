using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeskEntity.Model
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [ForeignKey("LoginTable")]
        public int EmployeeID { get; set; }

        public LoginTable LoginTable { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Invalid Email Address.")]
        public string EmployeeEmail { get; set; }

        public string Role { get; set; }

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }

        [StringLength(12, MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "char(1)")]
        public char Gender { get; set; }

        public string SecurityQuestion { get; set; }
    }
}
