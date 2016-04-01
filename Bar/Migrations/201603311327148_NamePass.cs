namespace Bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamePass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.Users", "Password", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Name");
        }
    }
}
