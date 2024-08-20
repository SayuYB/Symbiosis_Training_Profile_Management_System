using System.ComponentModel.DataAnnotations;

namespace PlacementDemo.Models
{
    public class LinkedIn
    {
        [Key]
        public int LinkID { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ProfilePicturePath { get; set; } //will store image file path

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        public string PhoneNumber { get; set; }

        public string Headline { get; set; }
        public string Summary { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime? EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public string JobResponsibilities { get; set; }
        public string Degree { get; set; }
        public string InstitutionName { get; set; }
        public DateTime? GraduationDate { get; set; }
        public string Skills { get; set; }
        public string Certifications { get; set; }
        public string Projects { get; set; }
        public string Languages { get; set; }
        public string Awards { get; set; }
        public string VolunteerExperience { get; set; }
        public string ProfessionalAffiliations { get; set; }
        public string Interests { get; set; }
    }
}

