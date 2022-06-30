use master
create database lab10
drop database lab10
use lab10

drop table [user]
drop table [user_auth]
drop table [message]

create table [user] (
    id int identity primary key,
    auth_id int foreign key references [user_auth](id),
    avatar varchar(255) not null,
    name nvarchar(20) not null,
    surname nvarchar(20) not null
)

create table [user_auth] (
    id int identity primary key,
    email nvarchar(100) not null,
    password nvarchar(100) not null
)

create table [message] (
    id int identity primary key,
    sender_id int foreign key references [user](id),
    receiver_id int foreign key references [user](id),
    text nvarchar(1000) not null
)

insert into [user] (auth_id, avatar, name, surname) values (1, N'D:\4 семестр\ООТПиСП\Lab№10\Lab№10\avatars\1.png', 'Alexandr', 'Mozolevskiy')
insert into [user] (auth_id, avatar, name, surname) values (2, N'D:\4 семестр\ООТПиСП\Lab№10\Lab№10\avatars\2.png', 'Artyom', 'Sinkevich')
insert into [user] (auth_id, avatar, name, surname) values (3, N'D:\4 семестр\ООТПиСП\Lab№10\Lab№10\avatars\3.png', 'Maxim', 'Dashinskiy')

insert into [user_auth] (email, password) values ('123@mail.ru', 'qwerty11')
insert into [user_auth] (email, password) values ('234@mail.ru', 'qwerty11')
insert into [user_auth] (email, password) values ('345@mail.ru', 'qwerty11')

insert into [message] (sender_id, receiver_id, text) values (1, 2, 'Hello!')
insert into [message] (sender_id, receiver_id, text) values (2, 1, 'Hi!')
insert into [message] (sender_id, receiver_id, text) values (1, 2, 'How do you do!')

select u1.surname as 'sender', u2.surname as 'retriever', m.text from [message] m
inner join [user] u1 on m.sender_id = u1.id
inner join [user] u2 on m.receiver_id = u2.id
where u1.id = 1
or u2.id = 1

create procedure AddUser @name nvarchar(20), @surname nvarchar(20),
    @avatar nvarchar(255), @email nvarchar(100), @password nvarchar(100) as
    begin
        declare @auth_id int
        insert into [user_auth] (email, password) values (@email, @password)
        select @auth_id = id from [user_auth] where email = @email
        insert into [user] (auth_id, avatar, name, surname) values (@auth_id, @avatar, @name, @surname)
    end

exec AddUser 'Ivan', 'Ivanov', N'D:\4 семестр\ООТПиСП\Lab№10\Lab№10\avatars\4.png', 'abc@mail.ru', 'qwerty11'









