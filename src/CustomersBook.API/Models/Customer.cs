using System;
using System.ComponentModel.DataAnnotations;

namespace CustomersBook.API.Models
{
    public class Customer
    {
        public Customer(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        [Key]
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
