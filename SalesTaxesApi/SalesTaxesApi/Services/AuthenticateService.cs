using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class AuthenticateService
    {
        private readonly SalesTaxesDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<MyUser> _signInManager;
        private ILogger<AuthenticateService> _logger;

        public AuthenticateService(
              SalesTaxesDBContext context,
              IConfiguration configuration,
              UserManager<MyUser> userManager,
              SignInManager<MyUser> signInManager,
              RoleManager<IdentityRole> roleManager,
              ILogger<AuthenticateService> logger
          )
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        

    }
}
