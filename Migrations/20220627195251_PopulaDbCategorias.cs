using Microsoft.EntityFrameworkCore.Migrations;

namespace DESAFIO_MVC.Migrations
{
    public partial class PopulaDbCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome,Imagem,Status) Values('Massas','https://www.tiaozinho.com/arquivo/blog/lasanha-frango.jpg',1)");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome,Imagem,Status) Values('Pratos caseiros','https://s.yimg.com/ny/api/res/1.2/WWAXWu2URUE4rVRU6F5ltg--/YXBwaWQ9aGlnaGxhbmRlcjt3PTY0MDtoPTQyNw--/https://s.yimg.com/os/creatr-uploaded-images/2022-03/9e2778b0-b072-11ec-9fff-7ee45ba8aa30',1)");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome,Imagem,Status) Values('Sobremesas','https://www.dicasdemulher.com.br/wp-content/uploads/2016/02/sobremesas-0.jpg',1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
