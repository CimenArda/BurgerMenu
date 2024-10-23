namespace ProjectBurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddproperty_gallery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "ImageUrl2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Galleries", "ImageUrl2");
        }
    }
}
