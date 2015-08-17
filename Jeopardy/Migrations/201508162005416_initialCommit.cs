namespace Jeopardy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.DoubleJeopardyQuestions",
                c => new
                    {
                        DoubleJeopardyQuestionId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoubleJeopardyQuestionId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.FinalJeopardyQuestions",
                c => new
                    {
                        FinalJeopardyQuestionId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinalJeopardyQuestionId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.JeopardyQuestions",
                c => new
                    {
                        JeopardyQuestionId = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        Value = c.Int(nullable: false),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JeopardyQuestionId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JeopardyQuestions", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.FinalJeopardyQuestions", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.DoubleJeopardyQuestions", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.JeopardyQuestions", new[] { "Category_CategoryId" });
            DropIndex("dbo.FinalJeopardyQuestions", new[] { "Category_CategoryId" });
            DropIndex("dbo.DoubleJeopardyQuestions", new[] { "Category_CategoryId" });
            DropTable("dbo.JeopardyQuestions");
            DropTable("dbo.FinalJeopardyQuestions");
            DropTable("dbo.DoubleJeopardyQuestions");
            DropTable("dbo.Categories");
        }
    }
}
