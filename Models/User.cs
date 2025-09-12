using System.Collections.Generic;

namespace BusinessPortal.Models
{
    // Enum to define the user roles. This provides strong typing and prevents magic strings.
    public enum UserRole
    {
        SuperAdmin,
        Admin,
        Manager,
        Financial,
        Employee,
        Technician,
        Client
    }

    public class User
    {
        // Initialize properties with default non-null values
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UserRole> Roles { get; set; } = new(); // new() is shorthand for new List<UserRole>()
        public string BusinessId { get; set; } = string.Empty;
    }
}

