using FluentValidation;

namespace JobCandidate.Api.Models
{
    public class CandidateModel
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? TimeToCall { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string Comment { get; set; }
    }

    public class CandidateValidator : AbstractValidator<CandidateModel>
    {
        public CandidateValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().Matches("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
            RuleFor(x => x.Comment).NotEmpty();
        }
    }
}
