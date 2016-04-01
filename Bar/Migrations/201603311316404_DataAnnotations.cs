namespace Bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Products", "Type", c => c.String(maxLength: 256));
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Recipes", "Description", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Taras", "Type", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Qualification", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Qualification", c => c.String());
            AlterColumn("dbo.Taras", "Type", c => c.String());
            AlterColumn("dbo.Recipes", "Description", c => c.String());
            AlterColumn("dbo.Recipes", "Name", c => c.String());
            AlterColumn("dbo.Products", "Type", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
