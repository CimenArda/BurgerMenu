namespace ProjectBurgerMenu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentity_reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        PersonCount = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        Time = c.String(),
                        Message = c.String(),
                        ReservationStatus = c.String(),
                    })
                .PrimaryKey(t => t.ReservationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservations");
        }
    }
}
