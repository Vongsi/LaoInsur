using System;
using System.Collections.Generic;
using System.Text;
using LaoInsur.Localization;
using Volo.Abp.Application.Services;

namespace LaoInsur;

/* Inherit your application services from this class.
 */
public abstract class LaoInsurAppService : ApplicationService
{
    protected LaoInsurAppService()
    {
        LocalizationResource = typeof(LaoInsurResource);
    }
}
