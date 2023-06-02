using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using EtecBookApi.Data;
using EtecBookApi.DataTransferObjects;

using EtecBookApi.Models;
using EtecBookAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtecBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        // Injetando o context do aplicativo que esta a conexão string do banco
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto login)
        {
            if (login == null)
                return BadRequest();

            // o modelSat
            if (!ModelState.IsValid)
                return BadRequest();

            AppUser user = new();
            if (isEmail(login.Email))
            {
                //Acha o usuario pelo email
                user = await _context.Users.FirstOrDefaultAsync(
                    u => u.Email.Equals(login.Email)
                );
            }
            else
            {
                //Acha o usuario pelo usermame
                user = await _context.Users.FirstOrDefaultAsync(
                    u => u.UserName.Equals(login.Email)
                );

            }

            if (user == null)
                return NotFound(new { Message = "Usuário e/ou Senha Inválidos!!" });

            if (!PasswordHasher.VerifyPassword(login.Password, user.Password))
                return NotFound(new { Message = "Usuário e/ou Senha Inválidos!!" });

            return Ok(new { Message = "Usuario Autenticado" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            // testando se o register é nullo
            if (register == null)
                return BadRequest();

            //testando se o estatos do email é valido
            if (!ModelState.IsValid)
                return BadRequest();

            // Checar se o email já existe

            if (await _context.Users.AnyAsync(u => u.Email.Equals(register.Email))) ;
            return BadRequest(new { Message = "Email já esta cadastro! Tente recuperar a sua senha ou entre em contato com os administradores" });

            // Checar a força da senha
            var pass = CheckPasswordStrength(register.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass });
        }

        private bool isEmail(string email)
        {
            try
            {
                // Testando se o email é um email, estamos tendo converte a string em um email
                MailAddress mail = new(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string CheckPasswordStrength(string password)
        {
            // StringBuilder é usado para construir texto e verfificações
            // Envoironment faz o quebra de linha
            StringBuilder sb = new();
            if (password.Length < 0)
                sb.Append("A senha deve possuir no mínimop 6 caractres" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]") && (Regex.IsMatch(password, "[0-9]")));
            sb.Append("A Senha deve ser alfanumerico" + Environment.NewLine);

            if (!Regex.IsMatch(password, "[<,>,!,@,#,$,%,&,*,(,),_,-,+,=,§,?,/,.,:,;,`,{,},\\[ ,\\],º,~,^,/,\\,]"))
                sb.Append("A Senha deve conter um caracter especial " + Environment.NewLine);
            return sb.ToString();            
             ));

        }
    }
}