using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FileStorage.Models.Filtering;
 
public class StorageFilesSummary
{
    public StorageFileType FileType { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public long Count { get; set; }

    public long Size { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}
