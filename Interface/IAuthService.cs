using System;

namespace ApiJwt.Interface;

public interface IAuthService
{
    Task<string?> ValidarLoginAsync(string email, string senha);
}
