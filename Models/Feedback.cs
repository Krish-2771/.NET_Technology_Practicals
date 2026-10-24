using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P7_Student_Feedback.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Enrollment No is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Enrollment No must be greater than 0.")]
        public int EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters.")]
        public string Comments { get; set; }
    }
}