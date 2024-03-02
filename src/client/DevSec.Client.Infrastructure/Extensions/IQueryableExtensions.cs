using Microsoft.EntityFrameworkCore;
using PagedList;

namespace DevSec.Client.Infrastructure.Extensions;

public class PagedListExtended<T> : BasePagedList<T>
{
    private PagedListExtended()
    {
    }

    public static async Task<IPagedList<T>> Create(IQueryable<T> superset, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var list = new PagedListExtended<T>();
        await list.InitializeAsync(superset, pageNumber, pageSize, cancellationToken);
        return list;
    }

    private async Task InitializeAsync(IQueryable<T> superset, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException("pageNumber", pageNumber, "PageNumber cannot be below 1.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException("pageSize", pageSize, "PageSize cannot be less than 1.");
        }

        TotalItemCount = superset == null ? 
            0 : await superset.CountAsync(cancellationToken);

        PageSize = pageSize;

        PageNumber = pageNumber;

        PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;

        HasPreviousPage = PageNumber > 1;

        HasNextPage = PageNumber < PageCount;

        IsFirstPage = PageNumber == 1;

        IsLastPage = PageNumber >= PageCount;

        FirstItemOnPage = (PageNumber - 1) * PageSize + 1;

        LastItemOnPage = (FirstItemOnPage + PageSize - 1) > TotalItemCount ? 
            TotalItemCount : 
            (FirstItemOnPage + PageSize - 1);

        if (superset == null || TotalItemCount <= 0)
        {
            return;
        }

        Subset.AddRange(pageNumber == 1 ? 
            await superset.Skip(0).Take(pageSize).ToListAsync(cancellationToken) : 
            await superset.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken));
    }
}

internal static class IQueryableExtensions
{
    public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> superset, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await PagedListExtended<T>.Create(superset, pageNumber, pageSize, cancellationToken);
    }
}
