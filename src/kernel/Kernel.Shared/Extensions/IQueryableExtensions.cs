using Microsoft.EntityFrameworkCore;

namespace Kernel.Shared.Extensions;

public class PagedList<T> : PaginationMetaData
{
    public IReadOnlyCollection<T> Items { get; set; } = new List<T>();
}

public class PaginationMetaData
{
    public int FirstItemOnPage { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
    public int LastItemOnPage { get; set; }
    public int PageCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemCount { get; set; }
}

public static class IQueryableExtensions
{
    /// <summary>
    /// Конвертация в SerializablePagedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="queryable"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> queryable, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (page < 1) throw new ArgumentException($"{nameof(page)} cannot be lower than 1", nameof(page));
        if (pageSize < 1) throw new ArgumentNullException($"{nameof(pageSize)} cannot be lower than 1", nameof(pageSize));

        var serializedPagedList = new PagedList<T>()
        {
            Items = await queryable
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken),

            TotalItemCount = await queryable
                .CountAsync(cancellationToken),

            PageSize = pageSize,
            PageNumber = page,
        };

        serializedPagedList.FirstItemOnPage = (page - 1) * pageSize + 1;
        serializedPagedList.LastItemOnPage =
            serializedPagedList.FirstItemOnPage + pageSize - 1 > serializedPagedList.TotalItemCount ?
                serializedPagedList.TotalItemCount :
                serializedPagedList.FirstItemOnPage + pageSize - 1;

        serializedPagedList.PageCount = serializedPagedList.TotalItemCount > 0 ?
                (int)Math.Ceiling(serializedPagedList.TotalItemCount / (double)serializedPagedList.PageSize) : 0;

        serializedPagedList.IsFirstPage = page == 1;
        serializedPagedList.IsLastPage = page >= serializedPagedList.PageCount;

        serializedPagedList.HasNextPage = page < serializedPagedList.PageCount;
        serializedPagedList.HasPreviousPage = page > 1;

        return serializedPagedList;
    }
}
