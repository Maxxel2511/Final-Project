using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Thinh_Ecom.Configurations;
using Thinh_Ecom.Data.DataSeeding;
using Thinh_Ecom.Entities;
using Thinh_Ecom.EntitiesThinh_Ecom.Entities;
using Thinh_Ecom.Models;

namespace Thinh_Ecom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder
                // .AddFilter (DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                // .AddFilter (DbLoggerCategory.Query.Name, LogLevel.Debug)
                .AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //// Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            //// tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            //// Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }



            builder.ApplyConfiguration(new AboutConfigurations());
            builder.ApplyConfiguration(new AppRoleConfigurations());
            builder.ApplyConfiguration(new AppUserConfigurations());
            builder.ApplyConfiguration(new BillConfigurations());
            builder.ApplyConfiguration(new CartConfigurations());
            builder.ApplyConfiguration(new CategoriesConfigurations());
            builder.ApplyConfiguration(new SystemContactConfigurations());
            builder.ApplyConfiguration(new ContactFormConfigurations());
            builder.ApplyConfiguration(new ProductInCartConfigurations());
            builder.ApplyConfiguration(new ProductsConfigurations());
            builder.ApplyConfiguration(new CouponsConfigurations());
            builder.ApplyConfiguration(new ShippingConfigurations());
            builder.ApplyConfiguration(new EmailGuestConfigurations());
            builder.ApplyConfiguration(new PriceForSizeConfigurations());







            //builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            //builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x => new { x.UserId, x.RoleId });
            //builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            //builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppUserRoleClaims");
            //builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);




            builder.Seed();


        }
        //table
        public DbSet<About> About { set; get; }
        public DbSet<AppRole> AppRole { set; get; }
        public DbSet<AppUser> AppUser { set; get; }
        public DbSet<Bills> Bills { set; get; }
        public DbSet<Categories> Categories { set; get; }
        public DbSet<SystemContact> SystemContact { set; get; }
        public DbSet<ContactForm> ContactForm { set; get; }
        public DbSet<Products> Products { set; get; }
        public DbSet<ProductInCart> ProductInCart { set; get; }
        public DbSet<Cart> Cart { set; get; }
        public DbSet<Coupons> Coupons { set; get; }
        public DbSet<Shipping> Shipping { set; get; }
        public DbSet<EmailGuest> EmailGuest { set; get; }
        public DbSet<PriceForSize> PriceForSize { set; get; }
        public DbSet<Thinh_Ecom.Models.PaymentManagement> PaymentManagement { get; set; }


    }
}
