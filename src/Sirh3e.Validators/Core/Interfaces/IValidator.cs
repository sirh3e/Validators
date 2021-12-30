namespace Sirh3e.Validators.Core.Interfaces;

public interface IValidator<in TEntity>
{
    IValidateResult Validate(TEntity entity);
}