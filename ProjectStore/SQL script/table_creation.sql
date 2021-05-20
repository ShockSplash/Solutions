create database project_storage;

create type solution_status as enum ('NotStarted', 'Active', 'Completed');

 create table solutions(
id serial primary key,
name text,
start_date date not null,
completion_date date not null,
current_status solution_status,
priority integer);

create type task_status as enum ('ToDo','InProgress', 'Done');

create table tasks(
id serial primary key,
solution_id integer references solutions(id) on delete cascade,
task_name text,
current_task_status task_status, 
description text,
priority integer
);