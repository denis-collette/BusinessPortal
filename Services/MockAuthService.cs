using BusinessPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessPortal.Services
{
    public class MockAuthService : IAuthService
    {
        private readonly List<User> _users;
        private User? _currentUser;

        public MockAuthService()
        {
            // Initialize the list of hard-coded users for testing.
            _users = new List<User>
            {
                new User { Id = "1", Name = "Super Admin", Email = "super@admin.com", BusinessId = "0", Roles = new List<UserRole> { UserRole.SuperAdmin } },
                new User { Id = "2", Name = "Alice Johnson", Email = "alice@business.com", BusinessId = "1", Roles = new List<UserRole> { UserRole.Admin } },
                // This line now correctly matches the enum in User.cs
                new User { Id = "3", Name = "Bob Smith", Email = "bob@business.com", BusinessId = "1", Roles = new List<UserRole> { UserRole.StandardUser } }
            };
        }

        public Task<User?> LoginAsync(string email, string password)
        {
            _currentUser = _users.FirstOrDefault(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(_currentUser);
        }

        public Task LogoutAsync()
        {
            _currentUser = null;
            return Task.CompletedTask;
        }

        public Task<User?> GetCurrentUserAsync()
        {
            return Task.FromResult(_currentUser);
        }
    }
}

