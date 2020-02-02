using System.Threading.Tasks;
using HoA.Entity;
using HoA.Service.Contracts;
using HoA.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HoA.UI.Test
{
    public class CustomerControllerTest
    {
        private readonly Mock<CustomerController> _customerController;
        private Mock<ICustomerService> _customerService;
        public CustomerControllerTest()
        {
            _customerService = new Mock<ICustomerService>();
            _customerController = new Mock<CustomerController>(_customerService);
        }

        [Fact]
        public async Task IndexTestAsync()
        {
            var result = await _customerController.Object.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task DetailsTestAsync()
        {
            var result = await _customerController.Object.Details(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.ViewData.Model != null);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task CreateTestAsync()
        {
            var result = await _customerController.Object.Details(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task EditTestAsync()
        {
            var result = await _customerController.Object.Edit(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.ViewData.Model != null);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task UpdateTestAsync()
        {
            var editResult = await _customerController.Object.Edit(1);
            var editViewResult = Assert.IsType<ViewResult>(editResult);

            var result = await _customerController.Object.Edit(1, (Customer)editViewResult.ViewData.Model);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.ViewData.Model != null);
            Assert.IsAssignableFrom<Customer>(viewResult.ViewData.Model);
        }
    }
}
