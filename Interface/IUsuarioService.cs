using System;
using ApiJwt.Models;

namespace ApiJwt.Interface;

public interface IUsuarioService
{
    Task<Usuario> CreateUsarioAsync(string email, string senha, string nome);
    Task<Usuario?> GetUsuarioByEmailAsync(string email);
    Task<bool> DeleteUsuarioAsync(long usuarioId);
}
