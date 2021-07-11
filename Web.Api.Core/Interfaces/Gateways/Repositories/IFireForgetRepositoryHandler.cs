using System;
using System.Threading.Tasks;
using Web.Api.Core.Interfaces.Gateways.Repositories;

namespace Web.Api.Core.Interfaces.Gateways.Repositories
{
    public interface IFireForgetRepositoryHandler
    {
        void Execute(Func<IJobItemRepository, Task> databaseWork);
    }
}