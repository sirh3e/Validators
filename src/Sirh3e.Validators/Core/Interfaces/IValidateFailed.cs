namespace Sirh3e.Validators.Core.Interfaces;

public interface IValidateFailed : IValidateResult
{
    IEnumerable<IValidateRuleFailed> ValidateRuleFailed { get; } //ToDo find out how to call this
}