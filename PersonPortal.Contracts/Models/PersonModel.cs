using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonPortal.Contracts.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [RegularExpression("([ა-ჰ]*$)|([a-z]*$)", ErrorMessage = "შეიყვანეთ მხოლოდ ქართული ან ლათინური სიმბოლოები")]
        [Required(ErrorMessage = "სახელი აუცილებელი ველია")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "სახელი უნდა იყოს მინუმუმ 2 და მაქსიმუმ 50 სიმბოლო")]
        public string FirstName { get; set; }
        [RegularExpression("([ა-ჰ]*$)|([a-z]*$)", ErrorMessage = "შეიყვანეთ მხოლოდ ქართული ან ლათინური სიმბოლოები")]
        [Required(ErrorMessage = "გვარი აუცილებელი ველია")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "სახელი უნდა იყოს მინუმუმ 2 და მაქსიმუმ 50 სიმბოლო")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "სქესი აუცილებელი ველია")]
        public int GenderiD { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "პირადი ნომერი უნდა იყოს 11 სიმბოლო")]
        [Required(ErrorMessage = "პირადი ნომერი აუცილებელი ველია")]
        public string PersonalNumber { get; set; }
        [Required(ErrorMessage = "დაბადების თარიღი აუცილებელი ველია")]
        public DateTime BirthDate { get; set; }
        public int? CityId { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public List<PersonModel> RelatedPersons { get; set; }
        public IFormFile file { get; set; }
    }
}
