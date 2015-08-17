namespace Jeopardy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoubleJeopardyQuestions", "Answer", c => c.String(nullable: false));
            AddColumn("dbo.FinalJeopardyQuestions", "Answer", c => c.String(nullable: false));
            AddColumn("dbo.JeopardyQuestions", "Answer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JeopardyQuestions", "Answer");
            DropColumn("dbo.FinalJeopardyQuestions", "Answer");
            DropColumn("dbo.DoubleJeopardyQuestions", "Answer");
        }
    }
}
