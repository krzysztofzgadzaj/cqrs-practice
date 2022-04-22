using FluentValidation;

namespace FullCqrsApp.Contracts.Commands.AddUser
{
    public class AddUserCommandValidator
        : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
            
            RuleFor(x => x.Surname)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}