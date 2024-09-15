CREATE DATABASE SucessoEventosDb;
USE SucessoEventosDb;
-- Criação da tabela Participantes
CREATE TABLE Participantes (
    CodPar INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(255) NOT NULL,
    DataNascimento DATETIME NOT NULL,
    Telefone NVARCHAR(20) NOT NULL
);

-- Criação da tabela Pacotes
CREATE TABLE Pacotes (
    CodPacote INT PRIMARY KEY IDENTITY(1,1),
    Descricao NVARCHAR(255) NOT NULL,
    Preco DECIMAL(18, 2) NOT NULL,
    DataViradaPreco DATETIME NOT NULL
);

-- Criação da tabela Atividades
CREATE TABLE Atividades (
    CodAtv INT PRIMARY KEY IDENTITY(1,1),
    DescAtv NVARCHAR(255) NOT NULL,
    Vagas INT NOT NULL,
    Preco DECIMAL(18, 2) NOT NULL
);

-- Tabela de associação entre Participante e Pacote
CREATE TABLE AxParticipantePacote (
    CodPar INT NOT NULL,
    CodPacote INT NOT NULL,
    PRIMARY KEY (CodPar, CodPacote),
    FOREIGN KEY (CodPar) REFERENCES Participantes(CodPar),
    FOREIGN KEY (CodPacote) REFERENCES Pacotes(CodPacote)
);

-- Tabela de associação entre Participante e Atividade
CREATE TABLE AxParticipanteAtividade (
    CodPar INT NOT NULL,
    CodAtv INT NOT NULL,
    PRIMARY KEY (CodPar, CodAtv),
    FOREIGN KEY (CodPar) REFERENCES Participantes(CodPar),
    FOREIGN KEY (CodAtv) REFERENCES Atividades(CodAtv)
);

