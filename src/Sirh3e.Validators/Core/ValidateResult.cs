using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public static class ValidateResult
{
    public static class Factory
    {
        public static IValidateResult CreateFrom(ICollection<IValidateRuleResult> validateRuleResults)
        {
            _ = validateRuleResults ?? throw new ArgumentNullException(nameof(validateRuleResults));

            return validateRuleResults.Any(result => !result.IsSuccessful)
                ? new ValidateFailed(validateRuleResults.Where(result => !result.IsSuccessful).Cast<IValidateRuleFailed>())
                : new ValidateSuccessful();
        }
    }
}