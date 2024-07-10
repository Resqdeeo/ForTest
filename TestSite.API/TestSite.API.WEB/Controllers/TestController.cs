using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestSite.API.Application.Contracts.Test.CreateNewTest;
using TestSite.API.Application.Contracts.Test.GetAvailableTests;
using TestSite.API.Application.Contracts.Test.GetPassedTests;
using TestSite.API.Application.Contracts.Test.GetTestById;
using TestSite.API.Application.Contracts.Test.GetTestPasses;
using TestSite.API.Application.Contracts.Test.PassTest;
using TestSite.API.Application.Features.Queries.Test.CreateNewTest;
using TestSite.API.Application.Features.Queries.Test.GetAvailableTests;
using TestSite.API.Application.Features.Queries.Test.GetPassedTests;
using TestSite.API.Application.Features.Queries.Test.GetTestById;
using TestSite.API.Application.Features.Queries.Test.GetTestPasses;
using TestSite.API.Application.Features.Queries.Test.PassTest;

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
    
    
    /// <summary>
    /// Создание нового теста
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CreateNewTest")]
    public async Task<CreateNewTestResponse> CreateTest(CreateNewTestRequest request, CancellationToken cancellationToken) 
        => await _mediator.Send(new CreateNewTestCommand(request), cancellationToken);


    /// <summary>
    /// Получение пройденных ранее тестов
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetPassedTests")]
    public async Task<GetPassedTestsResponse> GetPassedTests(CancellationToken cancellationToken)
        => await _mediator.Send(new GetPassedTestsQuery(), cancellationToken);

    
    /// <summary>
    /// Прохождение теста
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("PassTest")]
    public async Task<PassTestResponse> PassTest(PassTestRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(new PassTestCommand(request), cancellationToken);


    /// <summary>
    /// Получение сведений о прохождении теста 
    /// </summary>
    /// <param name="testId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("GetTestPasses/{testId:guid}")]
    public async Task<GetTestPassesResponse> GetTestPasses(Guid testId, CancellationToken cancellationToken)
        => await _mediator.Send(new GetTestPassesQuery(testId), cancellationToken);
}