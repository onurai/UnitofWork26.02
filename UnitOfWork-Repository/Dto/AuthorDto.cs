using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Task.Data.Entities;

namespace Mask.Dto
{
    public class AuthorDto
    {

        public string AuthorName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).Length(0, 10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).GreaterThan(10);
        }
    }
}
