using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Core.Interfaces.Gateways.Repositories;

namespace Web.Api.Infrastructure.Data.ExternalRepository
{

    public class FireForgetRepositoryHandler : IFireForgetRepositoryHandler
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public FireForgetRepositoryHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }


        public void Execute(Func<IJobItemRepository, Task> databaseWork)
        { // Fire off the task, but don't await the result
            Task.Run(async () =>
            {
                // Exceptions must be caught
                try
                {
                    var scope = _serviceScopeFactory.CreateScope();
                    var repository = scope.ServiceProvider.GetRequiredService<IJobItemRepository>();
                    await databaseWork(repository);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
