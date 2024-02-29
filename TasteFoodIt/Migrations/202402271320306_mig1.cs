namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Locale", c => c.String());
            DropColumn("dbo.Addresses", "LocalAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "LocalAddress", c => c.String());
            DropColumn("dbo.Addresses", "Locale");
        }
    }
}
