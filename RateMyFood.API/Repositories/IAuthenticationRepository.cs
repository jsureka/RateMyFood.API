using Microsoft.AspNetCore.Mvc;
using RateMyFood.API.Entities;

namespace RateMyFood.API.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<IActionResult> Add(User user);
        Task<IActionResult> Get(string username, string password);
        Task<IActionResult> Update();
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> GetById(Guid id);
    }
}
