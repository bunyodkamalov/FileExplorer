using FileExplorer.Application.FileStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FileStorage.Interfaces
{
    public interface IStorageEntry
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public StorageEntryType EntryType { get; set; }
    }
}
