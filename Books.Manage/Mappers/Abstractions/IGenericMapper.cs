namespace Books.Manage.Mappers.Abstractions;

public interface IGenericMapper <in TModel,TEntity, out TReturn> 
    where TModel : class where TEntity : class where TReturn : class
{
    TEntity ToEntity(TModel  model);
    TReturn ToModel(TEntity entity);
    TEntity Update(TEntity entity,TModel model);

}