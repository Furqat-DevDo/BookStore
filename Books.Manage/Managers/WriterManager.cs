using Books.Manage.Helpers.Exceptions;
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

namespace Books.Manage.Managers;

public class WriterManager : IWriterManager
{
    private readonly ILogger<WriterManager> _logger;
    private readonly IGuardian _guardian;
    private readonly IWriterMapper _writerMapper;
    private readonly IWriterRepository _writerRepository;

    public WriterManager(ILogger<WriterManager> logger,
        IGuardian guardian,
        IWriterMapper writerMapper,
        IWriterRepository writerRepository)
    {
        _logger = logger;
        _guardian = guardian;
        _writerMapper = writerMapper;
        _writerRepository = writerRepository;
    }

    public async Task<WriterModel> CreateWriterAsync(CreateWriterModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var entity = await _writerRepository.AddAsync(
            _writerMapper.ToEntity(model));

        return _writerMapper.ToModel(entity);
    }

    public async Task<bool> DeleteWriterAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        return await _writerRepository.DeleteAsync(id);
    }

    public async Task<WriterModel> GetWriterByFullNameAsync(string name)
    {
        await _guardian.GuardAgainstNullOrEmptyString(name);

        var writer = await _writerRepository.GetAsync(b => b.FullName.Contains(name,
            StringComparison.CurrentCultureIgnoreCase));

        if (writer is null)
        {
            _logger.LogWarning("Writer Not Found");
            throw new WriterNotFoundException(nameof(writer));
        }

        return _writerMapper.ToModel(writer);
    }

    public async Task<WriterModel> GetWriterByIdAsync(int id)
    {
        await _guardian.GuardAgainstZero(id);
        await _guardian.GuardAgainstMinus(id);

        var writer = await _writerRepository.GetAsync(b => b.Id == id);

        if (writer is null)
        {
            _logger.LogWarning("Writer Not Found.");
            throw new WriterNotFoundException(nameof(writer));
        }

        return _writerMapper.ToModel(writer);
    }

    public async Task<IEnumerable<WriterModel>> GetWritersAsync()
    {
        var writers = await _writerRepository.GetAllAsync();

        return !writers.Any() ? Enumerable.Empty<WriterModel>()
            : writers.AsEnumerable().Select(_writerMapper.ToModel);
    }

    public async Task<WriterModel> UpdateWriterAsync(int id, CreateWriterModel model)
    {
        await _guardian.GuardAgainstNull(model);

        var writer = await _writerRepository.GetAsync(b => b.Id == id);
        if (writer is null)
        {
            _logger.LogWarning("Writer Not found.");
            throw new WriterNotFoundException(nameof(writer));
        }

        var entity = await _writerRepository.UpdateAsync(
            _writerMapper.Update(writer, model));

        return _writerMapper.ToModel(entity);
    }
}
