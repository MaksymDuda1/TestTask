namespace Inforce.TestTask.Abstractions.Services;

public interface IGenerateCodeService
{
    Task<string> GenerateUniqueCode();
    Task<string> GenerateUniqueCode(string code);
}