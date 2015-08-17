namespace Jeopardy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCategoryIdToQuestionModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DoubleJeopardyQuestions", name: "Category_CategoryId", newName: "CategoryId");
            RenameColumn(table: "dbo.FinalJeopardyQuestions", name: "Category_CategoryId", newName: "CategoryId");
            RenameColumn(table: "dbo.JeopardyQuestions", name: "Category_CategoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.DoubleJeopardyQuestions", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.FinalJeopardyQuestions", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.JeopardyQuestions", name: "IX_Category_CategoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JeopardyQuestions", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameIndex(table: "dbo.FinalJeopardyQuestions", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameIndex(table: "dbo.DoubleJeopardyQuestions", name: "IX_CategoryId", newName: "IX_Category_CategoryId");
            RenameColumn(table: "dbo.JeopardyQuestions", name: "CategoryId", newName: "Category_CategoryId");
            RenameColumn(table: "dbo.FinalJeopardyQuestions", name: "CategoryId", newName: "Category_CategoryId");
            RenameColumn(table: "dbo.DoubleJeopardyQuestions", name: "CategoryId", newName: "Category_CategoryId");
        }
    }
}
