using Inforce.TestTask.Abstractions.Repositories;
using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;
using Inforce.TestTask.Repositories;

namespace Inforce.TestTask.Services;

public class AlgorithmInfoService : IAlgorithmInfoService
{
    private readonly IAlgorithmInfoRepository algorithmInfoRepository;

    public AlgorithmInfoService(IAlgorithmInfoRepository algorithmInfoRepository)
    {
        this.algorithmInfoRepository = algorithmInfoRepository;
    }
    
    public async Task<AlgorithmInfoModel> GetAlgorithmInfo()
    {
        return await algorithmInfoRepository.Get();
    }

    public async Task<AlgorithmInfoModel> UpdateAlgorithmInfo(AlgorithmInfoDto request)
    {
        var algorithmInfo = new AlgorithmInfoModel()
        {
            Stage1 = request.Stage1,
            Stage2 = request.Stage2,
            Stage3 = request.Stage3,
            Stage4 = request.Stage4,
            Stage5 = request.Stage5,
            Stage6 = request.Stage6,
            Stage7 = request.Stage7
        };

        return await algorithmInfoRepository.Update(algorithmInfo);
    }
}