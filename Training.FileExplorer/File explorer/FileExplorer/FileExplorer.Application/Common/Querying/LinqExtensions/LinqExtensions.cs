﻿using FileExplorer.Application.FileStorage.Models.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.Common.Querying.LinqExtensions;

public static class LinqExtensions
{
    public static IQueryable<TSource> ApplyPagination<TSource>(this IQueryable<TSource> source, FilterPagination paginationOptions)
    {
        // var pageSize = paginationOptions.DynamicPageSize;
        // return source.Skip((int)((paginationOptions.PageToken - 1) * pageSize)).Take((int)pageSize);

        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }

    public static IEnumerable<TSource> ApplyPagination<TSource>(this IEnumerable<TSource> source, FilterPagination paginationOptions)
    {
        // var pageSize = paginationOptions.DynamicPageSize;
        // return source.Skip((int)((paginationOptions.PageToken - 1) * pageSize)).Take((int)pageSize);

        return source.Skip((int)((paginationOptions.PageToken - 1) * paginationOptions.PageSize)).Take((int)paginationOptions.PageSize);
    }
}
