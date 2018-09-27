using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace SantosSantana.WebAPI
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-control-Allow-Origin", new[] { "*" });

            try
            {
                var dd = context.UserName;
                string[] conta = context.UserName.Split(';');
                var password = context.Password;

                Servicos.ServicoUsuario ser = new Servicos.ServicoUsuario();
            
                if (!ser.Acessar(conta[0],conta[1],password))
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, conta[0]));

                var roles = new List<string>();
                roles.Add("Admin");
                roles.Add("User");

                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                GenericPrincipal principal = new GenericPrincipal(identity, roles.ToArray());
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);


            }
            catch
            {

                context.SetError("invalid_grant", "Falha ao autenticar");
            }
        }
    }
}