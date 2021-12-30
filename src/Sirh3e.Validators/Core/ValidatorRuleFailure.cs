using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public class ValidatorRuleFailure : IValidateRuleFailed
{
    public ValidatorRuleFailure(string message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
    }

    public string Message { get; }

    public bool IsSuccessful => false;
}