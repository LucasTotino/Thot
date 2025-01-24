using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Thot.Models;

namespace Thot.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel>? Clientes { get; set; }
        public DbSet<UsuarioModel>? Usuarios { get; set; }
        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<FornecedorModel>? Fornecedores { get; set; }
    }
}
