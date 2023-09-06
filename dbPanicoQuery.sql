-- drop database dbPanico;
create database dbPanico;
use dbPanico;

create table tbUser(
	idUser int primary key identity,
	nome varchar(50) not null,
    senha varchar(50) not null
);

create table tbObra(
	idObra int primary key identity,
    nome varchar(50) not null,
    ano int not null,
    descricao varchar(500) not null,
    imagemPoster varchar(100) not null,
    imagemFundo varchar(100) not null,
    diretores varchar (100) not null,
    avaliacao int
);

create table tbPersonagens(
	idPerson int primary key identity,
    nomePerson varchar(50) not null,
    descricaoPerson varchar(500) not null,
    imagemPerson varchar(100) not null,
    situacao int not null
);

create table tbAtor(
	idAtor int primary key identity,
    nomeElenco varchar(50) not null,
    descricaoElenco varchar(500) not null, 
    imagemElenco varchar(100) not null, 
);

create table tbAtorPersonagem(
	idPerson int,
    idAtor int,
    Primary Key (idPerson, idAtor),
	foreign key (idPerson) references tbPersonagens(idPerson),
	foreign key (idAtor) references tbAtor(idAtor)
);

create table tbObraPersonagem(
	idObra int,
    idPerson int,
    Primary Key (idObra, idPerson),
	foreign key (idObra) references tbObra(idObra),
	foreign key (idPerson) references tbPersonagens(idPerson)
);


create procedure spInsertAtor
    @nomeElenco varchar(50),
    @descricaoElenco varchar(500),
    @imagemElenco varchar(100)
as
begin 
    insert into tbAtor (nomeElenco, descricaoElenco, imagemElenco)
        values (@nomeElenco, @descricaoElenco, @imagemElenco);
end;

exec spInsertAtor 'Neve Campbell', 'Neve Campbell é uma atriz canadense. Depois de começar sua carreira no palco, ela alcançou fama na série de televisão Party of Five, interpretando a adolescente Julia Salinger. Ela posteriormente apareceu em papéis principais em vários filmes de Hollywood, incluindo Scream, The Craft e Wild Things, e desde então apareceu em partes menores e retornou aos papéis no palco. Neve Campbell nasceu em Guelph, Ontário.', 'https://www.themoviedb.org/t/p/original/dr6kk8RMjR62N0QNqFYOOs5ITJf.jpg';
exec spInsertAtor 'Courtney Cox', 'Courteney Bass Cox (nascido em 15 de junho de 1964) é uma atriz americana, que alcançou fama por seu papel como Monica Geller na sitcom da NBC Friends. Cox também atuou na série de filmes Dirt and the Scream. Ela atualmente estrela no seriado da ABC, Cougar Town, pelo qual ela ganhou sua primeira indicação ao Globo de Ouro.', 'https://www.themoviedb.org/t/p/original/gfPFo174v4JqoRaaxUmqLVBrVID.jpg';

create procedure spInsertUser
    @nome varchar(50),
    @senha varchar(50)
as
begin 
    insert into tbUser (nome, senha)
        values (@nome, @senha);
end;

exec spInsertUser 'Yasmim','yasmim123';
exec spInsertUser 'Mateus', 'mateus123';

create procedure spInsertPersonagens
    @nomePerson varchar(50),
    @descricaoPerson varchar(500),
    @imagemPerson varchar (100),
    @situacao int
as
begin 
    insert into tbPersonagens(nomePerson, descricaoPerson, imagemPerson, situacao)
        values (@nomePerson, @descricaoPerson, @imagemPerson, @situacao);
end;

exec spInsertPersonagens 'Sidney Prescott', 'Sidney Prescott é a heroína e protagonista dos filmes Pânico. Ela é filha de Neil Prescott e sua falecida esposa, Maureen (nascida Roberts), esposa de Mark Kincaid e mãe de suas filhas. Ela era parente materna de Jill (prima), Kate (tia) e Roman (meio-irmão). Ela se tornou uma heroína celebridade local depois de derrotar e matar seu namorado psicótico Billy, e seu melhor amigo, Stu, os assassinos de sua própria mãe, que planejavam incriminar seu pai por um massacre. eles se comprometem no aniversário de um ano, dentro de sua pacífica cidade natal, Woodsboro.', 'https://www.themoviedb.org/t/p/original/fjVNliU0qjlXyW3qSion8pAStcn.jpg', 1;
exec spInsertPersonagens 'Gale Weathers', 'Gale Weathers, anteriormente como Gale Riley, é uma das personagens principais da franquia Pânico (1996-presente). Ela intrega os únicos três personagens, ao lado de Sidney Prescott e Dewey Riley, que aparecem em todos os cinco filmes e deve aparecer no sexto filme em breve. Em 1996, Gale é uma repórter proeminente que afirma e prova que Cotton Weary é inocente do assassinato da dona de casa Maureen Prescott um ano após os crimes com ajuda de sua filha, Sidney, quando o Primeiro Massacre de Woodsboro vem à tona. Assim que descobre os assassinatos de Casey Becker e Steven Orth, Gale viaja até Woodsboro com seu cinegrafista Kenny Brown. Ela presencia e ajuda a matar Billy Loomis, o assassino e mandante principal da matança, na residência 261 Turner Lane.', 'https://www.themoviedb.org/t/p/original/ekimYKwHHd2F7Hg5fmZqLF4WOt8.jpg', 1;

create procedure spInsertObra
    @nome varchar(50),
    @ano int,
    @descricao varchar(500),
    @imagemPoster varchar(100),
    @imagemFundo varchar(100),
    @diretores varchar(100),
    @avaliacao int
as
begin 
    insert into tbObra(nome, ano, descricao, imagemPoster, imagemFundo, diretores, avaliacao)
        values (@nome, @ano, @descricao, @imagemPoster, @imagemFundo, @diretores, @avaliacao);
end;

exec spInsertObra 'Pânico', 1996, 'Após uma série de mortes misteriosas, um grupo de amigos são ameaçados por um assassino. Em uma mistura de emoções fortes e muitos sustos, aqui a única coisa que se pode ter certeza é que todos são vítimas e todos são suspeitos.', 'https://www.themoviedb.org/t/p/original/xiQ6Lmi2jXkDw4oGRj1vbfWMYuS.jpg', 'https://www.themoviedb.org/t/p/original/7ZigA0vEuUMDXeZdo8ltjov8oRB.jpg', 'Wes Craven', 74;

insert into tbAtorPersonagem(idAtor, idPerson) values(1, 1);
insert into tbAtorPersonagem(idAtor, idPerson) values(2, 2);

insert into tbObraPersonagem(idObra, idPerson) values(1, 1);
insert into tbObraPersonagem(idObra, idPerson) values(1, 2);