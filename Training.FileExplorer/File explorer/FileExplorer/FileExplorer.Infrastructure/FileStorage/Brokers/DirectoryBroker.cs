using AutoMapper;
using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers
{
    public class DirectoryBroker : IDirectoryBroker
    {
        private readonly IMapper _mapper;

        public DirectoryBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool ExistsAsync(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        public StorageDirectory GetByPathAsync(string directoryPath)
        {
            return _mapper.Map<StorageDirectory>(new DirectoryInfo(directoryPath));
        }

        public IEnumerable<StorageDirectory> GetDirectories(string directoryPath)
        {
            return GetDirectoriesPath(directoryPath).Select(path => _mapper.Map<StorageDirectory>(new DirectoryInfo(path)));
        }

        public IEnumerable<string> GetDirectoriesPath(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath);
        }

        public IEnumerable<string> GetFilesPath(string directoryPath)
        { 
            return Directory.EnumerateFiles(directoryPath);
        }
    }
}
