namespace DotNetCoreFrameWork.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
