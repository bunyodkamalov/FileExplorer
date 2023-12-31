﻿using AutoMapper;
using FileExplorer.Api.Models.Dtos;
using FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Api.Common.MapperProfiles
{
    public class DriveProfile : Profile
    {
        public DriveProfile()
        {
            CreateMap<StorageDrive, StorageDriveDto>();
            CreateMap<StorageDriveDto, StorageDrive>();
        }
    }
}
