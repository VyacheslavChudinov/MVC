namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Languages", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Posts", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Posts", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.Posts", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "Content", c => c.String());
            AlterColumn("dbo.Posts", "Name", c => c.String());
            AlterColumn("dbo.Languages", "Name", c => c.String());
        }
    }
}
