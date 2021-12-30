namespace Sirh3e.Validators.Core.Interfaces;

public interface IValidateRuleFailed : IValidateRuleResult
{
    string Message { get; }
}