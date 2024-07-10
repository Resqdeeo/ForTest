namespace TestSite.API.Application.Contracts.Test.GetAvailableTests;

/// <summary>
/// Ответ для запроса доступных тестов
/// </summary>
public class GetAvailableTestsProp
{
    /// <summary>
    /// Id теста
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название теста
    /// </summary>
    public string Title { get; set; }
}

public class GetAvailableTestsResponse
{
    public List<GetAvailableTestsProp> Tests { get; set; } = default!;
}

