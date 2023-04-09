using LaoInsur.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LaoInsur.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LaoInsurEntityFrameworkCoreModule),
    typeof(LaoInsurApplicationContractsModule)
    )]
public class LaoInsurDbMigratorModule : AbpModule
{

}
