
namespace CriteriaSetUp_BE.Models
{
    public class CriteriaModule
    {
        public int? ID { get; set; }
        public string? Source { get; set; }
        public string? Criteria { get; set; }
    }
    public class CriteriaStatus
    {
        public int? ID { get; set; }
        public string? CriteriaStatusID { get; set; }
        public string? StatusDescription { get; set; }
        public string? Source { get; set; }
    }
    public class CriteriaStatuses
    {
        public int? Id { get; set; }
        public string? Source { get; set; }
        public bool? isActive { get; set; }
        public string? StatusName { get; set; }
        public string? Criteria { get; set; }
        public string? FeatureName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public class Criterilmodule 
    {
        public int? Id { get; set; }
        public string? Source { get; set; }
        public string? Criteria { get; set; }

    }
    public class Result<T>
    {
        public string? Message { get; set; }
        public T? Data { get; set; }
        public bool Status { get; set; }
        public short StatusCode { get; set; }
        public int PageNumber { get; set; }
        public long TotalRecords { get; set; }
        public string? MessageDetails { get; set; }
    }
}

