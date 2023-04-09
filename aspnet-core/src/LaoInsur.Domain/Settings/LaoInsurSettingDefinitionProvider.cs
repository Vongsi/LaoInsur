using Volo.Abp.Settings;

namespace LaoInsur.Settings;

public class LaoInsurSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LaoInsurSettings.MySetting1));
    }
}
