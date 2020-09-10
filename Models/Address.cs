using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(255, ErrorMessage = "This field should contains between 10 and 255 characteres")]
        [MinLength(10, ErrorMessage = "This field should contains between 10 and 255 characteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string ZipCode { get; set; } 
    }
}
