namespace Domain.DTOs
{
    public class BiddingPaginatedDTO
    {
        public bool Paginated { get; set; } = true;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 5;
        public string Search { get; set; } = string.Empty;
        public string SortColumn { get; set; } = nameof(BiddingDTO.Number);
        public string SortDirection { get; set; } = "asc";
    }
}