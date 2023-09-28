namespace Books.Web.ViewManagers;

public interface IGenericViewManager <TModel,TViewModel>
{
    Task<TModel> CreateAsync(TViewModel viewModel);
    Task<TViewModel> ReturnAsync(TModel model);
}