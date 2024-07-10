using TestSite.API.Application.Models;

namespace TestSite.API.Application.Contracts.Test.GetPassedTests;

public class GetPassedTestsResponse
{
    public List<PassedTestModel> PassedTests { get; set; }
}