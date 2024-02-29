namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameRezervation_Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        ReservationDate = c.DateTime(nullable: false),
                        time = c.String(),
                        GuestCount = c.String(),
                        ReservationStatus = c.String(),
                    })
                .PrimaryKey(t => t.ReservationId);
            
            DropTable("dbo.Rezervations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rezervations",
                c => new
                    {
                        RezervationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        RezervationDate = c.DateTime(nullable: false),
                        time = c.String(),
                        GuestCount = c.String(),
                        RezervationStatus = c.String(),
                    })
                .PrimaryKey(t => t.RezervationId);
            
            DropTable("dbo.Reservations");
        }
    }
}
