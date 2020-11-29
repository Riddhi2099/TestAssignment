namespace TestAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TCigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerCourses", "Trainer_TrainerRowId", "dbo.Trainers");
            DropForeignKey("dbo.TrainerCourses", "Course_CourseRowId", "dbo.Courses");
            DropIndex("dbo.TrainerCourses", new[] { "Trainer_TrainerRowId" });
            DropIndex("dbo.TrainerCourses", new[] { "Course_CourseRowId" });
            CreateIndex("dbo.Courses", "TrainerRowId");
            AddForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers", "TrainerRowId", cascadeDelete: true);
            DropTable("dbo.TrainerCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrainerCourses",
                c => new
                    {
                        Trainer_TrainerRowId = c.Int(nullable: false),
                        Course_CourseRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Trainer_TrainerRowId, t.Course_CourseRowId });
            
            DropForeignKey("dbo.Courses", "TrainerRowId", "dbo.Trainers");
            DropIndex("dbo.Courses", new[] { "TrainerRowId" });
            CreateIndex("dbo.TrainerCourses", "Course_CourseRowId");
            CreateIndex("dbo.TrainerCourses", "Trainer_TrainerRowId");
            AddForeignKey("dbo.TrainerCourses", "Course_CourseRowId", "dbo.Courses", "CourseRowId", cascadeDelete: true);
            AddForeignKey("dbo.TrainerCourses", "Trainer_TrainerRowId", "dbo.Trainers", "TrainerRowId", cascadeDelete: true);
        }
    }
}
