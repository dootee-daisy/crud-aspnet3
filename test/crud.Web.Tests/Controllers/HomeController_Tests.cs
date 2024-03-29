using System.Threading.Tasks;
using crud.Models.TokenAuth;
using crud.Web.Controllers;
using Shouldly;
using Xunit;

namespace crud.Web.Tests.Controllers
{
    public class HomeController_Tests: crudWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}