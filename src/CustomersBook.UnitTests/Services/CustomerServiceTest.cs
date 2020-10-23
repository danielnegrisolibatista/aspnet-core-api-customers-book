using CustomersBook.API.Data.Repositories;
using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using CustomersBook.API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


/// <summary>
/// https://www.codeproject.com/articles/47603/mock-a-database-repository-using-moq
/// </summary>
namespace CustomersBook.UnitTests.Services
{
    public class CustomerServiceTest
    {
        /// <summary>
        /// Our Mock Customer Repository for use in testing
        /// </summary>
        public readonly ICustomerRepository CustomerRepositoryMock;

        public CustomerServiceTest()
        {
            // create some mock customers
            List<Customer> customers = new List<Customer>
                {
                    new Customer(1, "Vinícius", "Correia", new DateTime(1980, 1, 1)),
                    new Customer(2, "Lakesha", "Joiner", new DateTime(1990, 1, 1)),
                    new Customer(3, "Cauã", "Silva", new DateTime(2000, 1, 1))
                };


            // Mock the Customer Repository using Moq
            Mock<ICustomerRepository> customerRepositoryMock = new Mock<ICustomerRepository>();

            // Return all the Customer
            customerRepositoryMock.Setup(mr => mr.Get()).Returns(customers);

            // return a customer by Id
            customerRepositoryMock.Setup(mr => mr.GetById(It.IsAny<int>())).Returns((int id) => customers.Where(w => w.Id == id).Single());

            // Allows us to test saving a Customer
            customerRepositoryMock.Setup(mr => mr.Save(It.IsAny<Customer>())).Verifiable();

            // Allows us to test update a Customer
            customerRepositoryMock.Setup(mr => mr.Update(It.IsAny<Customer>())).Verifiable();

            // Complete the setup of our Mock Customer Repository
            this.CustomerRepositoryMock = customerRepositoryMock.Object;
        }

        [Fact]
        public void ShouldReturnAllCustomers()
        {
            // Arrange

            // Act
            List<Customer> testCustomers = this.CustomerRepositoryMock.Get();

            // Assert
            Assert.NotNull(testCustomers); // Test if null
            Assert.Equal(3, testCustomers.Count); // Verify the correct Number
        }

        /// <summary>
        /// Can we return a Customer By Id?
        /// </summary>
        [Fact]
        public void ShouldReturnCustomerById()
        {
            // Arrange
            int id = 2;

            // Act
            Customer testCustomers = this.CustomerRepositoryMock.GetById(id);

            // Assert
            Assert.NotNull(testCustomers); // Test if null
            Assert.IsType<Customer>(testCustomers); // Test type
            Assert.Equal("Lakesha", testCustomers.FirstName); // Verify it is the right Customer
        }

        [Fact]
        public void ShouldReturnSuccessWhenCreateCustomer()
        {
            // Arrange
            var customerInputModel = new CreateCustomerModel("Daniel", "Negrisoli Batista", new DateTime(1980, 1, 1));
            var customerService = new CustomerService(this.CustomerRepositoryMock);

            // Act
            var customer = customerService.CreateCustomer(customerInputModel);

            // Assert
            Assert.Equal(customerInputModel.FirstName, customer.FirstName);
        }

        [Fact]
        public void ShouldReturnSuccessWhenUpdateCustomer()
        {
            // Arrange
            var customerInputModel = new UpdateCustomerModel(1, "Daniel", "Negrisoli Batista", new DateTime(1980, 1, 1));
            var customerService = new CustomerService(this.CustomerRepositoryMock);

            // Act
            var customer = customerService.UpdateCustomer(1, customerInputModel);

            // Assert
            Assert.Equal(customerInputModel.FirstName, customer.FirstName);
        }

        //[Fact]
        //public async Task ShouldReturnSuccessWhenUpdateCustomer()
        //{
        //    // Arrange
        //    var customerRepositoryMock = new Mock<ICustomerRepository>();

        //    var customerInputModel = new UpdateCustomerModel(1, "Daniel", "Negrisoli Batista", new DateTime(1980, 1, 1));

        //    customerRepositoryMock.Setup(pr => pr.GetById(1)).Verifiable();
        //    customerRepositoryMock.Setup(pr => pr.Update(It.IsAny<Customer>())).Verifiable();


        //    var customerService = new CustomerService(customerRepositoryMock.Object);

        //    // Act
        //    var customer = customerService.UpdateCustomer(1, customerInputModel);

        //    // Assert
        //    Assert.Equal(customerInputModel.FirstName, customer.FirstName);
        //    customerRepositoryMock.Verify(pr => pr.Update(It.IsAny<Customer>()), Times.Once);
        //}
    }
}
