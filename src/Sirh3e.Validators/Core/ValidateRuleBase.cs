using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public abstract class ValidateRuleBase<T> : IValidateRule<T>
{
    protected readonly Func<string, T, string> ErrorMessageProvider;
    protected readonly Func<T, bool> RuleValidatorProvider; //ToDo find better name

    protected ValidateRuleBase(Func<T, bool> ruleValidatorProvider, Func<string, T, string> errorMessageProvider)
    {
        RuleValidatorProvider = ruleValidatorProvider ?? throw new ArgumentNullException(nameof(ruleValidatorProvider));
        ErrorMessageProvider = errorMessageProvider ?? throw new ArgumentNullException(nameof(errorMessageProvider));
    }

    public IValidateRuleResult Validate(string name, T value, Func<string, T, string>? errorMessageProvider = null)
    {
        _ = name ?? throw new ArgumentNullException(nameof(name));
        _ = value ?? throw new ArgumentNullException(nameof(value));

        return RuleValidatorProvider(value)
            ? new ValidatorRuleSuccessful()
            : new ValidatorRuleFailure((errorMessageProvider ?? ErrorMessageProvider)(name, value));
    }
}