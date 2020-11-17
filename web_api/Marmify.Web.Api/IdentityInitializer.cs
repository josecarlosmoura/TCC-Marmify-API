using Marmify.Application.Interfaces.Entities;
using Marmify.Domain.Commons;
using Marmify.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace Marmify.Web.Api
{
	public class IdentityInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAddressAppService _addressAppService;

        public IdentityInitializer(
            UserManager<User> userManager,
            RoleManager<ApplicationRole> roleManager,
            IAddressAppService addressAppService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _addressAppService = addressAppService;
        }

        public void Initialize()
        {
            GenerateRoles();

            CreateUser(new User
            {
                UserName = "administrator@mamify.com",
                Email = "administrator@mamify.com",
                PhoneNumber = "N/A",
                CellPhone = "N/A",
                FullName = "Administrator",
                Cpf = "N/A",
                DateBirth = DateTime.Now,
                EstablishmentId = 1
            }, "zaq1ZAQ!", "Administrator");

            //CreateAddress(new Address
            //{
            //    Street = "Street One",
            //    Number = 100,
            //    Neighborhood = "Brooklyn",
            //    PostalCode = "38400400",
            //    UserId = 1
            //});
        }

        private void CreateAddress(Address address)
        {
            _addressAppService.CreateEntity(address);
        }

        private void GenerateRoles()
        {
            foreach (string role in ConstProfiles.GetListConstProfiles())
            {
                if (!_roleManager.RoleExistsAsync(role).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new ApplicationRole
                        {
                            Name = role
                        }).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception($"Erro durante a criação da role {role}.");
                    }
                }
            }
        }

        private void CreateUser(User user, string password, string initialRole = null)
       {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !string.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
