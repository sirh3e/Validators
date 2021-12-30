using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public class ValidateFailed : IValidateFailed
{

    public ValidateFailed(IEnumerable<IValidateRuleFailed> validateRuleFailed)
    {
        ValidateRuleFailed = validateRuleFailed ?? throw new ArgumentNullException(nameof(validateRuleFailed));
    }
    public IEnumerable<IValidateRuleFailed> ValidateRuleFailed { get; }

    public bool IsSuccessful => false;
}