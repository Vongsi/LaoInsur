using LaoInsur.Territories.Addresses;
using LaoInsur.Territories.Continents;
using LaoInsur.Territories.Countries;
using LaoInsur.Territories.Districts;
using LaoInsur.Territories.Provinces;
using LaoInsur.Territories.Villages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace LaoInsur.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class LaoInsurDbContext :
    AbpDbContext<LaoInsurDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region - Territories

    public DbSet<Continent> Continents { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<Address> Addresses { get; set; }

    #endregion - Territories

    public LaoInsurDbContext(DbContextOptions<LaoInsurDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LaoInsurConsts.DbTablePrefix + "YourEntities", LaoInsurConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Continent>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Continents",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
            e.Property(x => x.ISO2Codes).IsRequired().HasMaxLength(2);
        });

        builder.Entity<Country>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Countries",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
            e.Property(x => x.ISO2Codes).IsRequired().HasMaxLength(2);
            e.Property(x => x.ISO3Codes).IsRequired().HasMaxLength(3);
        });

        builder.Entity<Province>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Provinces",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<District>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Districts",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Village>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Villages",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Address>(e => {
            e.ToTable(LaoInsurConsts.DbTablePrefix + "Addresses",
                LaoInsurConsts.DbSchema);
            e.ConfigureByConvention(); //auto configure for the base class props
        });
    }
}
