using AutoMapper;
using FileExplorer.Application.FileStorage.Models.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Infrastructure.Common.MapperProfiles;

public class FileProfile : Profile
{
    public FileProfile()
    {
        CreateMap<FileInfo, StorageFile>()
            .ForMember(src => src.Name, opt => opt.MapFrom(dest => dest.Name))
            .ForMember(src => src.Path, opt => opt.MapFrom(dest => dest.FullName))
            .ForMember(src => src.DirectoryPath, opt => opt.MapFrom(dest => dest.DirectoryName))
            .ForMember(src => src.Size, opt => opt.MapFrom(dest => dest.Length))
            .ForMember(dest => dest.Extension, opt => opt.MapFrom(dest => dest.Extension));
    }
}
