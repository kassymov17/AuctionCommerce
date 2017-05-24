using AC.Core.Domain.Catalog;
using FluentValidation;
using AC.Data;
using AC.Services.Localization;
using AC.Web.Framework.Validators;
using AC.Web.Models.Catalog;

namespace AC.Web.Validators.Catalog
{
    public partial class ItemValidator : BaseACValidator<ItemModel>
    {
        public ItemValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.Products.Fields.Name.Required"));

            SetStringPropertiesMaxLength<Item>(dbContext);
        }
    }
}