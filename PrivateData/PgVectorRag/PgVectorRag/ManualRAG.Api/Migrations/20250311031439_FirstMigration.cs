using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Pgvector;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManualRAG.Api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.CreateTable(
                name: "Chunks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Embedding = table.Column<Vector>(type: "vector(1536)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chunks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Chunks",
                columns: new[] { "Id", "Embedding", "Text" },
                values: new object[,]
                {
                    { new Guid("14c1c655-72be-48d0-bcfb-140fa9f7fe12"), null, "Os Aplicativos de Contêiner do Azure são uma plataforma sem servidor que permite manter menos infraestrutura e economizar custos ao executar aplicativos em contêineres. Em vez de se preocupar com a configuração do servidor, a orquestração de contêineres e os detalhes da implantação, os Aplicativos de Contêiner fornecem todos os recursos de servidor atualizados necessários para manter seus aplicativos estáveis e seguros.\n\nOs tipos de uso comuns dos Aplicativos de Contêiner do Azure incluem:\n\nImplantação de pontos de extremidade de API\nHospedagem de trabalhos de processamento em segundo plano\nManipulação de processamento controlado por eventos\nExecução de microsserviços" },
                    { new Guid("19085bb9-7038-4c10-a2e9-027f506360a3"), null, "Os aplicativos baseados nos Aplicativos de Contêiner do Azure podem escalar dinamicamente de acordo com as seguintes características:\n\nTráfego HTTP\nProcessamento controlado por eventos\nCarga de CPU ou de memória\nQualquer dimensionador KEDA com suporte" },
                    { new Guid("35cb9b12-85a8-46f4-86be-12e05778bef3"), null, "Ele se baseia na última versão estável do mecanismo de banco de dados do Microsoft SQL Server. É possível usar recursos avançados de processamento de consulta, como tecnologias de alto desempenho na memória e processamento inteligente de consulta. Na verdade, os recursos mais recentes do SQL Server são liberados primeiro no Banco de Dados SQL do Azure e, em seguida, no próprio SQL Server. Você recebe as funcionalidades mais recentes do SQL Server sem a sobrecarga de aplicar patches ou atualizar, testados em milhões de bancos de dados." },
                    { new Guid("6b406924-35df-452c-b306-1d91fc98fe81"), null, "Camadas de serviço\nO modelo de compra baseado em vCore oferece três camadas de serviço:\n\nA camada de serviço Uso geral foi projetada para cargas de trabalho comuns. Oferece opções equilibradas de computação e armazenamento orientadas ao orçamento.\nA camada de serviço Comercialmente Crítico foi projetada para aplicativos OLTP com altas taxas de transação e requisitos de E/S de baixa latência. Oferece maior resiliência a falhas usando várias réplicas isoladas.\nA camada de serviço Hiperescala foi projetada para a maioria das cargas de trabalho de negócios. Hiperescala fornece excelente flexibilidade e alto desempenho com recursos de computação e armazenamento escalonáveis de maneira independente. Ela oferece maior resiliência a falhas, permitindo configurar mais de uma réplica de banco de dados isolada.\nO modelo de compra baseado em DTU oferece duas camadas de serviço:\n\nA camada de serviço Standard foi projetada para cargas de trabalho comuns. Oferece opções equilibradas de computação e armazenamento orientadas ao orçamento.\nA camada de serviço Premium foi projetada para aplicativos OLTP com altas taxas de transação e requisitos de E/S de baixa latência. Oferece maior resiliência a falhas usando várias réplicas isoladas." },
                    { new Guid("c4f49049-7731-4400-bcbd-afa977185c2b"), null, "O Banco de Dados SQL permite definir e escalar facilmente o desempenho dinamicamente escalonável em dois modelos de compra diferentes: um modelo de compra baseado em vCore e um modelo de compra baseado em DTU. O Banco de Dados SQL é um serviço totalmente gerenciado que tem alta disponibilidade interna, backups e outras operações de manutenção comuns. A Microsoft trata de todas as correções e atualizações do código do sistema operacional e do SQL. Não é preciso gerenciar a infraestrutura subjacente." },
                    { new Guid("e3e8e383-e69e-4c2d-94e6-d7e2a59d714d"), null, "O Banco de Dados SQL do Azure está sempre sendo executado na versão estável mais recente do mecanismo de banco de dados do SQL Server e no SO corrigido com 99,99% de disponibilidade. Os recursos de PaaS integrados ao Banco de Dados SQL do Azure permitem que você se concentre nas atividades de administração e otimização de bancos de dados específicas do domínio que são críticas para sua empresa. Com o Banco de Dados SQL do Azure, você pode criar uma camada de armazenamento de dados altamente disponível e de alto desempenho para aplicativos e soluções no Azure. O Banco de Dados SQL do Azure pode ser a escolha certa para uma série de aplicativos de nuvem modernos porque permite processar dados relacionais e estruturas não relacionais, como grafos, JSON, espacial e XML. " },
                    { new Guid("ed01fe5d-aff9-4f49-8b39-acc86e7bcef5"), null, "Modelos de compra\nO Banco de Dados SQL do Azure oferece os seguintes modelos de compra:\nO modelo de compra baseado em vCore permite que você escolha o número de vCores, a quantidade ou memória e a quantidade e velocidade de armazenamento. O modelo de compra baseado em vCore também permite usar o Benefício Híbrido do Azure para SQL Server a fim de obter economia de custos utilizando suas licenças existentes do SQL Server.\nO modelo de compra baseado em DTU oferece uma mistura de computação, memória e recursos de E/S em três camadas de serviço para dar suporte a cargas de trabalho leves e pesadas de banco de dados. Os tamanhos da computação dentro de cada camada fornecem uma mistura diferente desses recursos, aos quais você pode adicionar recursos de armazenamento." },
                    { new Guid("fbf25a61-2e6d-478d-ab7f-ea061d336464"), null, "Recursos\nCom os Aplicativos de Contêiner do Azure, você pode:\n\nUsar a extensão da CLI do Azure, o portal do Azure ou os modelos do ARM para gerenciar os aplicativos.\n\nHabilitar a entrada de HTTPS ou TCP sem precisar gerenciar outra infraestrutura do Azure.\n\nCriar microsserviços com o Dapr e acessar o rico conjunto de APIs que ele oferece.\n\nExecute trabalhos sob demanda, em um agendamento ou com base nos eventos.\n\nAdicione Azure Functions e Aplicativos Spring do Azure ao seu ambiente de Aplicativos de Contêiner do Azure.\n\nUse hardware especializado para ter acesso a mais recursos de computação.\n\nExecutar várias revisões de contêiner e gerenciar o ciclo de vida do aplicativo de contêiner.\n\nDimensionar automaticamente os aplicativos com base em qualquer gatilho de escala com suporte do KEDA. A maioria dos aplicativos pode ser dimensionada para zero1.\n\nDividir o tráfego entre várias versões de um aplicativo para implantações azuis/verdes e cenários de teste A/B.\n\nUsar a entrada interna e a descoberta de serviço para pontos de extremidade somente internos seguros com a descoberta de serviço interna baseada em DNS.\n\nExecutar contêineres de qualquer registro, público ou privado, incluindo o Docker Hub e o ACR (Registro de Contêiner do Azure).\n\nFornecer uma rede virtual existente ao criar um ambiente para os aplicativos de contêiner.\n\nGerenciar os segredos com segurança diretamente no aplicativo.\n\nMonitorar logs usando o Azure Log Analytics.\n\nCotas generosas que podem ser superadas para aumentar os limites por conta.\n\n1 Os aplicativos que são dimensionados de acordo com a carga de CPU ou de memória não podem ser dimensionados para zero.\n" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chunks_Embedding",
                table: "Chunks",
                column: "Embedding")
                .Annotation("Npgsql:IndexMethod", "hnsw")
                .Annotation("Npgsql:IndexOperators", new[] { "vector_cosine_ops" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chunks");
        }
    }
}
