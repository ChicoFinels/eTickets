﻿using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;

namespace eTickets.Data
{
    public class Inicializacao
    {
        public static void CriaDadosIniciais(AppDbContext _context)
        {
            //assegura que a base de dados foi criada e existe
            _context.Database.EnsureCreated();

            //se a base de dados estiver vazia
            if (!_context.Cinemas.Any() && !_context.Atores.Any() && !_context.Diretores.Any() && !_context.Filmes.Any() && !_context.Atores_Filmes.Any())
            {
                //Cinema
                _context.Cinemas.AddRange(new List<Cinema>()
                {
                    new Cinema()
                    {
                        Nome = "Cinema 1",
                        LogoURL = "https://yt3.googleusercontent.com/ytc/AL5GRJV0GPGA-HU8vpk2EWp186cfOiDiHVOqhXu4A5tY=s900-c-k-c0x00ffffff-no-rj",
                        Descricao = "Esta é a descrição do primeiro cinema"
                    },
                    new Cinema()
                    {
                        Nome = "Cinema 2",
                        LogoURL = "https://api.hatchwise.com/api/public/storage/assets/contests/entries/L967851-20140815214900.png",
                        Descricao = "Esta é a descrição do segundo cinema"
                    }
                });
                //salva as alterações na base de dados
                _context.SaveChanges();


                //Ator
                _context.Atores.AddRange(new List<Ator>()
                {
                    new Ator()
                    {
                        Nome = "Ator 1",
                        Biografia = "Esta é a bio do primeiro ator",
                        FotoPerfilURL = "http://t3.gstatic.com/licensed-image?q=tbn:ANd9GcQdRYyKKa7wCfj2i_S6EUvpNu0-56RlqkXptw3HYs8mAxjaw-j0wnU265bFvCRFQLHv"
                    },
                    new Ator()
                    {
                        Nome = "Ator 2",
                        Biografia = "Esta é a bio do segundo ator",
                        FotoPerfilURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRXzPUhdFrjwEevK7D60mCGWweex4RGc8LSpfc9M2-4J0UNWOVo"
                    },
                    new Ator()
                    {
                        Nome = "Ator 3",
                        Biografia = "Esta é a bio do terceiro ator",
                        FotoPerfilURL = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSimO6w0Cd3ljSmsHCzH-RSl13g3Jt5IlQ1NiSZRyiGUAxKw5rm"
                    },
                    new Ator()
                    {
                        Nome = "Ator 4",
                        Biografia = "Esta é a bio do quarto ator",
                        FotoPerfilURL = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcR0jbiRvU4V5cbwuzBhffHvcQMJ61C6JtMwEJRNrfEoolRmnQnu"
                    }
                });
                //salva as alterações na base de dados
                _context.SaveChanges();


                //Diretor
                _context.Diretores.AddRange(new List<Diretor>()
                {
                    new Diretor()
                    {
                        Nome = "Diretor 1",
                        Biografia = "Esta é a bio do primeiro diretor",
                        FotoPerfilURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNbZf9bzSjQhCZKXVuQYTNoIiAuiE2qsN8NWk5aTq6d1faV0su"
                    },
                    new Diretor()
                    {
                        Nome = "Diretor 2",
                        Biografia = "Esta é a bio do segundo diretor",
                        FotoPerfilURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxlTrJvdxqSMBYf90USQe0qXEaMhXdy35FJOpUlEZ5PGl4wIBI"
                    }
                });
                //salva as alterações na base de dados
                _context.SaveChanges();


                //Filme
                List<int> cinemas_id = new List<int>();
                foreach (var cinema in _context.Cinemas)
                {
                    cinemas_id.Add(cinema.Id);
                }

                List<int> diretores_id = new List<int>();
                foreach (var diretor in _context.Diretores)
                {
                    diretores_id.Add(diretor.Id);
                }

                _context.Filmes.AddRange(new List<Filme>()
                {
                    new Filme()
                    {
                        Nome = "Avatar: O Caminho da Água",
                        Descricao = "Esta é a descrição do filme",
                        Preco = 6.50,
                        ImagemURL = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTs7NbX_Mutgyh3U30XUFEEXQ1BhaLIb4pPiNpjWBMFVQxILf15",
                        DataInicial = DateTime.Now.AddDays(-10),
                        DataFinal = DateTime.Now.AddDays(10),
                        CinemaId = cinemas_id[0],
                        DiretorId = diretores_id[0],
                        Categoria = Categoria.Aventura
                    },
                    new Filme()
                    {
                        Nome = "Os Oito Odiados",
                        Descricao = "Esta é a descrição do filme",
                        Preco = 4.50,
                        ImagemURL = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRKmmFpI8YNxfVpPfhs8TqNWBbZnjM30xwoTQkqHYNBAWfMvESj",
                        DataInicial = DateTime.Now,
                        DataFinal = DateTime.Now.AddDays(30),
                        CinemaId = cinemas_id[1],
                        DiretorId = cinemas_id[1],
                        Categoria = Categoria.Faroeste
                    }
                });
                //salva as alterações na base de dados
                _context.SaveChanges();


                //Ator_Filme
                List<int> atores_id = new List<int>();
                foreach (var ator in _context.Atores)
                {
                    atores_id.Add(ator.Id);
                }

                List<int> filmes_id = new List<int>();
                foreach (var filme in _context.Filmes)
                {
                    filmes_id.Add(filme.Id);
                }

                _context.Atores_Filmes.AddRange(new List<Ator_Filme>()
                {
                    new Ator_Filme()
                    {
                        AtorId = atores_id[0],
                        FilmeId = filmes_id[0]
                    },
                    new Ator_Filme()
                    {
                        AtorId = atores_id[1],
                        FilmeId = filmes_id[0]
                    },
                    new Ator_Filme()
                    {
                        AtorId = atores_id[2],
                        FilmeId = filmes_id[1]
                    },
                    new Ator_Filme()
                    {
                        AtorId = atores_id[3],
                        FilmeId = filmes_id[1]
                    }
                });
                //salva as alterações na base de dados
                _context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Utilizador>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Utilizador()
                    {
                        Nome = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "@Admin123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Utilizador()
                    {
                        Nome = "User",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "@User123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
