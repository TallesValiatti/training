using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManualRAG.Api.Models.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Chunk>
{
    public void Configure(EntityTypeBuilder<Chunk> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Text);
        
        builder.Property(x => x.Embedding)
            .HasColumnType("vector(1536)");
        
        builder.HasIndex(x => x.Embedding)
            .HasMethod("hnsw")
            .HasOperators("vector_cosine_ops");
        
        builder.HasData( new List<Chunk>()
        {
            // AZURE SQL
            new()
            {
                Id = Guid.Parse("e3e8e383-e69e-4c2d-94e6-d7e2a59d714d"),
                Text = """
                       O Banco de Dados SQL do Azure está sempre sendo executado na versão estável mais recente do mecanismo de banco de dados do SQL Server e no SO corrigido com 99,99% de disponibilidade. Os recursos de PaaS integrados ao Banco de Dados SQL do Azure permitem que você se concentre nas atividades de administração e otimização de bancos de dados específicas do domínio que são críticas para sua empresa. Com o Banco de Dados SQL do Azure, você pode criar uma camada de armazenamento de dados altamente disponível e de alto desempenho para aplicativos e soluções no Azure. O Banco de Dados SQL do Azure pode ser a escolha certa para uma série de aplicativos de nuvem modernos porque permite processar dados relacionais e estruturas não relacionais, como grafos, JSON, espacial e XML. 
                       """
            },
            new()
            {
                Id = Guid.Parse("35cb9b12-85a8-46f4-86be-12e05778bef3"),
                Text = """
                       Ele se baseia na última versão estável do mecanismo de banco de dados do Microsoft SQL Server. É possível usar recursos avançados de processamento de consulta, como tecnologias de alto desempenho na memória e processamento inteligente de consulta. Na verdade, os recursos mais recentes do SQL Server são liberados primeiro no Banco de Dados SQL do Azure e, em seguida, no próprio SQL Server. Você recebe as funcionalidades mais recentes do SQL Server sem a sobrecarga de aplicar patches ou atualizar, testados em milhões de bancos de dados.
                       """
            },
            new()
            {
                Id = Guid.Parse("c4f49049-7731-4400-bcbd-afa977185c2b"),
                Text = """
                       O Banco de Dados SQL permite definir e escalar facilmente o desempenho dinamicamente escalonável em dois modelos de compra diferentes: um modelo de compra baseado em vCore e um modelo de compra baseado em DTU. O Banco de Dados SQL é um serviço totalmente gerenciado que tem alta disponibilidade interna, backups e outras operações de manutenção comuns. A Microsoft trata de todas as correções e atualizações do código do sistema operacional e do SQL. Não é preciso gerenciar a infraestrutura subjacente.
                       """
            },
            new()
            {
                Id = Guid.Parse("ed01fe5d-aff9-4f49-8b39-acc86e7bcef5"),
                Text = """
                       Modelos de compra
                       O Banco de Dados SQL do Azure oferece os seguintes modelos de compra:
                       O modelo de compra baseado em vCore permite que você escolha o número de vCores, a quantidade ou memória e a quantidade e velocidade de armazenamento. O modelo de compra baseado em vCore também permite usar o Benefício Híbrido do Azure para SQL Server a fim de obter economia de custos utilizando suas licenças existentes do SQL Server.
                       O modelo de compra baseado em DTU oferece uma mistura de computação, memória e recursos de E/S em três camadas de serviço para dar suporte a cargas de trabalho leves e pesadas de banco de dados. Os tamanhos da computação dentro de cada camada fornecem uma mistura diferente desses recursos, aos quais você pode adicionar recursos de armazenamento.
                       """
            },
            new ()
            {
                Id = Guid.Parse("6b406924-35df-452c-b306-1d91fc98fe81"),
                Text = """
                       Camadas de serviço
                       O modelo de compra baseado em vCore oferece três camadas de serviço:
                       
                       A camada de serviço Uso geral foi projetada para cargas de trabalho comuns. Oferece opções equilibradas de computação e armazenamento orientadas ao orçamento.
                       A camada de serviço Comercialmente Crítico foi projetada para aplicativos OLTP com altas taxas de transação e requisitos de E/S de baixa latência. Oferece maior resiliência a falhas usando várias réplicas isoladas.
                       A camada de serviço Hiperescala foi projetada para a maioria das cargas de trabalho de negócios. Hiperescala fornece excelente flexibilidade e alto desempenho com recursos de computação e armazenamento escalonáveis de maneira independente. Ela oferece maior resiliência a falhas, permitindo configurar mais de uma réplica de banco de dados isolada.
                       O modelo de compra baseado em DTU oferece duas camadas de serviço:
                       
                       A camada de serviço Standard foi projetada para cargas de trabalho comuns. Oferece opções equilibradas de computação e armazenamento orientadas ao orçamento.
                       A camada de serviço Premium foi projetada para aplicativos OLTP com altas taxas de transação e requisitos de E/S de baixa latência. Oferece maior resiliência a falhas usando várias réplicas isoladas.
                       """
            },
            // AZURE CONTAINER APPS
            new ()
            {
                Id = Guid.Parse("14C1C655-72BE-48D0-BCFB-140FA9F7FE12"),
                Text = """
                       Os Aplicativos de Contêiner do Azure são uma plataforma sem servidor que permite manter menos infraestrutura e economizar custos ao executar aplicativos em contêineres. Em vez de se preocupar com a configuração do servidor, a orquestração de contêineres e os detalhes da implantação, os Aplicativos de Contêiner fornecem todos os recursos de servidor atualizados necessários para manter seus aplicativos estáveis e seguros.
                       
                       Os tipos de uso comuns dos Aplicativos de Contêiner do Azure incluem:
                       
                       Implantação de pontos de extremidade de API
                       Hospedagem de trabalhos de processamento em segundo plano
                       Manipulação de processamento controlado por eventos
                       Execução de microsserviços
                       """
            },
            new ()
            {
                Id = Guid.Parse("19085BB9-7038-4C10-A2E9-027F506360A3"),
                Text = """
                       Os aplicativos baseados nos Aplicativos de Contêiner do Azure podem escalar dinamicamente de acordo com as seguintes características:
                       
                       Tráfego HTTP
                       Processamento controlado por eventos
                       Carga de CPU ou de memória
                       Qualquer dimensionador KEDA com suporte
                       """
            },
            new ()
            {
                Id = Guid.Parse("FBF25A61-2E6D-478D-AB7F-EA061D336464"),
                Text = """
                       Recursos
                       Com os Aplicativos de Contêiner do Azure, você pode:
                       
                       Usar a extensão da CLI do Azure, o portal do Azure ou os modelos do ARM para gerenciar os aplicativos.
                       
                       Habilitar a entrada de HTTPS ou TCP sem precisar gerenciar outra infraestrutura do Azure.
                       
                       Criar microsserviços com o Dapr e acessar o rico conjunto de APIs que ele oferece.
                       
                       Execute trabalhos sob demanda, em um agendamento ou com base nos eventos.
                       
                       Adicione Azure Functions e Aplicativos Spring do Azure ao seu ambiente de Aplicativos de Contêiner do Azure.
                       
                       Use hardware especializado para ter acesso a mais recursos de computação.
                       
                       Executar várias revisões de contêiner e gerenciar o ciclo de vida do aplicativo de contêiner.
                       
                       Dimensionar automaticamente os aplicativos com base em qualquer gatilho de escala com suporte do KEDA. A maioria dos aplicativos pode ser dimensionada para zero1.
                       
                       Dividir o tráfego entre várias versões de um aplicativo para implantações azuis/verdes e cenários de teste A/B.
                       
                       Usar a entrada interna e a descoberta de serviço para pontos de extremidade somente internos seguros com a descoberta de serviço interna baseada em DNS.
                       
                       Executar contêineres de qualquer registro, público ou privado, incluindo o Docker Hub e o ACR (Registro de Contêiner do Azure).
                       
                       Fornecer uma rede virtual existente ao criar um ambiente para os aplicativos de contêiner.
                       
                       Gerenciar os segredos com segurança diretamente no aplicativo.
                       
                       Monitorar logs usando o Azure Log Analytics.
                       
                       Cotas generosas que podem ser superadas para aumentar os limites por conta.
                       
                       1 Os aplicativos que são dimensionados de acordo com a carga de CPU ou de memória não podem ser dimensionados para zero.
                       
                       """
            },
             new ()
            {
                Id = Guid.Parse("76DF75E8-F4C0-4DEB-B814-16470F992859"),
                Text = """
                       A Sociedade do Anel: O jovem hobbit Frodo Bolseiro herda o Um Anel de seu tio Bilbo e descobre que ele pertence ao Senhor do Escuro, Sauron. Com seus amigos Sam, Merry e Pippin, ele parte do Condado para destruir o anel em Mordor. No caminho, encontra Aragorn e forma a Sociedade do Anel com Gandalf, Legolas, Gimli e Boromir. Eles enfrentam perigos como os Nazgûl, Saruman e as minas de Moria. Após a morte de Boromir e a separação do grupo, Frodo e Sam seguem sozinhos para Mordor, guiados pelo traiçoeiro Gollum.
                       """
            },
            new ()
            {
                Id = Guid.Parse("9D3F82B0-C8BF-49AF-8E86-021A976C96E1"),
                Text = """
                       As Duas Torres: A Sociedade do Anel se divide. Frodo e Sam continuam sua jornada para Mordor, enquanto Aragorn, Legolas e Gimli perseguem os orcs que capturaram Merry e Pippin. Os hobbits escapam e encontram Barbárvore, que lidera um ataque dos ents contra Saruman. Gandalf retorna como o Branco e ajuda Rohan a resistir à ameaça de Saruman na batalha do Abismo de Helm. Frodo e Sam, com Gollum como guia, enfrentam desafios e traições, culminando na emboscada de Shelob. Frodo é capturado pelos orcs, deixando Sam com a responsabilidade de salvá-lo e continuar a missão.
                       """
            },
            new ()
            {
                Id = Guid.Parse("C2807969-52FE-4DCD-B2AE-B6BE754D6D50"),
                Text = """
                       O Retorno do Rei: Sauron lança um ataque devastador a Gondor. Aragorn, com a ajuda do exército dos mortos, reforça as forças da cidade e lidera a batalha nos Campos de Pelennor. Frodo e Sam, desgastados, alcançam a Montanha da Perdição, onde Gollum rouba o anel e cai na lava, destruindo-o. Sauron é derrotado, e Aragorn assume o trono de Gondor. Os heróis retornam ao Condado, encontrando-o sob o domínio de Saruman. Após restaurar a paz, Frodo, ferido pelas dificuldades da jornada, parte para Valinor com Bilbo, Gandalf e os elfos, deixando seu legado para trás.
                       """
            },
        });
    }
}