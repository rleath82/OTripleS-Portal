using System;

namespace OTripleS.Portal.Web.Services.Users
{
    public interface IUserService
    {
        Guid GetCurrentlyLoggedInUser();
    }
}
