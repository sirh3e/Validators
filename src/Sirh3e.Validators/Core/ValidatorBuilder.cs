using System.Linq.Expressions;
using Sirh3e.Validators.Core.Interfaces;

namespace Sirh3e.Validators.Core;

public class ValidatorBuilder<TEntity>
{
    protected readonly List<Lazy<Func<TEntity, IValidateRuleResult>>> ValidateRuleResults = new();

    public ValidatorBuilder<TEntity> AddRule<TMember>(Func<TEntity, TMember> selector, Func<TMember, IValidateRuleResult> validator)
    {
        _ = selector ?? throw new ArgumentException(nameof(selector));
        _ = validator ?? throw new ArgumentNullException(nameof(validator));

        return AddValidateRuleResult(entity => validator(selector(entity)));
    }

    public ValidatorBuilder<TEntity> AddRule<TMember>(Expression<Func<TEntity, TMember>> selectorExpression, IValidateRule<TMember> validateRule)
    {
        _ = selectorExpression ?? throw new ArgumentNullException(nameof(selectorExpression));
        _ = validateRule ?? throw new ArgumentNullException(nameof(validateRule));

        return AddValidateRuleResult(entity =>
        {
            if (selectorExpression.Body is not MemberExpression memberExpression)
                throw new NotImplementedException();

            var name = memberExpression.Member.Name; //ToDo
            var func = selectorExpression.Compile();
            var value = func(entity);

            return validateRule.Validate(name, value);
        });
    }

    private ValidatorBuilder<TEntity> AddValidateRuleResult(Func<TEntity, IValidateRuleResult> validateRuleResult)
    {
        ValidateRuleResults.Add(new Lazy<Func<TEntity, IValidateRuleResult>>(() => validateRuleResult));
        return this;
    }

    public IValidateResult Build(TEntity entity)
        => ValidateResult.Factory.CreateFrom(ValidateRuleResults.Select(result => result.Value(entity)).ToList());
}