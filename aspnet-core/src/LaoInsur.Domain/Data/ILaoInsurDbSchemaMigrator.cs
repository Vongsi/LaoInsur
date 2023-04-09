using System.Threading.Tasks;

namespace LaoInsur.Data;

public interface ILaoInsurDbSchemaMigrator
{
    Task MigrateAsync();
}
