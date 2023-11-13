using DevIO.App.Data;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using DevIO.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevIO.App.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<MeuDbContext>();
            var contextId = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.MigrateAsync();
                await contextId.Database.MigrateAsync(); 

                await EnsureSeedProducts(context, contextId);
            }
        }

        private static async Task EnsureSeedProducts(MeuDbContext context, ApplicationDbContext contextId)
        {
            if (context.Fornecedores.Any())
                return;

            var idFornecedor = Guid.NewGuid();

            await context.Fornecedores.AddAsync(new Fornecedor() { 
                Id = idFornecedor,
                Nome = "Fornecedor Teste", 
                Documento = "49445522389",
                TipoFornecedor = TipoFornecedor.PessoaFisica,
                Ativo = true,
                Endereco = new Endereco() 
                {
                   Logradouro = "Rua Teste",
                   Numero = "123",
                   Complemento = "Complemento",
                   Bairro = "Teste",
                   Cep = "03180000",
                   Cidade = "São Paulo",
                   Estado = "SP"
                }
            });

            await context.SaveChangesAsync();

            if (context.Produtos.Any())
                return;

            await context.Produtos.AddAsync(new Produto() { Nome = "Livro CSS",    Valor = 50,  Descricao = "Teste",
            Ativo = true, DataCadastro = DateTime.Now, FornecedorId = idFornecedor});

            await context.Produtos.AddAsync(new Produto() { Nome = "Livro jQuery", Valor = 150, Descricao = "Teste",
            Ativo = true, DataCadastro = DateTime.Now, FornecedorId = idFornecedor});
            
            await context.Produtos.AddAsync(new Produto() { Nome = "Livro HTML",   Valor = 90,  Descricao = "Teste",
            Ativo = true, DataCadastro = DateTime.Now, FornecedorId = idFornecedor});
            
            await context.Produtos.AddAsync(new Produto() { Nome = "Livro Razor", Valor = 50,  Descricao = "Teste", 
            Ativo = true, DataCadastro = DateTime.Now, FornecedorId = idFornecedor});

            await context.SaveChangesAsync();

            if (contextId.Users.Any())
                return;

            await contextId.Users.AddAsync(new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "teste@teste.com",
                NormalizedUserName = "TESTE@TESTE.COM",
                Email = "teste@teste.com",
                NormalizedEmail = "TESTE@TESTE.COM",
                AccessFailedCount = 0,
                LockoutEnabled = false,
                PasswordHash = "AQAAAAIAAYagAAAAEEdWhqiCwW/jZz0hEM7aNjok7IxniahnxKxxO5zsx2TvWs4ht1FUDnYofR8JKsA5UA==",
                TwoFactorEnabled = false,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            });

            await contextId.SaveChangesAsync();
        }
    }
}
