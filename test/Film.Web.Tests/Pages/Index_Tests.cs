using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Film.Pages;

public class Index_Tests : FilmWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
