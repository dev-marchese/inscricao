1. Decisão da Arquitetura Utilizada
Para o desenvolvimento deste projeto, utilizei ASP.NET Core 8 e MySQL, adotando uma arquitetura em camadas. Essa abordagem separa as responsabilidades, criando um maior desacoplamento entre as camadas e garantindo uma manutenção mais simples, além de facilitar expansões futuras, como a inclusão de outras camadas de UI.
As camadas utilizadas foram:
•	UI: A camada de frontend foi implementada utilizando Vue.js em conjunto com o Razor.
•	BUSINESS: Responsável pela lógica de negócios, garantindo que as regras, tratamentos e validações de dados do negócio não se misturem com as camadas de acesso a dados (DATA) ou UI. Isso torna o código mais reutilizável e facilita a manutenção.
•	DATA: Camada de acesso a dados, totalmente desacoplada do restante da aplicação. Todo o acesso ao banco de dados, como consultas, inserções e execução de procedures, foi feito utilizando o Entity Framework Core.
•	DTO: A camada DTO representa as tabelas do banco de dados por meio de classes. Além disso, podem ser feitas validações utilizando data annotations. Neste projeto, utilizei validações e especificações para as propriedades das tabelas através do Fluent.
•	A aplicação também utiliza injeção de dependências, facilitando o gerenciamento de serviços como o DbContext, promovendo uma arquitetura mais modular e desacoplada.

2. IDEs Utilizadas
•	Visual Studio 2022: Utilizado para o desenvolvimento da aplicação.
•	MySQL Workbench: Utilizado para acesso e gerenciamento do banco de dados.

3. Lista de Bibliotecas de Terceiros Utilizadas
•	Entity Framework Core: Utilizado para mapear as entidades do projeto e realizar operações no banco de dados, utilizando o padrão ORM.
•	MySqlConnector: Utilizado para conectar a aplicação ao banco de dados MySQL.
•	Vue.js: Utilizado no frontend em conjunto com o Razor.
•	Bootstrap: Utilizado para estilização e responsividade, garantindo uma melhor experiência do usuário.
•	jQuery: Utilizado para manipulação de DOM e para facilitar o envio de requisições com a Fetch API.
•	Bundler & Minifier: Utilizado para minificar e transpilar arquivos .js.
•	WebCompiler: Utilizado para minificar e transpilar arquivos .scss.
4. O que Você Melhoraria se Tivesse Mais Tempo
Com mais tempo, algumas melhorias poderiam ser implementadas:
•	Melhoria na UI/UX: Mais tempo poderia ser dedicado ao design e usabilidade da aplicação, melhorando a disposição dos elementos, inserindo notificações amigáveis ao usuário e ajustando os layouts para maior responsividade.
•	Paginação em listagens: Implementar paginação nas listagens de alunos para evitar a sobrecarga de carregar todos os dados de uma vez seria uma boa prática.
•	Integração com autenticação: Embora o escopo atual não exija autenticação, a implementação desse recurso protegeria áreas sensíveis da aplicação, como o gerenciamento de matrículas e cursos.
•	Criptografia de parâmetros na URL.
•	Validação do CPF inserido.

5. Requisitos Obrigatórios que Não Foram Entregues
Após a conclusão do projeto, alguns requisitos não foram atendidos conforme solicitado:
•	Testes automatizados: A implementação de testes unitários e de integração seria essencial para garantir a qualidade e robustez da aplicação.
•	Mensagens de erro personalizadas: A aplicação exibe mensagens de erro genéricas em alguns casos. Personalizar essas mensagens para o usuário final seria importante.
•	Mensagens de confirmação para ações como DELETE.

