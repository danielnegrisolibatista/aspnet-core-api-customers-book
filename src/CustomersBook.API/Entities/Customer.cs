using System;
using System.ComponentModel.DataAnnotations;

namespace CustomersBook.API.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Customer(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public Customer(int id, string firstName, string lastName, DateTime birthday)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
