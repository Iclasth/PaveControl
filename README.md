# 🍮 PaveControl - Sistema de Gestão de Pavês

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core%208.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Azure](https://img.shields.io/badge/Azure-0089D6?style=for-the-badge&logo=microsoftazure&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

O **PaveControl** é uma aplicação web completa desenvolvida para o gerenciamento de inventário e vendas de pavês artesanais. O projeto foi desenhado seguindo as melhores práticas da arquitetura MVC, com foco em escalabilidade e deploy em nuvem.

![PaveControl: Home em funcionamento](img/PaveControlScreenshot.png)

---

## 🚀 Status do Projeto: Em Produção
A aplicação está hospedada na Azure e pode ser acessada em:  
🔗 [https://pavecontrol-iclas.azurewebsites.net/](https://pavecontrol-iclas-bec0fndshxh5byak.canadacentral-01.azurewebsites.net/) *(Ajuste se o link for diferente)*

---

## 🛠 Tecnologias e Ferramentas

* **Backend:** C# com ASP.NET Core MVC.
* **ORM:** Entity Framework Core (Code First).
* **Banco de Dados:** Azure SQL Database.
* **Frontend:** Razor Pages, HTML5, CSS3, Bootstrap e JavaScript.
* **Infraestrutura/Cloud:** * **Azure App Service** para hospedagem da aplicação.
    * **Managed Identity** para autenticação segura entre serviços (sem senhas expostas).
    * **Azure SQL Server** para persistência de dados.

---

## 🏗 Arquitetura e Funcionalidades

O projeto implementa um CRUD completo e foca em segurança e performance:

- **Migrations:** Controle de versão do banco de dados via EF Core.
- **Autenticação Segura:** Implementação de Identidade Gerenciada no Azure para comunicação site-banco.
- **Responsividade:** Interface adaptada para dispositivos móveis e desktops.
- **Configurações de Ambiente:** Separação clara entre ambientes de `Development` e `Production`.

---

## 📦 Como rodar o projeto localmente

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/seu-usuario/pave-control.git](https://github.com/seu-usuario/pave-control.git)

```

2. **Configure a Connection String:**
No arquivo `appsettings.Development.json`, insira sua string de conexão para o LocalDB ou SQL Server local.
3. **Execute as Migrations:**
No Console do Gerenciador de Pacotes do Visual Studio:
```powershell
Update-Database

```


4. **Inicie a aplicação:**
Aperte `F5` no Visual Studio.

---

## 🛡 Diferenciais Técnicos (O que aprendi)

Neste projeto, superei desafios reais de infraestrutura de nuvem, incluindo:

* Configuração de **Firewall do Azure SQL**.
* Resolução de problemas de **autenticação via tokens** entre serviços PaaS.
* Implementação de rotinas automáticas de migração de banco de dados via código no `Program.cs`.

```

---

### 💡 Dicas de Ouro para o GitHub:

1.  **Screenshots:** Tire 2 ou 3 fotos do sistema funcionando (uma da home e uma do cadastro) e coloque uma pasta chamada `img` no seu repositório. Use o comando `![Descrição](img/foto.png)` no README para exibi-las. Recrutadores **amam** ver o visual antes de ler o código.
2.  **GIF de Demonstração:** Se puder, use uma ferramenta como *ScreenToGif* para gravar 10 segundos de você cadastrando um pavê e coloque no README. Isso prova que o sistema funciona de ponta a ponta.
3.  **About (Sobre):** No lado direito do seu repositório no GitHub, preencha a descrição, coloque as *tags* (dotnet, csharp, azure, mvc) e o link do site da Azure que agora está funcionando!



**Gostaria que eu fizesse alguma alteração ou adicionasse alguma seção específica sobre os desafios que tivemos com a autenticação da Azure?** Isso demonstraria muita maturidade técnica!

```
