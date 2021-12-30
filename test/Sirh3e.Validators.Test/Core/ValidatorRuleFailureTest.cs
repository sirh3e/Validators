using FluentAssertions;
using Sirh3e.Validators.Core;
using Sirh3e.Validators.Core.Interfaces;
using Xunit;

namespace Sirh3e.Validators.Test.Core;

public class ValidatorRuleFailureTest
{
    [Theory]
    [InlineData("some error message nobody knows")]
    public void ValidatorRuleFailure(string message) //ToDo find a better name
    {
        var validatorRuleFailure = new ValidatorRuleFailure(message);

        validatorRuleFailure.Message.Should().Be(message);
        validatorRuleFailure.IsSuccessful.Should().BeFalse();
    }
    
    [Theory]
    [InlineData("some error message nobody knows")]
    public void ValidatorRuleFailureInterface(string message) //ToDo find a better name
    {
        var validatorRuleFailure = new ValidatorRuleFailure(message) as IValidateRuleFailed;

        validatorRuleFailure.Should().NotBeNull();
        validatorRuleFailure.Message.Should().Be(message);
        validatorRuleFailure.IsSuccessful.Should().BeFalse();
    }
}