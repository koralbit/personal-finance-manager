using FluentValidation;

namespace FinanceManager.Config;

public class Auth0Credentials
{
    public string Domain { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string Scope { get; set; } = null!;
}

public class Auth0CredentialsValidator : AbstractValidator<Auth0Credentials>
{
    public Auth0CredentialsValidator()
    {
        RuleFor(x => x.Domain).NotEmpty();
        RuleFor(x => x.ClientId).NotEmpty();
    }
}
