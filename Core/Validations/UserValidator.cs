using FluentValidation;
using Data.Data;
using Data.Entities;

namespace YouTube.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();
        public UserValidator()
        {
           /* RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Nickname)
                .NotEmpty().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is not valid")
                .Must(BeUniqueEmail).WithMessage("Email must be unique.");

            RuleFor(x => x.Password)
                .NotEmpty().MinimumLength(4).MaximumLength(10)
                .WithMessage("{PropertyName} must be between 4 and 10 characters");

            RuleFor(x => x.AvatarUrl)
                .Must(LinkMustBeAUri).WithMessage("Image URL address must be valid.");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("{PropertyName} is not valid")
                .Must(ValidAge).WithMessage("User must be at least 12 years old.");*/
        }
        private bool BeUniqueEmail(string email)
        {
            return !ctx.Users.Any(u => u.Email == email);
        }
        private static bool ValidAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;

            if (birthday.Date > today.AddYears(-age)) age--;

            return age >= 12;
        }
        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
