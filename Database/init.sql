CREATE DATABASE SucessoEventosDb;
USE SucessoEventosDb;
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;


BEGIN TRANSACTION;


CREATE TABLE [Atividades] (
    [CodAtv] int NOT NULL IDENTITY,
    [DescAtv] nvarchar(255) NOT NULL,
    [Vagas] int NOT NULL,
    [Preco] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Atividades] PRIMARY KEY ([CodAtv])
);


CREATE TABLE [Pacotes] (
    [CodPacote] int NOT NULL IDENTITY,
    [Preco] decimal(18,2) NOT NULL,
    [DataViradaPreco] datetime2 NOT NULL,
    [Descricao] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Pacotes] PRIMARY KEY ([CodPacote])
);


CREATE TABLE [Participantes] (
    [CodPar] int NOT NULL IDENTITY,
    [Nome] nvarchar(255) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Telefone] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_Participantes] PRIMARY KEY ([CodPar])
);


CREATE TABLE [AxParticipanteAtividade] (
    [CodPar] int NOT NULL,
    [CodAtv] int NOT NULL,
    [ParticipanteCodPar] int NULL,
    CONSTRAINT [PK_AxParticipanteAtividade] PRIMARY KEY ([CodPar], [CodAtv]),
    CONSTRAINT [FK_AxParticipanteAtividade_Atividades_CodAtv] FOREIGN KEY ([CodAtv]) REFERENCES [Atividades] ([CodAtv]) ON DELETE CASCADE,
    CONSTRAINT [FK_AxParticipanteAtividade_Participantes_CodPar] FOREIGN KEY ([CodPar]) REFERENCES [Participantes] ([CodPar]) ON DELETE CASCADE,
    CONSTRAINT [FK_AxParticipanteAtividade_Participantes_ParticipanteCodPar] FOREIGN KEY ([ParticipanteCodPar]) REFERENCES [Participantes] ([CodPar])
);


CREATE TABLE [AxParticipantePacote] (
    [CodPar] int NOT NULL,
    [CodPacote] int NOT NULL,
    CONSTRAINT [PK_AxParticipantePacote] PRIMARY KEY ([CodPar], [CodPacote]),
    CONSTRAINT [FK_AxParticipantePacote_Pacotes_CodPacote] FOREIGN KEY ([CodPacote]) REFERENCES [Pacotes] ([CodPacote]) ON DELETE CASCADE,
    CONSTRAINT [FK_AxParticipantePacote_Participantes_CodPar] FOREIGN KEY ([CodPar]) REFERENCES [Participantes] ([CodPar]) ON DELETE CASCADE
);


CREATE INDEX [IX_AxParticipanteAtividade_CodAtv] ON [AxParticipanteAtividade] ([CodAtv]);


CREATE INDEX [IX_AxParticipanteAtividade_ParticipanteCodPar] ON [AxParticipanteAtividade] ([ParticipanteCodPar]);


CREATE INDEX [IX_AxParticipantePacote_CodPacote] ON [AxParticipantePacote] ([CodPacote]);


INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240915200840_InitCreate', N'8.0.8');


COMMIT;
