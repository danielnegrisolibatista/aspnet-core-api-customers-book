using CustomersBook.API.Data.Repositories;
using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using CustomersBook.API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomersBook.UnitTests.Services
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task ShouldReturnSuccessWhenCreateCustomer()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var customerInputModel = new CreateCustomerModel("Daniel", "Negrisoli Batista", new DateTime(1980, 1, 1));

            customerRepositoryMock.Setup(pr => pr.SaveAsync(It.IsAny<Customer>())).Verifiable();

            var customerService = new CustomerService(customerRepositoryMock.Object);

            // Act
            var customer = await customerService.CreateCustomer(customerInputModel);

            // Assert
            Assert.Equal(customerInputModel.FirstName, customer.FirstName);
            customerRepositoryMock.Verify(pr => pr.SaveAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnSuccessWhenUpdateCustomer()
        {
            // Arrange
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var customerInputModel = new UpdateCustomerModel(1, "Daniel", "Negrisoli Batista", new DateTime(1980, 1, 1));

            customerRepositoryMock.Setup(pr => pr.GetById(1)).Verifiable();
            customerRepositoryMock.Setup(pr => pr.UpdateAsync(It.IsAny<Customer>())).Verifiable();
            

            var customerService = new CustomerService(customerRepositoryMock.Object);

            // Act
            var customer = await customerService.UpdateCustomer(1, customerInputModel);

            // Assert
            Assert.Equal(customerInputModel.FirstName, customer.FirstName);
            customerRepositoryMock.Verify(pr => pr.UpdateAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
