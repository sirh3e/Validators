using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Extensions;

public static class Extensions
{
    public static bool IsValid(IValidateResult result)
        => result.IsSuccessful;

    public static bool IsNotValid(IValidateResult result)
        => !IsValid(result);
}