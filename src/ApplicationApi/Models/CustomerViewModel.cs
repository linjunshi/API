using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ApplicationApi.Models
{
    public class CustomerViewModel
    {
        [Required(ErrorMessage = "Please enter your name!")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter an email!")]
        public string email { get; set; } 

        [Required(ErrorMessage = "Please enter a contact number!")]
        public string contact { get; set; }

        public string experienceTitle { get; set; }

        public string experienceCompany { get; set; }

        public DateTime experienceDate { get; set; }

        public string experienceInRole { get; set; }

        [MaxLength(500, ErrorMessage="Maximum length is 500 characters!")]
        public string comment { get; set; }

        //[Required(ErrorMessage = "Please upload your resume!")]
        //public IFormFile cv { get; set; }

    }
}

/*
<form>
   <input type="text" name="name">
   <input type="text" name="email">
   <input type="text" name="contact">
   <input type="text" name="experienceTitle">
   <input type="text" name="experienceCompany">
   <input type="text" name="experienceDate">
   <input type="checkbox" name="experienceInRole">
   <textarea name="comments"></textarea>
   <input type="file" name="cv">
</form>
     */
