namespace EnterpriseProgrammingAssignment.Migrations
{
    using EnterpriseProgrammingAssignment.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EnterpriseProgrammingAssignment.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EnterpriseProgrammingAssignment.Models.NewDbContext";
        }

        protected override void Seed(EnterpriseProgrammingAssignment.Models.ApplicationDbContext context)
        {
            /*List<Categories> category = new List<Categories>();
            category.Add(new Categories { CategoryName = "Computer and Office" });
            category.Add(new Categories { CategoryName = "Vehicles" });
            category.Add(new Categories { CategoryName = "Electronics" });
            category.Add(new Categories { CategoryName = "Sports" });
            category.Add(new Categories { CategoryName = "Furniture" });
            context.categories.AddRange(category);

            List<Quality> quality = new List<Quality>();
            quality.Add(new Quality { QualityType = "Poor" });
            quality.Add(new Quality { QualityType = "Bad" });
            quality.Add(new Quality { QualityType = "Good" });
            quality.Add(new Quality { QualityType = "Excellent" });
            context.qualities.AddRange(quality);
            context.SaveChanges();

            using (RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
            {

                if (!roleManager.RoleExists("User"))
                {
                    IdentityRole role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "User";
                    roleManager.Create(role);
                }
            }

            List<ApplicationUser> users = new List<ApplicationUser>();
            using (UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            {
                ApplicationUser userSeed = new ApplicationUser() { Email = "abc@gmail.com", UserName = "abc@gmail.com" };
                context.Users.Add(userSeed);
                userManager.Create(userSeed, "TestPa$5");
                userManager.AddToRole(userSeed.Id, "user");
                ApplicationUser userSeed1 = new ApplicationUser() { Email = "def@gmail.com", UserName = "def@gmail.com" };
                context.Users.Add(userSeed1);
                userManager.Create(userSeed1, "TestPa$5");
                userManager.AddToRole(userSeed1.Id, "user");
                ApplicationUser userSeed2 = new ApplicationUser() { Email = "ghi@gmail.com", UserName = "ghi@gmail.com" };
                context.Users.Add(userSeed2);
                userManager.Create(userSeed2, "TestPa$5");
                userManager.AddToRole(userSeed2.Id, "user");
                ApplicationUser userSeed3 = new ApplicationUser() { Email = "jkl@gmail.com", UserName = "jkl@gmail.com" };
                context.Users.Add(userSeed3);
                userManager.Create(userSeed3, "TestPa$5");
                userManager.AddToRole(userSeed3.Id, "user");
                ApplicationUser userSeed4 = new ApplicationUser() { Email = "mno@gmail.com", UserName = "mno@gmail.com" };
                context.Users.Add(userSeed4);
                userManager.Create(userSeed4, "TestPa$5");
                userManager.AddToRole(userSeed4.Id, "user");
                ApplicationUser userSeed5 = new ApplicationUser() { Email = "pqr@gmail.com", UserName = "pqr@gmail.com" };
                context.Users.Add(userSeed5);
                userManager.Create(userSeed5, "TestPa$5");
                userManager.AddToRole(userSeed5.Id, "user");
            }
            context.SaveChanges();

            List<ItemTypes> itemTypes = new List<ItemTypes>();
            itemTypes.Add((new ItemTypes { Category_Id = 1, ItemName = "Biro", ImageUrl= "https://www.dropbox.com/s/svb6kavbgwoiljl/biro632f5e4219d14448be369beaf0d1f106.jpg?dl=1"}));
            itemTypes.Add((new ItemTypes { Category_Id = 1, ItemName = "File", ImageUrl = "https://www.dropbox.com/s/ypcrrhrvmmqgziw/filee0616702929741ffbea8bce6356c84dc.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 1, ItemName = "Paper", ImageUrl = "https://www.dropbox.com/s/aix9ifryyfwj29y/paperaece00f6793f4d96ad5103dcfe761906.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 1, ItemName = "Rubber", ImageUrl = "https://www.dropbox.com/s/g7b6rf9em9hr2k9/rubbere4d8ba49f39844afbb3856f6dbaed7ed.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 1, ItemName = "Paper Clip", ImageUrl = "https://www.dropbox.com/s/jxaauotekimy4g5/paperclipad35bacd7a6043a39eeb8a55d34a21bc.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 2, ItemName = "4x4", ImageUrl = "https://www.dropbox.com/s/8ju00gg2tbq82tw/4x45e25e27fb4de4b8b93a1211776741d65.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 2, ItemName = "Honda ", ImageUrl = "https://www.dropbox.com/s/soueeaklo26gp83/honda5aeb5d1fcff14b28bc758622e21a6028.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 2, ItemName = "Saloon ", ImageUrl = "https://www.dropbox.com/s/gi5fax7w7c87p0e/car4b34e3d8a4064b37a272c1c08a0f5df9.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 2, ItemName = "Mustang ", ImageUrl = "https://www.dropbox.com/s/1nzk8tcvslso8kg/mustang027c26e775bb4898b1874b1aa255fd97.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 2, ItemName = "Toyota ", ImageUrl = "https://www.dropbox.com/s/o42f3cuqwvitzd9/toyota13aa5c7cdebb4f3dad5d9b6342fe90ee.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 3, ItemName = "Electric Lighter ", ImageUrl = "https://www.dropbox.com/s/z56r2d0cu9sr6pq/lighter982ad61642344339b9f2982145aacd7c.png?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 3, ItemName = "Mobile ", ImageUrl = "https://www.dropbox.com/s/rhauz43dafvf3j3/mobilef93cba7b75c44312a5c31c15dfcbf1d0.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 3, ItemName = "Laptop ", ImageUrl = "https://www.dropbox.com/s/dv9f0z2p1okcc7u/laptopc506ab25e3d046559e462ba315e792f2.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 3, ItemName = "Remote ", ImageUrl = "https://www.dropbox.com/s/s8cw098zmiv5bmk/remote83d0655dd10644b4a4edd7750c31b2a0.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 3, ItemName = "TV ", ImageUrl = "https://www.dropbox.com/s/k0p29yv4ttz3wah/tv74ff3fc2c2b54173989aafbaf6e63b0b.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 4, ItemName = "Football ", ImageUrl = "https://www.dropbox.com/s/7qgqnfrmsmtwinv/ballb759e12ae34e45c3b0271ee1c37c43da.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 4, ItemName = "Basketball ", ImageUrl = "https://www.dropbox.com/s/np2k3hmfgw9h63j/basketballb217aaf3cd664b2bb54af0f87753b1eb.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 4, ItemName = "Rugby ", ImageUrl = "https://www.dropbox.com/s/szgb5ezyo3adshr/rugby%20ball5bd48ad111ad4079aada1efcdae686d8.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 4, ItemName = "Tennis ", ImageUrl = "https://www.dropbox.com/s/9dc65kxac3vm87t/tennis%20racket0ec98333210f4b6bb2a581f0b35ed038.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 4, ItemName = "Fishing ", ImageUrl = "https://www.dropbox.com/s/micpyfhsp5poyid/fishingc1c19d31596c4a41bc19317083f6304b.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 5, ItemName = "Chair ", ImageUrl = "https://www.dropbox.com/s/8sv6p8c1c9d1a3t/chair7ddfe98b129340b09bf1cdb75318bf7f.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 5, ItemName = "Table ", ImageUrl = "https://www.dropbox.com/s/27sxuqletgl46wl/table6251537803904dc890e317acebee59f0.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 5, ItemName = "Lampshade ", ImageUrl = "https://www.dropbox.com/s/qpzm3cde4866noh/lampshade6a4e55724d05456e8e44499e0611ccdf.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 5, ItemName = "Sofa ", ImageUrl = "https://www.dropbox.com/s/9b7vrbcip8ej3q3/sofa597a7d00bcf04b078972ed7ea1afab3c.jpg?dl=1" }));
            itemTypes.Add((new ItemTypes { Category_Id = 5, ItemName = "Stool ", ImageUrl = "https://www.dropbox.com/s/h9ylsqzkk211r52/stool9e759648b6764188aca3716f1f1603b9.webp?dl=1" }));
            context.itemTypes.AddRange(itemTypes);
            */
            List<ItemDetails> itemDetails = new List<ItemDetails>();

           // itemDetails.Add((new ItemDetails { ItemType_Id = 1, Quality_Id = 1, Quantity = 4, Price = 1.10M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555"}));
            //itemDetails.Add((new ItemDetails { ItemType_Id = 2, Quality_Id = 2, Quantity = 6, Price = 3.30M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 3, Quality_Id = 3, Quantity = 8, Price = 2.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 4, Quality_Id = 4, Quantity = 4, Price = 1.50M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 5, Quality_Id = 1, Quantity = 3, Price = 1.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 6, Quality_Id = 2, Quantity = 7, Price = 4500M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 7, Quality_Id = 3, Quantity = 9, Price = 2500M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 8, Quality_Id = 4, Quantity = 15, Price = 130000M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 9, Quality_Id = 1, Quantity = 8, Price = 60500M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 10, Quality_Id = 2, Quantity = 6, Price = 12000M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 11, Quality_Id = 3, Quantity = 2, Price = 3.5M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 12, Quality_Id = 4, Quantity = 7, Price = 250M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 13, Quality_Id = 1, Quantity = 13, Price = 600M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 14, Quality_Id = 2, Quantity = 16, Price = 12M, User_Id = "a78034e3-921e-46dc-8829-88df1256a69f" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 15, Quality_Id = 3, Quantity = 4, Price = 1500M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 16, Quality_Id = 4, Quantity = 9, Price = 4.00M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 17, Quality_Id = 1, Quantity = 26, Price = 3.20M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 18, Quality_Id = 2, Quantity = 9, Price = 8.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 19, Quality_Id = 3, Quantity = 10, Price = 5.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 20, Quality_Id = 4, Quantity = 16, Price = 3.20M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 21, Quality_Id = 1, Quantity = 5, Price = 16.30M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 22, Quality_Id = 2, Quantity = 23, Price = 80.20M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 23, Quality_Id = 3, Quantity = 7, Price = 45.30M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 24, Quality_Id = 4, Quantity = 19, Price = 63.21M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 25, Quality_Id = 1, Quantity = 17, Price = 24.60M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 1, Quality_Id = 4, Quantity = 4, Price = 1.30M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 2, Quality_Id = 3, Quantity = 6, Price = 4.30M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 3, Quality_Id = 2, Quantity = 8, Price = 2.50M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 4, Quality_Id = 1, Quantity = 4, Price = 3.50M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 5, Quality_Id = 4, Quantity = 3, Price = 2.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 6, Quality_Id = 3, Quantity = 7, Price = 3200M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 7, Quality_Id = 2, Quantity = 9, Price = 2000M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 8, Quality_Id = 1, Quantity = 15, Price = 110000M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 9, Quality_Id = 4, Quantity = 8, Price = 60000M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 10, Quality_Id = 3, Quantity = 6, Price = 11000M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 11, Quality_Id = 2, Quantity = 2, Price = 3.0M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 12, Quality_Id = 1, Quantity = 7, Price = 190M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 13, Quality_Id = 4, Quantity = 13, Price = 400M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 14, Quality_Id = 3, Quantity = 16, Price = 10M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 15, Quality_Id = 2, Quantity = 4, Price = 1300M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 16, Quality_Id = 1, Quantity = 9, Price = 3.00M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 17, Quality_Id = 4, Quantity = 26, Price = 3.00M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 18, Quality_Id = 3, Quantity = 9, Price = 5.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 19, Quality_Id = 2, Quantity = 10, Price = 4.00M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 20, Quality_Id = 1, Quantity = 16, Price = 2.20M, User_Id = "c3dd4add-3e3c-4390-9779-bf1d33124cbd" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 21, Quality_Id = 4, Quantity = 5, Price = 15M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 22, Quality_Id = 3, Quantity = 23, Price = 75.20M, User_Id = "0dd482c4-7086-417e-92c4-c1c4288e6555" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 23, Quality_Id = 2, Quantity = 7, Price = 50.30M, User_Id = "157621ee-c87c-4749-b997-3c3b12e9b718" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 24, Quality_Id = 1, Quantity = 19, Price = 60.21M, User_Id = "fee7378d-3d1f-4946-8c82-24614d60ee43" }));
            itemDetails.Add((new ItemDetails { ItemType_Id = 25, Quality_Id = 4, Quantity = 17, Price = 28.00M, User_Id = "5ee63f90-8f05-4d88-8ee9-b0674efd7b27" }));
            context.itemDetails.AddRange(itemDetails);
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}
