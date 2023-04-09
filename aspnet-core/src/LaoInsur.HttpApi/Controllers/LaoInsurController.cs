using LaoInsur.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LaoInsur.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LaoInsurController : AbpControllerBase
{
    protected LaoInsurController()
    {
        LocalizationResource = typeof(LaoInsurResource);
    }
}
