using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(255, ErrorMessage = "This field should contains between 2 and 255 characteres")]
        [MinLength(2, ErrorMessage = "This field should contains between 2 and 255 characteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(255, ErrorMessage = "This field should contains between 2 and 255 characteres")]
        [MinLength(2, ErrorMessage = "This field should contains between 2 and 255 characteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime Birthday { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
