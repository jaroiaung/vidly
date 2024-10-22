using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace vidly.Models
{
    public class SendEmailTester
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public string Pin { get; set; }

        [NotMapped]
		public string PinToVerify { get; set; }

        public DateTime PinDate { get; set; }
    }
}