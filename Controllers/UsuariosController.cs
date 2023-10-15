using BeautySoftAPI.DTOs;
using BeautySoftAPI.Models;
using BeautySoftAPI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Beautysoft.Models;
using Beautysoft.DTOs;
using System.Security.Cryptography;

namespace BeautySoftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        private readonly IConfiguration _config;

        public static Usuario usuario = new Usuario();

        public UsuariosController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            this._usuarioService = usuarioService;
            this._config = configuration;

        }


        [HttpPost("Register")]
        public async Task<ActionResult<Usuario>> Register(UsuarioDto request)
        {
            CreatePasswordHash(request.Senha, out byte[] passwordHash, out byte[] passwordSalt);

            usuario.NomeUsuario = request.NomeUsuario;
            usuario.SenhaHash = passwordHash;
            usuario.SenhaSalt = passwordSalt;

            return Ok(request);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UsuarioDto request)
        {
            if (request.NomeUsuario != usuario.NomeUsuario)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPasswordHash(request.Senha, usuario.SenhaHash, usuario.SenhaSalt))
            {
                return BadRequest("Wrong Password");
            }

            string token = CreateToken(usuario);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (!usuario.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token");
            }
            else if (usuario.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token Expired");
            }
            string token = CreateToken(usuario);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
            usuario.RefreshToken = refreshToken.Token;
            usuario.TokenCreated = refreshToken.Created;
            usuario.TokenExpires = refreshToken.Expires;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private string CreateToken(Usuario user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.NomeUsuario),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
                (
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passworHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passworHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passworHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passworHash);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarUsuarios()
        {
            var usuarios = await _usuarioService.BuscarTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorIdAsync(id);
            if (usuario == null) return NotFound("Id não encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AdicionarUsuario([FromBody] Usuario usuario)
        {
            await _usuarioService.AdicionarUsuarioAsync(usuario);
            return CreatedAtAction(nameof(BuscarUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] UsuarioDto usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("Dados inválidos para o usuário.");

            await _usuarioService.AtualizarUsuarioAsync(id, usuarioDTO);

            return Ok(new { message = "O usuário foi atualizado com êxito." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            if (id == null) return BadRequest("Id não encontrado.");
            await _usuarioService.DeletarUsuarioAsync(id);

            return Ok("Usuário deletado com Sucesso!");
        }
        

    }
}
