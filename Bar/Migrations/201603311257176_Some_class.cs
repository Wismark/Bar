namespace Bar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Some_class : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Prod_ProductId = c.Int(),
                        Recipe_RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Products", t => t.Prod_ProductId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId)
                .Index(t => t.Prod_ProductId)
                .Index(t => t.Recipe_RecipeId);
            
            CreateTable(
                "dbo.Taras",
                c => new
                    {
                        TaraId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        ReUse_time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TaraId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Salary = c.Double(nullable: false),
                        Tip = c.Double(nullable: false),
                        Qualification = c.String(),
                        AccessToTheWarehouse = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Ingredients", "Prod_ProductId", "dbo.Products");
            DropIndex("dbo.Ingredients", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.Ingredients", new[] { "Prod_ProductId" });
            DropTable("dbo.Users");
            DropTable("dbo.Taras");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Products");
        }
    }
}
