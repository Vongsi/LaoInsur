using Volo.Abp.Modularity;

namespace LaoInsur;

[DependsOn(
    typeof(LaoInsurApplicationModule),
    typeof(LaoInsurDomainTestModule)
    )]
public class LaoInsurApplicationTestModule : AbpModule
{

}
