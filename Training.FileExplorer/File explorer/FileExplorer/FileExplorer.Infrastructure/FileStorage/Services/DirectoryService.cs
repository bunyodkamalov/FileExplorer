using AutoMapper;
using FileExplorer.Application.Common.Querying.LinqExtensions;
using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Application.FileStorage.Models.Filtering;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _directoryBroker;

    public DirectoryService(IDirectoryBroker directoryBroker, IMapper mapper)
    {
        _directoryBroker = directoryBroker;
    }

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_directoryBroker.GetByPathAsync(directoryPath));
    }

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = await Task.Run(() => _directoryBroker.GetDirectories(directoryPath).ApplyPagination(paginationOptions).ToList());

        return directories;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions)
    {
        return _directoryBroker.GetDirectoriesPath(directoryPath).ApplyPagination(paginationOptions);
    }

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions)
    {
        return _directoryBroker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);
    }
}
