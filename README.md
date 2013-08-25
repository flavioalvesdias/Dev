Dev
===
Custom ASP.NET Identity Membership
Custom Asp.net Identity Membership
Asp.net Identity é o novo sistema Membership para construção de aplicações Asp.net. Com este novo recurso, é possível facilmente gerenciar acesso às aplicações, seja através de um controle local, usando o SQL Server ou outro gerenciador de dados ou até mesmo através de outras formas de autenticação, como pelo Google, Facebook, Twiter e contas Microsoft.
A utilização deste recurso é bastante simples, basta criar uma aplicação MVC como por exemplo, que o recurso já estará pronto para o uso. Este recurso apenas está presente na versão Preview do Visual Studio 2013. Você também pode facilmente usar o seu próprio banco de dados ao invés do banco default que é gerado quando é criado o projeto. O próprio time de desenvolvimento do Asp.Net Entity, disponibilizou uma versão customizada como exemplo, para mostrar o quanto é simples customizar a aplicação para que funcione como queira.

Segue link do exemplo: https://github.com/rustd/AspnetIdentitySample

Indrodução ao Asp.net Identity: 
http://blogs.msdn.com/b/webdev/archive/2013/06/27/introducing-asp-net-identity-membership-system-for-asp-net-applications.aspx.

Estou disponibilizando um exemplo onde estão contidos três projetos, um para criação do banco de dados, onde utilizo o Migrations para criação e atualização, outro projeto que será a aplicação principal do sistema, e por fim, um simples projeto que irá rodar dentro do Content da aplicação principal, para exemplificar o conceito de modularização.
Optei por este exemplo, pois é uma forma de modularizar sua aplicação, diminuindo o acoplamento.  Os projetos serão os seguintes:

MaintenanceDB - Projeto onde serão criadas todas as classes de modelo da aplicação;

AppMain: Aplicação principal, repositório para as demais aplicações;

HelloWord: Uma aplicação que será executada dentro da AppMain. Para abrir a aplicação HelloWord dentro do content da aplicação AppMain, estarei usando o RazorGenerator. Para quem não conhece o RazorGenerator, existe um post no blog tratando o tema de modularização.
Segue link para download da versão para VS2013 do RazorGenerator: RazorGenerator.
