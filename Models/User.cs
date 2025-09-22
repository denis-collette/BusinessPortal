using System.Collections.Generic;

namespace BusinessPortal.Models
{
    // Ensure the enum contains all the roles we need.
    public enum UserRole
    {
        SuperAdmin,
        Admin,
        StandardUser, // This was likely the missing or misspelled value.
        Manager,
        Financial,
        Employee,
        Technician,
        Client
    }

    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<UserRole> Roles { get; set; } = new List<UserRole>();
        public string BusinessId { get; set; } = string.Empty;
    }
}

