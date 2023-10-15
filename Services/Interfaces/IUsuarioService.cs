using BeautySoftAPI.DTOs;
using BeautySoftAPI.Models;

namespace BeautySoftAPI.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> BuscarTodosUsuariosAsync();
        Task<Usuario> BuscarUsuarioPorIdAsync(int usuarioId);
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task AtualizarUsuarioAsync(int usuario, UsuarioDto usuarioDTO);
        Task DeletarUsuarioAsync(int usuarioId);
    }
}
