using Inforce.TestTask.Models;

namespace Inforce.TestTask.Abstractions.Repositories;

public interface IAlgorithmInfoRepository
{
    Task<AlgorithmInfoModel> Get();
    Task<AlgorithmInfoModel> Update(AlgorithmInfoModel algorithmModel);
}