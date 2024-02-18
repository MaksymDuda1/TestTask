using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;

namespace Inforce.TestTask.Abstractions.Services;

public interface IAlgorithmInfoService
{
    Task<AlgorithmInfoModel> GetAlgorithmInfo();
    Task<AlgorithmInfoModel> UpdateAlgorithmInfo(AlgorithmInfoDto request);
}