using BusinessPortal.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessPortal.Services
{
    /// <summary>
    /// A mock implementation of IAuthService for development and testing.
    /// It uses a hard-coded list of users instead of a real database.
    /// </summary>
    public class MockAuthService : IAuthService
    {
        // Our hard-coded, in-memory "user database"
        private readonly List<User> _users;
        private User? _currentUser;

        public MockAuthService()
        {
            _users = new List<User>
            {
                new User { Id = "1", Name = "Super Admin", Email = "super@admin.com", Roles = new List<UserRole> { UserRole.SuperAdmin } },
                new User { Id = "2", Name = "Alice Owner", Email = "alice@business.com", Roles = new List<UserRole> { UserRole.Admin }, BusinessId = "b1" },
                new User { Id = "3", Name = "Bob User", Email = "bob@business.com", Roles = new List<UserRole> { UserRole.User }, BusinessId = "b1" }
            };
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            // In a real app, you would also check the hashed password. Here we just check email.
            var user = _users.FirstOrDefault(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));

            _currentUser = user;

            // Simulate a network delay to feel more realistic
            await Task.Delay(500);

            return _currentUser;
        }

        public async Task LogoutAsync()
        {
            _currentUser = null;
            await Task.Delay(250); // Simulate a quick network call
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            await Task.Delay(50); // Simulate a quick check
            return _currentUser;
        }
    }
}
