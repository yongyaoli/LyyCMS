using System.Threading.Tasks;
using LyyVueCMS.Models.TokenAuth;
using LyyVueCMS.Web.Controllers;
using Shouldly;
using Xunit;

namespace LyyVueCMS.Web.Tests.Controllers
{
    public class HomeController_Tests: LyyVueCMSWebTestBase
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