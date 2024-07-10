using System.Diagnostics;
using TestSite.API.Application.Models;

namespace TestSite.API.Application.Contracts.Test.PassTest;

public class PassTestResponse
{
    public PassedTestModel PassedTestModel { get; set; } = default!;
}