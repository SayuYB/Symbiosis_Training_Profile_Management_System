using PlacementDemo.Models.ViewModels;

namespace PlacementDemo.Services
{
    public interface IProfileAnalysisService
    {
        // Defining the methods that the service will implement
        ProfileAnalysisResult AnalyzeProfile(LinkedInViewModel profile);
    }
}