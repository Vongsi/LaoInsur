using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LaoInsur.Data;

/* This is used if database provider does't define
 * ILaoInsurDbSchemaMigrator implementation.
 */
public class NullLaoInsurDbSchemaMigrator : ILaoInsurDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
