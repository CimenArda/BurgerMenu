namespace ProjectBurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentityBanner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.BannerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Banners");
        }
    }
}
