namespace TestAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentCourseRowId = c.Int(nullable: false, identity: true),
                        StudentRowId = c.Int(nullable: false),
                        CourseRowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseRowId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentCourses");
        }
    }
}
