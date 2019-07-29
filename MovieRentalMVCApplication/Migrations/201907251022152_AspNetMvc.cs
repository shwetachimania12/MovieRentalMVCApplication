namespace MovieRentalMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetMvc : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf17cd08-dcb6-4c1b-8060-7d0273fef46e', N'admin," +
                "INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01bc91f0-4ce0-42cd-bff7-6987777daa5d', N'bf17cd08-dcb6-4c1b-8060-7d0273fef46e, " +
                "INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'01bc91f0-4ce0-42cd-bff7-6987777daa5d', N'admin@gmail.com', 0, N'AF1jix5YfpCesBRWy95LJJoyYffbn3cpTTHf1SuIYb5JPy2hG9pnUrnv30EMtB6G2Q==', N'388855de-77c6-49a9-8604-3eb51b840524', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com ");





        }

        public override void Down()
        {
        }
    }
}
