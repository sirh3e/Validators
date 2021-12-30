namespace Sirh3e.Validators.Core.Interfaces;

public interface IValidateRule<T>
{
    IValidateRuleResult Validate(string name, T value, Func<string, T, string>? errorMessageProvider = null);
}