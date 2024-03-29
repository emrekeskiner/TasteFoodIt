﻿namespace TasteFoodIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_MailBox_Table : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Mailboxes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mailboxes",
                c => new
                    {
                        MailboxId = c.Int(nullable: false, identity: true),
                        To = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailboxId);
            
        }
    }
}
