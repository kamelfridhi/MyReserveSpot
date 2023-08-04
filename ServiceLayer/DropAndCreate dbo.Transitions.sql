/*New To Closed*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'7758c584-a174-4c4c-9db7-fe72317a7cb6','79698a7b-d7e6-47a7-8aae-e670728d2157')
/*Closed to New*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'79698a7b-d7e6-47a7-8aae-e670728d2157','7758c584-a174-4c4c-9db7-fe72317a7cb6')
/*New To Suspended*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'7758c584-a174-4c4c-9db7-fe72317a7cb6','dda0d280-f86a-4030-8fd9-f4c25e74b202')
/*Suspended to New*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'dda0d280-f86a-4030-8fd9-f4c25e74b202','7758c584-a174-4c4c-9db7-fe72317a7cb6')
/* New to InProgress*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'7758c584-a174-4c4c-9db7-fe72317a7cb6','2beb37a3-09a0-417b-947c-48aaae9937fd')
/*InProgress To Closed*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'2beb37a3-09a0-417b-947c-48aaae9937fd','79698a7b-d7e6-47a7-8aae-e670728d2157')
/*Inprogress To Suspended*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'2beb37a3-09a0-417b-947c-48aaae9937fd','dda0d280-f86a-4030-8fd9-f4c25e74b202')
/* Suspended To Inprogress*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'dda0d280-f86a-4030-8fd9-f4c25e74b202','2beb37a3-09a0-417b-947c-48aaae9937fd')
/*Closed To InProgress*/
insert into [RepositoryPattern].[dbo].Transitions (Id,SourceId,TargetId) values (NEWID(),'79698a7b-d7e6-47a7-8aae-e670728d2157','2beb37a3-09a0-417b-947c-48aaae9937fd')



