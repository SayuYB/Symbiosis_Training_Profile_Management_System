using Microsoft.AspNetCore.Mvc;
using PlacementDemo.Data;
using PlacementDemo.Models;
using PlacementDemo.Models.ViewModels;
using PlacementDemo.Services;


namespace PlacementDemo.Controllers
{
    public class LinkedInController : Controller
    {
        public IActionResult Index()
        {
            var data = _context.LinkedIns.ToList();
            return View(data);
        }

        //context, environment, services
        private readonly LinkedInContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IProfileAnalysisService _analysisService;

        public LinkedInController(LinkedInContext context, IWebHostEnvironment environment, IProfileAnalysisService analysisService)
        {
            _context = context;
            _environment = environment;
            _analysisService = analysisService;
        }
        //Retriveing the LinkedIn Data

        [HttpGet]
        public IActionResult ViewLinkedIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewLinkedIn(LinkedInViewModel model)
        {
            //check whether the Model is valid or not
            if (ModelState.IsValid)
            {
                //for storing image
                var path = _environment.WebRootPath;
                var filePath = "content/image/" + model.ProfilePicturePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                UploadImage(model.ProfilePicturePath, fullPath);
                var data = new LinkedIn()
                {
                    FullName = model.FullName,
                    ProfilePicturePath = filePath,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Headline = model.Headline,
                    Summary = model.Summary,
                    JobTitle = model.JobTitle,
                    CompanyName = model.CompanyName,
                    EmploymentStartDate = model.EmploymentStartDate,
                    EmploymentEndDate = model.EmploymentEndDate,
                    JobResponsibilities = model.JobResponsibilities,
                    Degree = model.Degree,
                    InstitutionName = model.InstitutionName,
                    GraduationDate = model.GraduationDate,
                    Skills = model.Skills,
                    Certifications = model.Certifications,
                    Projects = model.Projects,
                    Languages = model.Languages,
                    Awards = model.Awards,
                    VolunteerExperience = model.VolunteerExperience,
                    ProfessionalAffiliations = model.ProfessionalAffiliations,
                    Interests = model.Interests
                };
                _context.Add(data);
                _context.SaveChanges();

                return RedirectToAction("AnalyzeProfile", new { id = model.LinkID });
            }
            else
            {
                return View(model);
            }
        }
         public void UploadImage(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        //Analyzing the data
        [HttpGet]
        public IActionResult AnalyzeProfile(int id)
        {
            // Retrieve the profile data using the ID
            var profile = _context.LinkedIns.Find(id);

            if (profile == null)
            {
                return NotFound();
            }

            // Convert LinkedIn entity to LinkedInViewModel
            var model = new LinkedInViewModel
            {
                FullName = profile.FullName,
                // ProfilePicturePath cannot be directly assigned here as it's IFormFile
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber,
                Headline = profile.Headline,
                Summary = profile.Summary,
                JobTitle = profile.JobTitle,
                CompanyName = profile.CompanyName,
                EmploymentStartDate = profile.EmploymentStartDate,
                EmploymentEndDate = profile.EmploymentEndDate,
                JobResponsibilities = profile.JobResponsibilities,
                Degree = profile.Degree,
                InstitutionName = profile.InstitutionName,
                GraduationDate = profile.GraduationDate,
                Skills = profile.Skills,
                Certifications = profile.Certifications,
                Projects = profile.Projects,
                Languages = profile.Languages,
                Awards = profile.Awards,
                VolunteerExperience = profile.VolunteerExperience,
                ProfessionalAffiliations = profile.ProfessionalAffiliations,
                Interests = profile.Interests
            };

            // Perform analysis on the profile
            var analysisResult = _analysisService.AnalyzeProfile(model);

            // Pass the analysis result to the view
            var viewModel = new ProfileAnalysisViewModel
            {
                Profile = model,
                AnalysisResult = analysisResult
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AnalyzeProfile(LinkedInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _analysisService.AnalyzeProfile(model);
                var viewModel = new ProfileAnalysisViewModel
                {
                    Profile = model,
                    AnalysisResult = result
                };
                return View("AnalyzeProfile", viewModel);
            }
            return View("ViewLinkedIn", model);
        }
    }
}
