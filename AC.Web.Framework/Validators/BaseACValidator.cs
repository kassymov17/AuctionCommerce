using System.Linq;
using FluentValidation;
using AC.Data;

namespace AC.Web.Framework.Validators
{
    public abstract class BaseACValidator<T> : AbstractValidator<T> where T : class
    {
        protected BaseACValidator()
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {

        }

        protected virtual void SetStringPropertiesMaxLength<TObject>(IDbContext dbContext, params string[] filterPropertyNames)
        {
            if (dbContext == null)
                return;

            var dbObjectType = typeof(TObject);

            var names = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string) && !filterPropertyNames.Contains(p.Name))
                .Select(p => p.Name).ToArray();

            var maxLength = dbContext.GetColumnsMaxLength(dbObjectType.Name, names);
            var expression = maxLength.Keys.ToDictionary(name => name, name => Kendoui.DynamicExpression.ParseLambda<T, string>(name, null));

            foreach (var expr in expression)
            {
                RuleFor(expr.Value).Length(0, maxLength[expr.Key]);
            }
        }
    }
}
