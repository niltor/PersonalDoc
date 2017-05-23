```csharp
	public class AuthController : Controller
	{

		public AuthController()
		{

		}


		public IActionResult Login()
		{

			var identity = new ClaimsIdentity("admin");
			identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
			identity.AddClaim(new Claim(ClaimTypes.Name, "admin"));

			var principal = new ClaimsPrincipal(identity);
			HttpContext.Authentication.SignInAsync("MSDevAdmin", principal);

			return View();
		}



		public IActionResult Logout(){
			HttpContext.Authentication.SignOutAsync("MSDevAdmin");
			return RedirectToAction("Index", "Home");

		}

		public IActionResult Forbidden()
		{
			return View();
		}
	}
```