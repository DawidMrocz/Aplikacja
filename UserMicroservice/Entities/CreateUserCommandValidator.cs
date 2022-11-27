using FluentValidation;
using UserMicroserivce.Commands;
using UserMicroservice.Models;

namespace UserMicroservice.Entities
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(UserDbContext contex)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = contex.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is takem");
                }
            });

        }
    }
}
