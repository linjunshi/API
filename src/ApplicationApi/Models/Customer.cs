using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationApi.Models
{
    public class Customer
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string experienceTitle { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string contact { get; set; }

        public string experienceCompany { get; set; }

        public DateTime experienceDate { get; set; }

        public bool experienceInRole { get; set; }

        [MaxLength(500)]
        public string comment { get; set; }

        //[Required]
        //public byte[] cv { get; set; }

        //public string IPAddress { get; set; }

        public DateTime PostTime { get; set; }

    }
}
