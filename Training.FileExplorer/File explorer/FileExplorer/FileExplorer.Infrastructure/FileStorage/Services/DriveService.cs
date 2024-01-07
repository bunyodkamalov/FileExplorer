using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Application.FileStorage.Models.Storage;
using FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _driveBroker;

    public DriveService(IDriveBroker driveBroker)
    {
        _driveBroker = driveBroker;
    }

    public ValueTask<IList<StorageDrive>> GetAsync()
    {
        var drives = _driveBroker.Get().ToList();
        return new ValueTask<IList<StorageDrive>>(drives);
    }
}
