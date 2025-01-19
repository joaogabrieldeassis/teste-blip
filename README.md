**Projeto de Chatbot com Blip** <br>
Este projeto é uma API intermediária entre o Blip e a API do GitHub. A API foi desenvolvida com foco em boas práticas de desenvolvimento, seguindo os princípios de Clean Code, Clean Architecture e SOLID. Além disso, o projeto está containerizado utilizando Docker para facilitar a implantação e execução.

Foi criada uma esteira de pipeline utilizando o GitHub Actions. A API está hospedada na AWS, utilizando o serviço App Runner e o ECR da AWS.

A aplicação se encontra no ar na URL: https://ehmbfmswx2.us-east-1.awsapprunner.com/swagger/index.html

Após abrir a URL, será possível ver o método para obter os repositórios mais antigos do GitHub (https://github.com/takenet), ordenados do mais antigo para o mais novo.

Para executar o projeto:<br>
Digite **cd Api** na pasta do projeto.
Digite o comando docker build -t bliapi .
Execute o contêiner:
docker run -d -p 8080:8080 bliapi
