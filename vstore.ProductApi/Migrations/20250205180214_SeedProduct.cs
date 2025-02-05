using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vstore.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, CategoryId) VALUES" +
                    "('Luva de Boxe Profissional', 'Luva de couro sintético para treinamento e competição', 299.90, 'luva-boxe.jpg', 50, 1)," +
                    "('Kimono de Jiu-Jitsu', 'Kimono competição Shoyoroll, tecido premium', 549.99, 'kimono-jiu-jitsu.jpg', 30, 1)," +
                    "('Protetor de Cabeça', 'Capacete para treino de artes marciais, proteção máxima', 189.50, 'protetor-cabeça.jpg', 25, 1)," +
                    "('Saco de Pancada 120cm', 'Saco de treino profissional, couro sintético', 449.00, 'saco-pancada.jpg', 15, 1)," +
                    "('Bandagem de Boxe', 'Bandagem elástica profissional, 4,5 metros', 29.90, 'bandagem.jpg', 100, 1);");
            
            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, CategoryId) VALUES" +
                    "('Barraca 4 Pessoas', 'Barraca impermeável para camping, montagem rápida', 599.99, 'barraca-4p.jpg', 20, 2)," + 
                    "('Saco de Dormir Térmico', 'Saco de dormir para temperaturas até -5°C', 349.90, 'saco-dormir.jpg', 35, 2)," + 
                    "('Fogareiro Portátil', 'Fogareiro compacto para camping, uso em alta montanha', 189.50, 'fogareiro.jpg', 40, 2)," + 
                    "('Mochila Cargueira 60L', 'Mochila de trekking com sistema de ventilação', 449.00, 'mochila-cargueira.jpg', 25, 2)," + 
                    "('Kit Talheres Camping', 'Conjunto de talheres dobráveis em aço inox', 79.90, 'kit-talheres.jpg', 50, 2);");
            
            mb.Sql("INSERT INTO Products (Name, Description, Price, ImageUrl, Stock, CategoryId) VALUES" + 
                    "('Prancha de Surf', 'Prancha performance, fibra de vidro', 1299.90, 'prancha-surf.jpg', 10, 3)," + 
                    "('Máscara de Mergulho', 'Máscara profissional, vidro temperado', 249.50, 'mascara-mergulho.jpg', 30, 3)," + 
                    "('Colete Salva-Vidas', 'Colete aprovado pela Marinha, tamanho único', 199.99, 'colete-salva-vidas.jpg', 25, 3)," + 
                    "('Nadadeira de Mergulho', 'Nadadeira profissional, borracha premium', 299.00, 'nadadeira.jpg', 40, 3)," + 
                    "('Roupa de Neoprene', 'Roupa completa para mergulho, 3mm de espessura', 599.90, 'roupa-neoprene.jpg', 15, 3);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
