namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation_colums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "GuestCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "GuestCount", c => c.String());
        }
    }
}
