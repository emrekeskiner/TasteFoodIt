namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_NotificationEntity_colums_color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "IconCircleColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "IconCircleColor");
        }
    }
}
