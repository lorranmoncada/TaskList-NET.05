# Indice

- [Sobre](#-sobre)
- [Tecnologias Utilizadas](#-tecnologias-utilizadas)
- [Como baixar o projeto](#-como-baixar-o-projeto)

## 🔖&nbsp; Sobre

O projeto **TaskList** é um To Do basicamente criado para organizar suas atividades.
Url da api : https://service-task.herokuapp.com 

---

## 🚀 Tecnologias utilizadas

O projeto foi desenvolvido utilizando as seguintes tecnologias

- [NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)

---

## 🚀 Packages utilizadas

O projeto foi desenvolvido utilizando os seguintes packages

   Camada de **Infraestructure**
-  Microsoft.EntityFrameworkCore.SqlServer
-  Microsoft.EntityFrameworkCore.Tools
-  Microsoft.EntityFrameworkCore
-  Microsoft.EntityFrameworkCore.Design

   **Web Aplication**
-  Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
-  Microsoft.AspNetCore.Mvc.NewtonsoftJson
-  Microsoft.EntityFrameworkCore.SqlServer
-  Microsoft.EntityFrameworkCore.Tools
-  Microsoft.VisualStudio.Azure.Containers.Tools.Targets
-  Swashbuckle.AspNetCore

---

## 🗂 Como baixar o projeto

```bash

    # Clonar o repositório
    $ git clone https://github.com/lorranmoncada/Tasklist-Angular.git

    # Entrar no diretório
    $ cd Tasklist-Angular-main\Tasklist-Angular-main  

    # Instalar as dependências
    $ Clean Solution
    $ Compile Solution

```
---

Observaçõs: 
- O Swagger não esta exibindo todos os campos necessários para o request, se achar necessário podera visualizar o codigo fonte. Ainda será analisado o problema com o Swagger.
- Não foi utilizado ViewModel na aplicação pois todas as pages do front utilizariam os mesmos dados da minha Model, mas se fosse necessário a utilização de Viewmodels eu criaria uma pasta de ViewModel na camada de application e utilizaria o Pacakge AutoMapper para mapegar minha Domain Model para a minha Viewmodel e visse versa ViewModel para Domain Model
Desenvolvido 😀 por Lorran Mendes 
