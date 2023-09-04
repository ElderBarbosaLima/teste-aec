# teste-aec
Teste de habilidades para a vaga dotnet
Observações:
1. O projeto foi desenvolvido utilizando o framework mais recente .NET 7
2. O banco utiliza um banco sql server local para armazenar as informacões requisitadas
3. Para criar o banco de dados basta executar o comando  dotnet ef database update
4. Foi identificado um bug na api Brasil api. Quando se busca o clima pelo nome da cidade completo ex: Belo Horizonte e a api encotnra apenas um registro, é retornado um erro. Foi aberta uma isse no projeto Brasil api, que até o momento estava sendo resolvida. Link da issue: https://github.com/BrasilAPI/BrasilAPI/issues/514
5. O projeto poderia ter várias melhorias e adição de testes, que foram deixados de lado, pois este final de semana tive alguns contratempos, o que não me permitiu dedicar o tempo que eu desejava.
6. Todos os pontos requisitados pelo e-mail foram atendidos:
Seguem as instruções:
7. Foi utilizado o SDK dotnet disponível da api. Preferi esta abordagem para deixar o projeto o mais limpo possível. Seria possível implementar a chamada da api via HttpClient utilizando uma factory para a a chamada da api. O que é o mesmo que o SDk faz.
 

# Developer challenge

*      Sua tarefa é fazer uma API (RestFull) que consuma dados da Brasil API ( https://brasilapi.com.br/docs ), que retornará um determinado clima para uma cidade ou aeroporto informada na rota da API, que mostre no console os dados a cada requisição realizada.

Sendo assim, certifique-se que:

*      1. Tenha ao menos uma rota para o clima da cidade;

*      2. Tenha ao menos uma rota para o clima do aeroporto;

*      3. Persista esses dados no Sql Server a cada requisição;

*      4. Salvar logs no Sql Server caso aconteça algum erro de processamento de dados.
