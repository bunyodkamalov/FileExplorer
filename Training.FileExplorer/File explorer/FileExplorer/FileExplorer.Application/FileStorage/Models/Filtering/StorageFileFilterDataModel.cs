using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.FileStorage.Models.Filtering;

public class StorageFileFilterDataModel : FilterPagination
{
    public List<StorageFilesSummary> FilterData { get; set; } = new();
}
