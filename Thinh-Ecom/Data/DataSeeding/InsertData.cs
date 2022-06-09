using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thinh_Ecom.Entities;
using Thinh_Ecom.EntitiesThinh_Ecom.Entities;

namespace Thinh_Ecom.Data.DataSeeding
{
    public static class InsertData
    {
        public static void Seed(this ModelBuilder builder)
        {
            //Table Categories

            var categoriesId1 = Guid.NewGuid().ToString();
            var categoriesId2 = Guid.NewGuid().ToString();
            var categoriesId3 = Guid.NewGuid().ToString();
            var categoriesId4 = Guid.NewGuid().ToString();



            builder.Entity<Categories>().HasData(
                new Categories()
                {
                    cg_Id = categoriesId1,
                    cg_Name = "Pizza",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = categoriesId2,
                    cg_Name = "Spaghetti",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = categoriesId3,
                    cg_Name = "Sidedishes",
                    cg_Type = "",
                    cg_Sale = ""

                },
                new Categories()
                {
                    cg_Id = categoriesId4,
                    cg_Name = "Drink",
                    cg_Type = "",
                    cg_Sale = ""

                });

            //var hasher = new PasswordHasher<AppUsers>();

            var productId1 = Guid.NewGuid().ToString();
            var productId2 = Guid.NewGuid().ToString();
            var productId3 = Guid.NewGuid().ToString();
            var productId4 = Guid.NewGuid().ToString();
            var productId5 = Guid.NewGuid().ToString();
            var productId6 = Guid.NewGuid().ToString();
            var productId7 = Guid.NewGuid().ToString();
            var productId8 = Guid.NewGuid().ToString();
            var productId9 = Guid.NewGuid().ToString();
            var productId10 = Guid.NewGuid().ToString();
            var productId11 = Guid.NewGuid().ToString();
            var productId12 = Guid.NewGuid().ToString();
            var productId13 = Guid.NewGuid().ToString();
            var productId14 = Guid.NewGuid().ToString();


            //Table Products
            builder.Entity<Products>().HasData(
                new Products()
                {
                    pd_Id = productId1,
                    pd_Name = "Extravaganza",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Extravaganza.png",
                    pd_ShortDescription = "Tomato Sauce, Mozzarella Cheese, Pepperoni Sausage, Ham, Sausage, Beef Balls, Green Bell Peppers, Mushrooms, Onions, Olives",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId2,
                    pd_Name = "Haft-haft",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Haft-haft.png",
                    pd_ShortDescription = "It is a topping combination of Ocean Mania pizza and Cheesy Chicken Bacon pizza",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId3,
                    pd_Name = "Hawaiian",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Hawaiian.png",
                    pd_ShortDescription = "Tomato Sauce, Mozzarella Cheese, Ham, Pineapple",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId4,
                    pd_Name = "Kid-mania",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Kid-mania.png",
                    pd_ShortDescription = "Cheese Sauce, Mozzarella Cheese, Pickled Pork, Corn, Quail Egg",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId5,
                    pd_Name = "Meat-lover",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Meat-lover.png",
                    pd_ShortDescription = "Tomato Sauce, Mozzarella Cheese, Pepperoni Sausage, Ham, Sausage, Beef Balls, Bacon",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId6,
                    pd_Name = "Cheese-mania",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Cheese-mania.png",
                    pd_ShortDescription = "Tomato Sauce, Mozzarella Cheese",
                    pd_Size = "",
                    CategoriesFK = categoriesId1
                },
                new Products()
                {
                    pd_Id = productId7,
                    pd_Name = "Baked Bolognese Pasta",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Baked Bolognese Pasta.png",
                    pd_ShortDescription = "Sauce Minced Beef Noodles, Mozzarella Cheese",
                    pd_Size = "",
                    CategoriesFK = categoriesId2
                },
                new Products()
                {
                    pd_Id = productId8,
                    pd_Name = "Baked Seafood Pasta",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Baked Seafood Pasta.png",
                    pd_ShortDescription = "Light spicy noodle sauce, shrimp, crab stick, squid, Mozzarella cheese",
                    pd_Size = "",
                    CategoriesFK = categoriesId2
                },
                new Products()
                {
                    pd_Id = productId9,
                    pd_Name = "Baked Veggie Pasta",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Baked Veggie Pasta.png",
                    pd_ShortDescription = "Sauce lightly spicy noodles, mushroom, green bell pepper, tomato, pineapple, black olive, mozzarella cheese.",
                    pd_Size = "",
                    CategoriesFK = categoriesId2
                },
                new Products()
                {
                    pd_Id = productId10,
                    pd_Name = "BBQ-Chicken-Kickers",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/BBQ-Chicken-Kickers.png",
                    pd_ShortDescription = "Breaded Boneless Chicken served with delicious BBQ sauce.",
                    pd_Size = "",
                    CategoriesFK = categoriesId3
                },
                new Products()
                {
                    pd_Id = productId11,
                    pd_Name = "Cheesy-backed-chicken",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Cheesy-backed-chicken.png",
                    pd_ShortDescription = "Breaded chicken with fatty cheese, topped with bacon and served with BBQ sauce.",
                    pd_Size = "",
                    CategoriesFK = categoriesId3
                },
                new Products()
                {
                    pd_Id = productId12,
                    pd_Name = "Coke",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Coke.png",
                    pd_ShortDescription = "Natural flavor",
                    pd_Size = "",
                    CategoriesFK = categoriesId4
                },
                new Products()
                {
                    pd_Id = productId13,
                    pd_Name = "Coke-light",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Coke-light.png",
                    pd_ShortDescription = "No sugar, for dieters",
                    pd_Size = "",
                    CategoriesFK = categoriesId4
                },
                new Products()
                {
                    pd_Id = productId14,
                    pd_Name = "Peach-tea",
                    pd_Description = "",
                    pd_Price = 10,
                    pd_ReducePrice = 5,
                    pd_Img1 = "/img/pizza/Peach-tea.png",
                    pd_ShortDescription = "It is a combination of the freshest green tea leaves and nutritious aromatic chia seeds, combined with the seductive sweet peach flavor to help boost energy.",
                    pd_Size = "",
                    CategoriesFK = categoriesId4
                }
                );




            //Table About
            builder.Entity<About>().HasData(
                new About()
                {
                    about_id=1,
                    about_Url= "https://www.youtube.com/watch?v=F1vcruph8JA",
                    about_Title = "Footwear the leading eCommerce Store around the Globe",
                    about_Description = "The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. \n \n When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove,the headline of Alphabet Village and the subline of her own road,the Line Lane.Pityful a rethoric question ran over her cheek,then she continued her way."
                });

            var IdRoleStaff = "f49e4348-718f-43e3-b1f6-6dc89c5Bb4fd";
            var IdRoleAdmin = "360E601E-92F2-4F08-832B-604A21293258";



            //Table AppRole 2222222222222222222222222222222222222222222222222222222222222222222

            builder.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = IdRoleStaff,
                    Name ="Staff",
                    Description = "Staff",
                    NormalizedName = "Staff"
                },
                new AppRole()
                {
                    Id = IdRoleAdmin,
                    Name = "Admin",
                    Description = "admin",
                    NormalizedName = "Admin"
                });


