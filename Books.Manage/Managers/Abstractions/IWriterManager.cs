﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Manage.Managers.Abstractions;

public class WriterModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public List<BookModel>? Books { get; set; }
    public List<BookSeriesModel>? BookSeries { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

public record CreateWriterModel(int Id,
    string FullName,
    List<BookModel>? Books,
    List<BookSeriesModel>? BookSeries);

public interface IWriterManager
{
    Task<WriterModel> CreateWriterAsync(CreateWriterModel model);
    Task<WriterModel> UpdateWriterAsync(int id, CreateWriterModel model);
    Task<bool> DeleteWriterAsync(int id);
    Task<WriterModel> GetWriterByIdAsync(int id);
    Task<WriterModel> GetWriterByFullNameAsync(string name);
    Task<IEnumerable<WriterModel>> GetWritersAsync();
}
