using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace LaoInsur;

[Dependency(ReplaceServices = true)]
public class LaoInsurBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LaoInsur";
}
