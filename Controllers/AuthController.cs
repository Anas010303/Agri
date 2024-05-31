using Agri.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Agri.Controllers
{
    public class AuthController : Controller
    {
        private readonly FirebaseAuthProvider auth;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyC_XHSECwzohgXAY7moqOZYepnFS3N1Th4"));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var registerUser = await auth.CreateUserWithEmailAndPasswordAsync(register.Username, register.Password);
                    _logger.LogInformation("User registered: {user}", JsonConvert.SerializeObject(registerUser));

                    var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(register.Username, register.Password);
                    _logger.LogInformation("User signed in: {user}", JsonConvert.SerializeObject(fbAuthLink));

                    string currentUserId = fbAuthLink.User.LocalId;

                    if (currentUserId != null)
                    {
                        HttpContext.Session.SetString("currentUser", currentUserId);
                        return RedirectToAction("Dashboard", "Farmer");
                    }
                }
                catch (FirebaseAuthException ex)
                {
                    var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                    ModelState.AddModelError(string.Empty, firebaseEx.error.message);
                    _logger.LogError("FirebaseAuthException: {message}", firebaseEx.error.message);
                    return View(register);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    _logger.LogError("Exception: {message}", ex.Message);
                    return View(register);
                }
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
                    _logger.LogInformation("User signed in: {user}", JsonConvert.SerializeObject(fbAuthLink));

                    string currentUserId = fbAuthLink.User.LocalId;

                    if (currentUserId != null)
                    {
                        HttpContext.Session.SetString("currentUser", currentUserId);
                        return RedirectToAction("Dashboard", "Farmer");
                    }
                }
                catch (FirebaseAuthException ex)
                {
                    var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                    ModelState.AddModelError(string.Empty, firebaseEx.error.message);
                    _logger.LogError("FirebaseAuthException: {message}", firebaseEx.error.message);
                    Utils.AuthLogger.Instance.LogError(firebaseEx.error.message + " - User: " + login.Email + " - IP: " + HttpContext.Connection.RemoteIpAddress
                        + " - Browser: " + Request.Headers.UserAgent);
                    return View(login);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    _logger.LogError("Exception: {message}", ex.Message);
                    return View(login);
                }
            }

            return View(login);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("currentUser");
            return RedirectToAction("Login");
        }
    }
}