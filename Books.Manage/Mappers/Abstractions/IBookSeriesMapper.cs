using Books.Core.Entities;
using Books.Manage.Managers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Mappers.Abstractions;

public interface IBookSeriesMapper
{
    BookSeries ToEntity(CreateBookSeriesModel model);
    BookSeriesModel ToModel(BookSeries entity);
    BookSeries Update(BookSeries entity, CreateBookSeriesModel seriesModel);
}
