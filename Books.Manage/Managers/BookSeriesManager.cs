using Books.Manage.Helpers.Validators;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers
{
    public class BookSeriesManager : IBookSeriesManager
    {
        private readonly ILogger<BookSeriesManager> _logger;
        private readonly IGuardian _guardian;
        private readonly IBookSeriesMapper _mapper;
        private readonly IBookSeriesRepository _seriesRepository;

        public BookSeriesManager(ILogger<BookSeriesManager> logger,
            IGuardian guardian,
            IBookSeriesMapper mapper,
            IBookSeriesRepository seriesRepository)
        {
            _logger = logger;
            _guardian = guardian;
            _mapper = mapper;
            _seriesRepository = seriesRepository;
        }
        public Task<BookSeriesModel> CreateBookSeriesAsync(CreateBookSeriesModel model)
        {
            
        }

        public Task<bool> DeleteBookSeriesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookSeriesModel> GetBookSeriesByBookId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookSeriesModel> GetBookSeriesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookSeriesModel> GetBookSeriesByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<BookSeriesModel> GetBookSeriesByWriterId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookSeriesModel> UpdateBookSeriesAsync(CreateBookSeriesModel model)
        {
            throw new NotImplementedException();
        }
    }
}
