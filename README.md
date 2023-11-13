# Obtendo o Usuário do Identity em Qualquer Camada da Arquitetura

## Introdução
Este repositório é um guia sobre como obter informações do usuário do Identity (logado) em qualquer camada da arquitetura de um projeto ASP.NET Core. Implementamos uma interface de abstração que permite acessar dados do usuário de forma limpa e eficiente, sem depender diretamente do ASP.NET Core Identity ou da infraestrutura.

## Desafio
Acessar informações do usuário do Identity em diferentes camadas de uma aplicação, como lógica de negócios ou acesso a dados, pode ser desafiador. Isso geralmente requer dependências diretas do ASP.NET Core Identity, o que pode levar a um acoplamento indesejado e dificuldades de teste.

## Solução Proposta
Nossa solução envolve a criação de uma interface de abstração que encapsula a lógica de obter dados do usuário. Essa abordagem permite que diferentes camadas da aplicação acessem informações do usuário sem depender diretamente do Identity ou de detalhes específicos da infraestrutura.

## Implementação
A implementação consiste em:

1. **Definição da Interface:** Criamos uma interface que define os métodos necessários para obter dados do usuário.
2. **Serviço de Abstração:** Implementamos um serviço que concretiza esta interface, utilizando os serviços do Identity para obter os dados do usuário.
3. **Injeção de Dependência:** Configuramos a injeção de dependência para usar nossa interface abstrata em toda a aplicação, garantindo a desacoplagem do Identity.
4. **Implementação Abstrata** Acesse o usuário de qualquer controller chamando apenas pela propriedade herdada da BaseController

## Vantagens
- **Desacoplamento:** Reduz a dependência direta do ASP.NET Core Identity, permitindo maior flexibilidade e testabilidade.
- **Reusabilidade:** Facilita a reutilização do código em diferentes camadas da aplicação.
- **Manutenção Simplificada:** Centraliza a lógica de acesso aos dados do usuário, facilitando mudanças e manutenção.
- **Facilita Futuras Implamentações** Como por exemplo controlar o acesso a dados, exibindo apenas dados que pertencem ao usuário logado. Realizar log de auditoria de ações importantes do usuário.

## Como Utilizar Este Repositório
Siga os passos abaixo para entender e aplicar este método:

1. **Configuração do Ambiente:** Certifique-se de ter o .NET Core SDK e o EF Core instalados.
2. **Clonar o Repositório:** Clone este repositório para sua máquina local.
3. **Explorar o Código:** Abra o projeto no seu IDE favorito e explore a estrutura e implementação.
4. **Executar o Projeto:** Execute o Build e observe o comportamento do projeto conforme o vídeo do conteúdo PLUS.
