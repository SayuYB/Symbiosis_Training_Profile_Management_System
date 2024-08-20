using Microsoft.EntityFrameworkCore;
using PlacementDemo.Data;
using PlacementDemo.Models.ViewModels;

namespace PlacementDemo.Services
{
    public class ProfileAnalysisService : IProfileAnalysisService
    {
        private readonly LinkedInContext _context;
        //We have initialize the constructor to access the database
        public ProfileAnalysisService(LinkedInContext context)
        {
            _context = context;
        }

        
        public ProfileAnalysisResult AnalyzeProfile(LinkedInViewModel profile)
        {
            // Extracting keywords from profile fields
            var profileKeywords =new List<string>();
            profileKeywords.AddRange(profile.Skills.Split(','));
            profileKeywords.AddRange(profile.Certifications.Split(','));
            profileKeywords.AddRange(profile.Projects.Split(','));

            // Retrieving required keywords from database
            var requiredKeywords = _context.RoleKeywords
                .Include(rk => rk.Keyword)
                .ToList();

            //comparing extracted keywords from the profile with the required keywords from table
            var matchedKeywords = profileKeywords
            .Select(k => k.Trim().ToLower())
            .Intersect(requiredKeywords.Select(rk => rk.Keyword.KeywordName.ToLower()))
            .ToList();

            //calculates the percentage of matched keywords out of total required keywords
            var matchPercentage = (double)matchedKeywords.Count / requiredKeywords.Count * 100;

            return new ProfileAnalysisResult
            {
                MatchPercentage = matchPercentage,
                MatchedKeywords = matchedKeywords
            };

        }
    }    
}
