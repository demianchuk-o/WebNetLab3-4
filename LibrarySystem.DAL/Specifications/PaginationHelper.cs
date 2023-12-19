namespace LibrarySystem.DAL.Specifications;

public static class PaginationHelper
{
    public static (int Skip, int Take) GetPaginationValues(int pageNumber, int pageSize)
        => ((pageNumber - 1) * pageSize, pageSize);
}