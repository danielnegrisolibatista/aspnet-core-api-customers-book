using System;
using System.ComponentModel.DataAnnotations;

namespace CustomersBook.API.DTO
{
    public class UpdateCustomerModel
    {
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

        public UpdateCustomerModel()
        {

        }
        public UpdateCustomerModel(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public UpdateCustomerModel(int id, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
