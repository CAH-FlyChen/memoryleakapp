using B2BAgent.Server.Domains;
using B2BAgent.Server.Users;
using EV.Domain.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

namespace B2BAgent.Server.EntityFrameworkCore
{
    public static class ServerDbContextModelCreatingExtensions
    {
        public static void ConfigureServer(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ServerConsts.DbTablePrefix + "YourEntities", ServerConsts.DbSchema);

            //    //...
            //});
            builder.Entity<SysDict>(b => { 
                b.ToTable("sys_dict");
                b.Property(t => t.IsDeleted).HasDefaultValue(false);
            });
            builder.Entity<SysDictItem>(b=> {
                b.ToTable("sys_dict_item");
                //b.Property(t => t.IsDeleted).HasDefaultValue(false);
                b.HasOne(t => t.SysDict).WithMany(a => a.SysDictItems).HasForeignKey(t => t.SysDictId);
            });

            //builder.Entity<BusinessTenant>(b => { 
            //    b.ToTable("biz_tenant");
            //    b.Property(t => t.ExtraId).HasMaxLength(32);
            //});
            builder.Entity<ERPBrand>(b=> {
                b.ToTable("biz_erp_brand");
                b.Property(t => t.Name).HasMaxLength(50);
            });





            builder.Entity<TenantConnectionString>(x=> { 
                x.HasKey(x => new { x.TenantId, x.Name });
            });

            

            builder.Entity<Tenant>(b =>
            {
                b.ToTable("AbpTenants");
                b.Property(e => e.Name).HasColumnName(nameof(Tenant.Name)).IsRequired().HasMaxLength(TenantConsts.MaxNameLength);
                b.Property(e => e.CreationTime).HasColumnName(nameof(Tenant.CreationTime));
                b.ConfigureByConvention();
            });

            
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
            //b.Property<Guid?>(nameof(AppUser.MerchantId));
            //b.HasOne<Merchant>().WithMany().HasForeignKey(nameof(AppUser.MerchantId));
        }
    }
}