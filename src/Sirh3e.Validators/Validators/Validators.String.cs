using Sirh3e.Validators.Core;
using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators;

public static partial class Validators
{
    public static class String
    {
        public static Func<string, IValidateRuleResult> IsNullOrEmpty = @string => string.IsNullOrEmpty(@string)
            ? new ValidatorRuleFailure("String is null or empty")
            : new ValidatorRuleSuccessful();
    }
}