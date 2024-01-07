using FileExplorer.Application.FileStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FileStorage.Broker;

public interface IFileBroker
{
    StorageFile GetByPath(string filePath);
}
