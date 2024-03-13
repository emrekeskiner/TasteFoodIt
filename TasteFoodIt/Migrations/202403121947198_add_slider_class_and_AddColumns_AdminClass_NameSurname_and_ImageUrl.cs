namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_slider_class_and_AddColumns_AdminClass_NameSurname_and_ImageUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Slogan = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.SliderId);
            
            AddColumn("dbo.Admins", "NameSurname", c => c.String());
            AddColumn("dbo.Admins", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ImageUrl");
            DropColumn("dbo.Admins", "NameSurname");
            DropTable("dbo.Sliders");
        }
    }
}
