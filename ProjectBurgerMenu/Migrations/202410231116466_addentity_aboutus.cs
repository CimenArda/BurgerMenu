namespace ProjectBurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentity_aboutus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutUs",
                c => new
                    {
                        AboutUsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.AboutUsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutUs");
        }
    }
}
