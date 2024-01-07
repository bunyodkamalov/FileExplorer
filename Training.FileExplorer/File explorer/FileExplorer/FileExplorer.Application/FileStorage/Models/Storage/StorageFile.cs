using FileExplorer.Application.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FileStorage.Models.Storage
{
    public class StorageFile : IStorageEntry
    {
        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public string? DirectoryPath { get; set; } = string.Empty;

        public long Size { get; set; }

        public string Extension { get; set; } = string.Empty;

        public StorageEntryType EntryType { get; set; } = StorageEntryType.File;

    }
}
