namespace ProjectBurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adEntity_subscribe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        SubscribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.SubscribeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribes");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Addresses");
        }
    }
}
