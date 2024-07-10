namespace TestSite.API.Application.Contracts.Test.CreateNewTest;

public class CreateNewTestResponse
{
    /// <summary>
    /// ID созданного теста.
    /// </summary>
    public Guid TestId { get; set; }

    /// <summary>
    /// Сообщение о результате операции.
    /// </summary>
    public string Message { get; set; }
}