using Inforce.TestTask.Abstractions.Repositories;
using Inforce.TestTask.Data;
using Inforce.TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace Inforce.TestTask.Repositories;

public class AlgorithmInfoRepository : IAlgorithmInfoRepository
{
    private readonly ApplicationDbContext context;

    public AlgorithmInfoRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<AlgorithmInfoModel> Get()
    {
        var algorithmModel = await context.AlgorithmModels.FirstOrDefaultAsync();

        if (algorithmModel == null)
            throw new Exception();

        return algorithmModel;
    }

    public async Task<AlgorithmInfoModel> Update(AlgorithmInfoModel algorithmModel)
    {
        var post = await context.AlgorithmModels.FirstOrDefaultAsync();

        if (post == null)
            throw new Exception();
        
        post.Stage1 = algorithmModel.Stage1;
        post.Stage2 = algorithmModel.Stage2;
        post.Stage3 = algorithmModel.Stage3;
        post.Stage4 = algorithmModel.Stage4;
        post.Stage5 = algorithmModel.Stage5;
        post.Stage6 = algorithmModel.Stage6;
        post.Stage7 = algorithmModel.Stage7;

        await context.SaveChangesAsync();

        return algorithmModel;
    }
}