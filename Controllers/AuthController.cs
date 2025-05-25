using Microsoft.AspNetCore.Mvc;
using AWS_gamehub_front.Models;
using AWS_gamehub_front.Services.HttpServices;
using System.Threading.Tasks;
using AWS_gamehub_front.Models.DTOs;

namespace AWS_gamehub_front.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View(new LoginDTO
            {
                UsernameOrEmail = string.Empty,
                Password = string.Empty
            });
        }

        public IActionResult Register()
        {
            return View(new RegisterDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                var loginResult = await _authService.LoginAsync(model);
                //comentarios
                if (loginResult != null && !string.IsNullOrEmpty(loginResult.accessToken))
                {
                    // Guardar el JWT en una cookie segura y httpOnly
                    Response.Cookies.Append("jwt", loginResult.accessToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = false, // Solo en HTTPS en producción
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(2)
                    });


                    // Redirigir a la página principal, dashboard, etc.
                    return RedirectToAction("Index", "Videogame");
                }
                else
                {
                    ViewBag.Message = "Usuario o contraseña incorrectos.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error controlador login ------> " + ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            try
            {
                

                // Directly pass the RegisterDto model to the AuthService  
                var response = await _authService.RegisterAsync(model);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "¡Registro exitoso! Ahora puedes iniciar sesión.";
                    ModelState.Clear();
                    //limpiar formulario t ir a pagina de login
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    ViewBag.Message = "Error en el registro. Intenta nuevamente.";
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorContent);
                    return View(model);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("error al registrar ------> " + ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            var token = Request.Cookies["AuthToken"];

            if (string.IsNullOrEmpty(token))
            {
                // Si no hay token, simplemente redirige a la página de inicio
                return RedirectToAction("Index", "Videogame");
            }

            Response.Cookies.Delete("AuthToken");
            // Si guardas el nombre/email en otra cookie, bórrala también
            return RedirectToAction("Index", "Videogame");
        }

    }
}
