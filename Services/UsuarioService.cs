using Microsoft.EntityFrameworkCore;
using BeautySoftAPI.Data;
using BeautySoftAPI.DTOs;
using BeautySoftAPI.Models;
using BeautySoftAPI.Services.Interfaces;

namespace BeautySoftAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DataContext _context;

        public UsuarioService(DataContext context)
        {
            _context = context;
        }


        public async Task<Usuario> BuscarUsuarioPorIdAsync(int Id) =>
              await _context.Usuarios.FindAsync(Id);

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarUsuarioAsync(int usuarioId, UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(h => h.Id == usuarioId);
            if (usuario != null)
            {
                usuario.NomeUsuario = usuarioDto.NomeUsuario;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletarUsuarioAsync(int usuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Usuario>> BuscarTodosUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
