using LaoInsur.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LaoInsur;

[DependsOn(
    typeof(LaoInsurEntityFrameworkCoreTestModule)
    )]
public class LaoInsurDomainTestModule : AbpModule
{

}
