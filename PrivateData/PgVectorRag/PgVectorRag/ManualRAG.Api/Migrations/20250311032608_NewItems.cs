using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManualRAG.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chunks",
                columns: new[] { "Id", "Embedding", "Text" },
                values: new object[,]
                {
                    { new Guid("76df75e8-f4c0-4deb-b814-16470f992859"), null, "A Sociedade do Anel: O jovem hobbit Frodo Bolseiro herda o Um Anel de seu tio Bilbo e descobre que ele pertence ao Senhor do Escuro, Sauron. Com seus amigos Sam, Merry e Pippin, ele parte do Condado para destruir o anel em Mordor. No caminho, encontra Aragorn e forma a Sociedade do Anel com Gandalf, Legolas, Gimli e Boromir. Eles enfrentam perigos como os Nazgûl, Saruman e as minas de Moria. Após a morte de Boromir e a separação do grupo, Frodo e Sam seguem sozinhos para Mordor, guiados pelo traiçoeiro Gollum." },
                    { new Guid("9d3f82b0-c8bf-49af-8e86-021a976c96e1"), null, "As Duas Torres: A Sociedade do Anel se divide. Frodo e Sam continuam sua jornada para Mordor, enquanto Aragorn, Legolas e Gimli perseguem os orcs que capturaram Merry e Pippin. Os hobbits escapam e encontram Barbárvore, que lidera um ataque dos ents contra Saruman. Gandalf retorna como o Branco e ajuda Rohan a resistir à ameaça de Saruman na batalha do Abismo de Helm. Frodo e Sam, com Gollum como guia, enfrentam desafios e traições, culminando na emboscada de Shelob. Frodo é capturado pelos orcs, deixando Sam com a responsabilidade de salvá-lo e continuar a missão." },
                    { new Guid("c2807969-52fe-4dcd-b2ae-b6be754d6d50"), null, "O Retorno do Rei: Sauron lança um ataque devastador a Gondor. Aragorn, com a ajuda do exército dos mortos, reforça as forças da cidade e lidera a batalha nos Campos de Pelennor. Frodo e Sam, desgastados, alcançam a Montanha da Perdição, onde Gollum rouba o anel e cai na lava, destruindo-o. Sauron é derrotado, e Aragorn assume o trono de Gondor. Os heróis retornam ao Condado, encontrando-o sob o domínio de Saruman. Após restaurar a paz, Frodo, ferido pelas dificuldades da jornada, parte para Valinor com Bilbo, Gandalf e os elfos, deixando seu legado para trás." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chunks",
                keyColumn: "Id",
                keyValue: new Guid("76df75e8-f4c0-4deb-b814-16470f992859"));

            migrationBuilder.DeleteData(
                table: "Chunks",
                keyColumn: "Id",
                keyValue: new Guid("9d3f82b0-c8bf-49af-8e86-021a976c96e1"));

            migrationBuilder.DeleteData(
                table: "Chunks",
                keyColumn: "Id",
                keyValue: new Guid("c2807969-52fe-4dcd-b2ae-b6be754d6d50"));
        }
    }
}
