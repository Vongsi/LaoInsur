using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LaoInsur.Data;
using Volo.Abp.DependencyInjection;

namespace LaoInsur.EntityFrameworkCore;

public class EntityFrameworkCoreLaoInsurDbSchemaMigrator
    : ILaoInsurDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLaoInsurDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LaoInsurDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LaoInsurDbContext>()
            .Database
            .MigrateAsync();
    }
}
