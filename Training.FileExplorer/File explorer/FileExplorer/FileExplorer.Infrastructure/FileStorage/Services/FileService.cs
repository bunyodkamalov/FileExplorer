using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Settings;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.Extensions.Options;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{

    private readonly FileFilterSettings _fileFilterSettings;
    private readonly FileStorageSettings _fileStorageSettings;
    private readonly IFileBroker _fileBroker;

    public FileService(IOptions<FileStorageSettings> fileStorageSettings,
        IOptions<FileFilterSettings> fileFilterSettings, IFileBroker fileBroker)
    {
        _fileBroker = fileBroker;
        _fileFilterSettings = fileFilterSettings.Value;
        _fileStorageSettings = fileStorageSettings.Value;
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string filesPath)
    {
        if (string.IsNullOrWhiteSpace(filesPath)) 
            throw new ArgumentNullException(nameof(filesPath));

        return new(_fileBroker.GetByPath(filesPath));
    }   


    public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        var files = await Task.Run(() => { return filesPath.Select(filePath => _fileBroker.GetByPath(filePath)).ToList(); });
        return files;
    }

    public IEnumerable<StorageFilesSummary> GetFilesSummary(IEnumerable<StorageFile> files)
    {
        var filesType = files.Select(file => (File: file, Type: GetFileType(file.Path)));

        return filesType
            .GroupBy(file => file.Type)
            .Select(filesGroup => new StorageFilesSummary()
            {
                FileType = filesGroup.Key,
                Count = filesGroup.Count(),
                Size = filesGroup.Sum(file => file.File.Size),
                DisplayName = _fileFilterSettings.FileExtensions
                        .FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.DisplayName ?? "Other files",
                ImageUrl = _fileFilterSettings.FileExtensions
                        .FirstOrDefault(extension => extension.FileType == filesGroup.Key)?.ImageUrl ?? _fileStorageSettings.FileImageUrl
            }) ;
    }

    public StorageFileType GetFileType(string filePath)
    {
        var fileExtensions = Path.GetExtension(filePath).TrimStart('.');
        var matchedFileType = _fileFilterSettings.FileExtensions.FirstOrDefault(extension => extension.Extensions.Contains(fileExtensions));

        return matchedFileType?.FileType ?? StorageFileType.Other;
    }
}
