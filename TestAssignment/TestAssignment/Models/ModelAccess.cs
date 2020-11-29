using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestAssignment.Models
{
    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }

        [Required(ErrorMessage = "CourseId is Must")]
        [StringLength(50, ErrorMessage = "CourseId can be 50 characters max")]
        public string CourseId { get; set; }

        [Required(ErrorMessage = "CourseName is Must")]
        [StringLength(50, ErrorMessage = "Course Name can be 50 characters max")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "CourseTrainer Name is Must")]
        [StringLength(50, ErrorMessage = "CourseTrainer Name can be 50 characters max")]
        public string CourseTrainer { get; set; }



        [Required(ErrorMessage = "NoOfModules is Must")]
        public int NoOfModules { get; set; }

        [Required(ErrorMessage = "Price is Must")]
        public int Price { get; set; }
        [Required(ErrorMessage = "TrainerId is Must")]
        public int TrainerRowId { get; set; }



        public virtual Trainer Trainer { get; set; }
        

    }

    public class Student
    {


        [Key]
        public int StudentRowId { get; set; }

        [Required(ErrorMessage = "StudentId is Must")]
        [StringLength(50, ErrorMessage = "StudentId can be 50 characters max")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "StudentNameis Must")]
        [StringLength(50, ErrorMessage = "StudentName can be 50 characters max")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email is Must")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address  is Must")]
        [StringLength(50, ErrorMessage = "Address can be 50 characters max")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City  is Must")]
        [StringLength(50, ErrorMessage = "City can be 50 characters max")]
        public string City { get; set; }

        [Required(ErrorMessage = "AreaOfInterest is Must")]
        [StringLength(50, ErrorMessage = "AreaOfInterest can be 50 characters max")]
        public string AreaOfInterest { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "MobileNo")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "SelectedCourse  is Must")]
        [StringLength(50, ErrorMessage = "SelectedCourse can be 50 characters max")]
        public string SelectedCourse { get; set; }

        [Required(ErrorMessage = "CourseCompleted  is Must")]
        [StringLength(50, ErrorMessage = "CourseCompleted can be 50 characters max")]
        public string CourseCompleted { get; set; }

    }

    public class Trainer
    {
        [Key]
        public int TrainerRowId { get; set; }

        [Required(ErrorMessage = "TrainerId is Must")]
        [StringLength(50, ErrorMessage = "TrainerId can be 50 characters max")]
        public string TrainerId { get; set; }

        [Required(ErrorMessage = "Trainer Name is Must")]
        [StringLength(50, ErrorMessage = "Trainer Name can be 50 characters max")]
        public string TrainerName { get; set; }

        [Required(ErrorMessage = "Expertise is Must")]
        [StringLength(50, ErrorMessage = "Expertise can be 50 characters max")]
        public string Expertise { get; set; }



        public virtual ICollection<Course> Course { get; set; }
    }

    public class StudentCourse
    {
        [Key]
        public int StudentCourseRowId { get; set; }
        public int StudentRowId { get; set; }

        public int CourseRowId { get; set; }


    }
}