            var IdStaff = "f49e4348-718f-43e3-b1f6-6dc89c5Bb5ff";
            var IdAdmin = "DE544998-A3CC-4E12-ABB4-0642E57BD222";

            //Table AppUser 2222222222222222222222222222222222222222222222222222222222222222222

            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(
            new AppUser
            {
                Id = IdAdmin,
                UserName = "Admin",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456Aa@"),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "admin",
                LastName = "admin",
                DoB = new DateTime(2020, 01, 02)

            },
            new AppUser
            {
                Id = IdStaff,
                UserName = "Staff",
                NormalizedUserName = "STAFF@GMAIL.COM",
                NormalizedEmail = "STAFF@GMAIL.COM",
                Email = "staff@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456Aa@"),
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "staff",
                LastName = "staff",
                DoB = new DateTime(2020, 03, 02)

            });


            //Table AppUser - role 2222222222222222222222222222222222222222222222222222222222222222222
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = IdRoleStaff,
                UserId = IdStaff
            },
            new IdentityUserRole<string>
            {
                RoleId = IdRoleAdmin,
                UserId = IdAdmin
            });





            var IdCart1 = "72309286-ECBB-4D20-AD95-2819D31E3400";
            var IdCart2 = "D355458F-1DD3-4834-AA28-6DA34B6357FF";


            //Table Cart

            builder.Entity<Cart>().HasData(
                new Cart()
                {
                    cart_Id = IdCart1,
                    cart_UserID = IdStaff

                },
                new Cart()
                {
                    cart_Id = IdCart2,
                    cart_UserID = IdAdmin

                });


            //Table Product In Cart

            builder.Entity<ProductInCart>().HasData(
                new ProductInCart()
                {
                     pic_CartId = IdCart2,
                     pic_ProductId = productId1,
                     pic_amount = 2
                });


           





            //Table ContactSystem

            builder.Entity<SystemContact>().HasData(
                new SystemContact()
                {
                    Contact_Id = 1,
                    Contact_Address = " 123, An Lac A Ward, Binh Tan District, HCM",
                    Contact_Phone = "0123456789",
                    Contact_Email = "admin@gmail.com",
                    Contact_Website = "https://shoes.com"


                });



            //Table ContactUsers
            var contactFormId1 = Guid.NewGuid().ToString();

            builder.Entity<ContactForm>().HasData(
                new ContactForm()
                {
                    cf_Id = contactFormId1,
                    cf_Name = "Name",
                    cf_Phone = 0123456789,
                    cf_Email = "Email",
                    cf_Subject = "Subject",
                    cf_Description = "Description"
                });







           

            builder.Entity<Coupons>().HasData(
                new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode ="code10",
                    couponPrice = 10
                },
                new Coupons()
                {
                    couponId = Guid.NewGuid().ToString(),
                    couponCode = "code50",
                    couponPrice = 50
                });



            string billId1 = "D269BF93-A5E2-4C4A-8146-9967DDE80D30";

            //Table Bills

            builder.Entity<Bills>().HasData(
                new Bills()
                {
                    bill_Id = billId1,
                    bill_UserId = IdStaff,
                    bill_PaidTotal = 2000,
                    bill_ProductIdlist = ""+ productId1 + "|"+ productId2 + "|"+ productId3 + "|"+ productId4 + "|",
                    bill_ProductNamelist = "product 1|product 2| product 3| product 4|",
                    bill_ProductSizelist = "7|8|9|14|",
                    bill_ProductPricelist = "550|450|350|640|",
                    bill_Shipping = 10,
                    bill_Discount = 0,
                    bill_Confirmation = true,
                    bill_DatetimeOrder = DateTime.Now,
                    bill_PaymentMethod = "Check Payment",
                    bill_Note = "",
                    bill_QuantityList = "1|1|2|1|",
                    bill_HideStatus = false,
                    bill_WaitForConfirmation = false,
                }); ;

            //Table Shiping

            string shipId = "7CF94A7D-9239-446E-A404-086518F84652";

            builder.Entity<Shipping>().HasData(
                new Shipping()
                {
                    ship_Id = shipId,
                    ship_Name ="Ship",
                    ship_Price = 5
                });

            //Table Price for size

            string PriceForSizeId1 = Guid.NewGuid().ToString();
            string PriceForSizeId2 = Guid.NewGuid().ToString();

            builder.Entity<PriceForSize>().HasData(
                new PriceForSize()
                {
                    Id = PriceForSizeId1,
                    SizeName = "M",
                    Price = 10
                },
                new PriceForSize()
                {
                    Id = PriceForSizeId2,
                    SizeName = "L",
                    Price = 15
                });


        }    
                
               
    }   
}
