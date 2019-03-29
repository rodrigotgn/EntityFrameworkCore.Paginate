namespace EntityFrameworkCore.Paginate
{
    /// <summary>
    /// Interface Pagination Info.
    /// </summary>
    public interface IPaginationInfo
    {
        /// <summary>
        /// Page.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Per Page.
        /// </summary>
        int Per_Page { get; set; }

        /// <summary>
        /// Ordenação por property.
        /// </summary>
        string sort_by { get; set; }

        /// <summary>
        /// Ordem de sorteio.
        /// </summary>
        EnumSortOrder sort_order { get; set; }
    }
}
