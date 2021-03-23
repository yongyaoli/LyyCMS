using System.Threading.Tasks;
using LyyCMS.Models.TokenAuth;
using LyyCMS.Web.Controllers;
using Shouldly;
using Xunit;

namespace LyyCMS.Web.Tests.Controllers
{
    public class HomeController_Tests: LyyCMSWebTestBase
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