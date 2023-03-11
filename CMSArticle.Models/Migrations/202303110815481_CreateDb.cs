namespace CMSArticle.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.T_Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.T_Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.T_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.T_Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Family = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Posts", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Posts", "CategoryId", "dbo.T_Categories");
            DropIndex("dbo.T_Posts", new[] { "UserId" });
            DropIndex("dbo.T_Posts", new[] { "CategoryId" });
            DropTable("dbo.T_Users");
            DropTable("dbo.T_Posts");
            DropTable("dbo.T_Categories");
        }
    }
}
