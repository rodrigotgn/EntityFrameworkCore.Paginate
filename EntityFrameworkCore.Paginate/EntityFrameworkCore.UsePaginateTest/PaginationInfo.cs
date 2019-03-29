using EntityFrameworkCore.Paginate;

namespace EntityFrameworkCore.UsePaginateTest
{
    /// <summary>
    /// Interface Pagination Info.
    /// </summary>
    public class PaginationInfo : IPaginationInfo
    {
        /// <summary>
        /// Page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Per Page.
        /// </summary>
        public int Per_Page { get; set; }

        /// <summary>
        /// Ordenação por property.
        /// </summary>
        public string sort_by { get; set; }

        /// <summary>
        /// Ordem de sorteio.
        /// </summary>
        public EnumSortOrder sort_order { get; set; }
    }
}
