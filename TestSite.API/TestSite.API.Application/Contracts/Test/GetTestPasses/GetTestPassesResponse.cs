using TestSite.API.Application.Models;

namespace TestSite.API.Application.Contracts.Test.GetTestPasses;

public class GetTestPassesResponse
{
    public List<PassedTestModel> TestPasses { get; set; } = default!;
}