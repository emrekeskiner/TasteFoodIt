namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_procedure : DbMigration
    {
        public override void Up()
        {
            
            Sql("Create Procedure sp_ReservationCountByDate as "+
"select Format(ReservationDate, 'MMMM ,yyyy', 'tr-tr') as Tarih,"+
 "sum(GuestCount) as ToplamKisi from Reservations group by ReservationDate ");

        }
        
        public override void Down()
        {
            DropStoredProcedure("sp_ReservationCountByDate");
        }
    }
}
