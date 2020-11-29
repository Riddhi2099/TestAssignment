namespace TestAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseRowId = c.Int(nullable: false, identity: true),
                        CourseId = c.String(nullable: false, maxLength: 50),
                        CourseName = c.String(nullable: false, maxLength: 50),
                        CourseTrainer = c.String(nullable: false, maxLength: 50),
                        NoOfModules = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                        Trainer_TrainerRowId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseRowId)
                .ForeignKey("dbo.Trainers", t => t.Trainer_TrainerRowId)
                .Index(t => t.Trainer_TrainerRowId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerRowId = c.Int(nullable: false, identity: true),
                        TrainerId = c.String(nullable: false, maxLength: 50),
                        TrainerName = c.String(nullable: false, maxLength: 50),
                        Expertise = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TrainerRowId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentRowId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false, maxLength: 50),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        AreaOfInterest = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(),
                        MobileNo = c.String(nullable: false),
                        SelectedCourse = c.String(nullable: false, maxLength: 50),
                        CourseCompleted = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StudentRowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Trainer_TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "Trainer_TrainerRowId" });
            DropTable("dbo.Students");
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
