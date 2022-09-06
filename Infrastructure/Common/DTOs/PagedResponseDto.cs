namespace Infrastructure.Common.DTOs;

public readonly record struct PagedResponseDto<T>(List<T> Data, int CurrentPage, int TotalCount, int PageSize)
{
    public readonly int TotalPages = (int) Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}