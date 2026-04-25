namespace JobOffer.Core.Entities
{
    public class Audit : BaseEntity<int>
    {
        public string EntityName { get; set; } 
        public string Action { get; set; }    
        public string? OldValues { get; set; } 
        public string? NewValues { get; set; } 
        public string UserName { get; set; }     

    }
}
