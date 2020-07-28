using BlogServer.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogServer.Services
{
    public interface IUserService
    {
        string GetName();
        Task<User> GetOrPopulateUserAsync(CancellationToken cancellationToken = default);
        string GetPreferredUsername();
        string GetUserId();
    }
}
