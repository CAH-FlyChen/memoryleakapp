using B2BAgent.Server.Domains;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace MemoryLeakTest.EntityFrameworkCore
{
    public static class MemoryLeakTestDbContextModelCreatingExtensions
    {
        public static void ConfigureMemoryLeakTest(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MemoryLeakTestConsts.DbTablePrefix + "YourEntities", MemoryLeakTestConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<ERPBrand>(b => {
                b.ToTable("biz_erp_brand");
                b.Property(t => t.Name).HasMaxLength(50);
            });
        }
    }
}