using LaoInsur.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LaoInsur.Permissions;

public class LaoInsurPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(LaoInsurPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LaoInsurPermissions.MyPermission1, L("Permission:MyPermission1"));

        var LaoInsurGroup = context.AddGroup(LaoInsurPermissions.GroupName, L("Permission:LaoInsur"));

        var continentPermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Continents.Default, L("Permission:Continents"));
        continentPermission.AddChild(LaoInsurPermissions.Continents.Create, L("Permission:Continents.Create"));
        continentPermission.AddChild(LaoInsurPermissions.Continents.Edit, L("Permission:Continents.Edit"));
        continentPermission.AddChild(LaoInsurPermissions.Continents.Delete, L("Permission:Continents.Delete"));

        var countryPermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Countries.Default, L("Permission:Countries"));
        countryPermission.AddChild(LaoInsurPermissions.Countries.Create, L("Permission:Countries.Create"));
        countryPermission.AddChild(LaoInsurPermissions.Countries.Edit, L("Permission:Countries.Edit"));
        countryPermission.AddChild(LaoInsurPermissions.Countries.Delete, L("Permission:Countries.Delete"));

        var provincePermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Provinces.Default, L("Permission:Provinces"));
        provincePermission.AddChild(LaoInsurPermissions.Provinces.Create, L("Permission:Provinces.Create"));
        provincePermission.AddChild(LaoInsurPermissions.Provinces.Edit, L("Permission:Provinces.Edit"));
        provincePermission.AddChild(LaoInsurPermissions.Provinces.Delete, L("Permission:Provinces.Delete"));

        var districtPermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Districts.Default, L("Permission:Districts"));
        districtPermission.AddChild(LaoInsurPermissions.Districts.Create, L("Permission:Districts.Create"));
        districtPermission.AddChild(LaoInsurPermissions.Districts.Edit, L("Permission:Districts.Edit"));
        districtPermission.AddChild(LaoInsurPermissions.Districts.Delete, L("Permission:Districts.Delete"));

        var villagePermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Villages.Default, L("Permission:Villages"));
        villagePermission.AddChild(LaoInsurPermissions.Villages.Create, L("Permission:Villages.Create"));
        villagePermission.AddChild(LaoInsurPermissions.Villages.Edit, L("Permission:Villages.Edit"));
        villagePermission.AddChild(LaoInsurPermissions.Villages.Delete, L("Permission:Villages.Delete"));

        var addressPermission = LaoInsurGroup.AddPermission(LaoInsurPermissions.Addresses.Default, L("Permission:Addresses"));
        addressPermission.AddChild(LaoInsurPermissions.Addresses.Create, L("Permission:Addresses.Create"));
        addressPermission.AddChild(LaoInsurPermissions.Addresses.Edit, L("Permission:Addresses.Edit"));
        addressPermission.AddChild(LaoInsurPermissions.Addresses.Delete, L("Permission:Addresses.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LaoInsurResource>(name);
    }
}
