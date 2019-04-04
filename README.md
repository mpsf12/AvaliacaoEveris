# Everis
Solução para teste de avaliação da Everis

Resposta questionário Everis
1. Acerca de conceitos básicos e tratamentos de exceção em programação orientada a objetos, julgue os itens subsequentes. Objetos podem ter mais de uma identidade; para isso, é necessário que a sua posição esteja explícita em um array de dados.

A. (X) Verdadeiro
B. ( ) Falso

2. Na programação orientada a objetos, o pilar que permite que um único nome de classe, ou nome de método, represente um código diferente, selecionado por algum mecanismo automático, em que um nome pode assumir muitas formas, ou seja, o mesmo nome pode representar muitos comportamentos diferentes, é o pilar conhecido como

A. (X) polimorfismo.
B. ( ) construtores.
C. ( ) encapsulamento.
D. ( ) modularização.
E. ( ) acoplamento.

3. Julgue os itens a seguir, relativos a projetos orientados a objeto. Padrões de projeto devem conter uma especificação detalhada somente dos problemas e da solução, para permitir o reuso de componentes executáveis.

A. ( ) Verdadeiro
B. (X) Falso

Obs: Padrões de projeto devem conter especificações genéricas de organização e manutenção dos projetos, sem pensar nos problemas e/ou soluções.

4. Considere o programa abaixo:
public static void Programa()
{
for (int i = 3; i < 20; i+=2)
{
Console.Write((i%3).ToString() + " ");
}
}

O resultado a ser informado ao usuário após a execução do programa acima é:
A. ( ) 0 0 1 0 0 1 0 0 1
B. ( ) 0 1 2 0 1 2 0 1 2
C. ( ) 0 1 0 1 0 1 0 1 0
D. ( ) 1 2 1 2 1 2 1 2 1
E. (X) 0 2 1 0 2 1 0 2 1

Obs:
i = 3; i%3 = 0
i = 5; i%3 = 2
i = 7; i%3 = 1
i = 9; i%3 = 0
i = 11; i%3 = 2
i = 13; i%3 = 1
i = 15; i%3 = 0
i = 17; i%3 = 2
i = 19; i%3 = 1
i = 21; i%3 = 0

5. Dadas as classes:
public abstract class Conta
{
public Cliente Titular { get; set; }
//outros métodos e atributos da Conta
}
public static class ContaExtensions
{
public static void MudaTitular(this Conta c, Cliente titular)
{
c.Titular = titular;
}
}
O que podemos afirmar sobre o código a seguir? Indique com verdadeiro ou falso.
Conta c = new ContaCorrente();
Cliente titular = new Cliente("victor");
ContaExtensions.MudaTitular(c, titular);
A. (X) Extension Method é um método estático comum e, portanto, o código do exercício funciona.
B. ( ) Código do exercício não compila. Só podemos usar o MudaTitular como extension method e não como método estático.
C. ( ) Código não compila, pois temos um this no primeiro argumento do MudaTitular.

O código funciona com a implementação das classes que estão faltando.


Script banco de dados

CREATE TABLE Everis.dbo.tb_empresa (
  id int IDENTITY,
  NomeEmpresa varchar(50) NOT NULL,
  CONSTRAINT PK_tb_empresa_id PRIMARY KEY CLUSTERED (id)
)
ON [PRIMARY]
GO

CREATE UNIQUE INDEX KEY_tb_empresa_id
  ON Everis.dbo.tb_empresa (id)
  ON [PRIMARY]
GO

CREATE TABLE Everis.dbo.tb_produto (
  Id int IDENTITY,
  NomeProduto varchar(255) NOT NULL,
  CONSTRAINT PK_tb_produto_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO

CREATE UNIQUE INDEX KEY_tb_produto_Id
  ON Everis.dbo.tb_produto (Id)
  ON [PRIMARY]
GO

CREATE TABLE Everis.dbo.tb_produto_estoque (
  Id int IDENTITY,
  IdProduto int NOT NULL,
  IdEmpresa int NOT NULL,
  Estoque int NOT NULL,
  CONSTRAINT PK_tb_produto_estoque_Id PRIMARY KEY NONCLUSTERED (Id),
  CONSTRAINT KEY_tb_produto_estoque UNIQUE (IdProduto, IdEmpresa)
)
ON [PRIMARY]
GO

CREATE TABLE Everis.dbo.tb_produto_movimentacao (
  Id int IDENTITY,
  IdProduto int NOT NULL,
  IdEmpresa int NOT NULL,
  Movimentacao int NOT NULL,
  Data date NOT NULL,
  CONSTRAINT PK_tb_produto_movimentacao_Id PRIMARY KEY CLUSTERED (Id)
)
ON [PRIMARY]
GO


ALTER TABLE Everis.dbo.tb_produto_estoque
  ADD CONSTRAINT FK_tb_produto_estoque_IdEmpresa FOREIGN KEY (IdEmpresa) REFERENCES dbo.tb_empresa (id)
GO

ALTER TABLE Everis.dbo.tb_produto_estoque
  ADD CONSTRAINT FK_tb_produto_estoque_IdProduto FOREIGN KEY (IdProduto) REFERENCES dbo.tb_produto (Id)
GO

ALTER TABLE Everis.dbo.tb_produto_movimentacao
  ADD CONSTRAINT FK_tb_produto_movimentacao_IdEmpresa FOREIGN KEY (IdEmpresa) REFERENCES dbo.tb_empresa (id)
GO

ALTER TABLE Everis.dbo.tb_produto_movimentacao
  ADD CONSTRAINT FK_tb_produto_movimentacao_IdProduto FOREIGN KEY (IdProduto) REFERENCES dbo.tb_produto (Id)
GO
