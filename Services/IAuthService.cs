using BusinessPortal.Models;
using System.Threading.Tasks;

namespace BusinessPortal.Services
{
	/// <summary>
	/// Defines the contract for an authentication service.
	/// Any class implementing this interface must provide these methods.
	/// </summary>
	public interface IAuthService
	{
		/// <summary>
		/// Attempts to log a user in with the given credentials.
		/// </summary>
		/// <param name="email">The user's email.</param>
		/// <param name="password">The user's password.</param>
		/// <returns>A User object if successful, otherwise null.</returns>
		Task<User?> LoginAsync(string email, string password);

		/// <summary>
		/// Logs the current user out.
		/// </summary>
		Task LogoutAsync();

		/// <summary>
		/// Gets the currently authenticated user.
		/// </summary>
		/// <returns>The current User object, or null if not authenticated.</returns>
		Task<User?> GetCurrentUserAsync();
	}
}
