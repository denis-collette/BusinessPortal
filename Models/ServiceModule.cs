namespace BusinessPortal.Models
{
    // Represents the services/modules available in the portal (e.g., CRM, Invoicing)
    public class ServiceModule
    {
        // Initialize properties with default non-null values
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}

