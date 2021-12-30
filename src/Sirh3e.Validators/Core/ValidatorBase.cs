using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public abstract class ValidatorBase<T> : IValidator<T>
{
    protected readonly ValidatorBuilder<T> Builder;
    protected ValidatorBase(ValidatorBuilder<T> builder)
    {
        Builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    public IValidateResult Validate(T entity)
        => Builder.Build(entity);
}