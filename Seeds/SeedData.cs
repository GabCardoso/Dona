using Dona.Data;
using Dona.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Sensors.Seeds
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SQLiteDBContext>();
            context.Database.EnsureCreated();
            if (!context.Usuarias.Any())
            {
                context.Usuarias.AddRange(
                    new Usuaria
                    {
                        Id = 1,
                        Nome = "Ana Maria Silva",
                        Email = "anamariasilva@gmail.com",
                        Senha = "12345678",
                        Profissao = "Programadora",
                        Telefone = "21987456254",
                        Uf = "RJ"
                    },
                     new Usuaria
                     {
                         Id = 2,
                         Nome = "Maria de Souza",
                         Email = "mariasouza@gmail.com",
                         Senha = "12345678",
                         Profissao = "Analista",
                         Telefone = "21987456254",
                         Uf = "SP"
                     },
                    new Usuaria
                    {
                        Id = 3,
                        Nome = "Luiza Fernandes",
                        Email = "luizafernandes@gmail.com",
                        Senha = "12345678",
                        Profissao = "Gerente",
                        Telefone = "21987456254",
                        Uf = "RJ"
                    },
                    new Usuaria
                    {
                        Id = 4,
                        Nome = "Alice Rocha",
                        Email = "alicerocha@gmail.com",
                        Senha = "12345678",
                        Profissao = "Programadora",
                        Telefone = "21987456254",
                        Uf = "PR"
                    },
                    new Usuaria
                    {
                        Id = 5,
                        Nome = "Ana Maria",
                        Email = "anamaria@gmail.com",
                        Senha = "12345678",
                        Profissao = "Programadora",
                        Telefone = "21987456254",
                        Uf = "RJ"
                    },
                    new Usuaria
                    {
                        Id = 6,
                        Nome = "Julia Martins",
                        Email = "juliamartins@gmail.com",
                        Senha = "12345678",
                        Profissao = "Ux Designer",
                        Telefone = "21987456254",
                        Uf = "MG"
                    },
                    new Usuaria
                    {
                        Id = 7,
                        Nome = "Dulce Maria Reis",
                        Email = "dulcemariareis@gmail.com",
                        Senha = "12345678",
                        Profissao = "Designer",
                        Telefone = "21987456254",
                        Uf = "RJ"
                    },
                    new Usuaria
                    {
                        Id = 8,
                        Nome = "Mariana Mendes",
                        Email = "marianamendes@gmail.com",
                        Senha = "12345678",
                        Profissao = "Engenheira de Civil",
                        Telefone = "21987456254",
                        Uf = "PR"
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
