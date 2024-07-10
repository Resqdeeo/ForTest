using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestSite.API.Application.Contracts.Test.CreateNewTest;
using TestSite.API.Application.Contracts.Test.GetAvailableTests;
using TestSite.API.Application.Contracts.Test.GetTestById;
using TestSite.API.Application.Features.Queries.Test.CreateNewTest;
using TestSite.API.Application.Features.Queries.Test.GetAvailableTests;
using TestSite.API.Application.Features.Queries.Test.GetTestById;

namespace TestSite.API.WEB.Controllers;

/// <summary>
/// Контроллер тестов
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Медиатр
    /// </summary>
    /// <param name="mediator"></param>
    public TestController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Доступные тесты
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("GetAvailableTests")]
    public async Task<GetAvailableTestsResponse> GetAvailableTests(CancellationToken cancellationToken)
        => await _mediator.Send(new GetAvailableTestsQuery(), cancellationToken);


    /// <summary>
    /// Тест по айди для прохождения 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetTestById/{testId:guid}")]
    public async Task<GetTestByIdResponse> GetTestById(Guid testId, CancellationToken cancellationToken)
        => await _mediator.Send(new GetTestByIdQuery(testId), cancellationToken);
    
    
    [HttpPost("CreateNewTest")]
    public async Task<CreateNewTestResponse> CreateTest(CreateNewTestRequest request) 
        => await _mediator.Send(new CreateNewTestCommand(request));
}