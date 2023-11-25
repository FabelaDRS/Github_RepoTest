use ExamDb
Go

Insert into SecurityApp.tbl_User
	   (FirstName, LastName, Email, Age, UserName, AccessCode, CreatedAt, CreatedBy, IsActive)
Values ('Magdaleno','Fabela','fabela.drs@gmail.com',35,'Fabela','Admin123', GETDATE(), 0, 1);
Go

Insert into SecurityApp.tbl_User
	   (FirstName, LastName, Email, Age, UserName, AccessCode, CreatedAt, CreatedBy, IsActive)
Values ('Dirosi','Fabela','fabela.drs@gmail.com',35,'Dirosi','Admin2023', GETDATE(), 0, 1);
Go

Insert into SecurityApp.tbl_User
	   (FirstName, LastName, Email, Age, UserName, AccessCode, CreatedAt, CreatedBy, IsActive)
Values ('Daniela','Montalvo','daniela.drs@gmail.com',35,'Daniela','Dani2023', GETDATE(), 0, 1);
Go

Select * from SecurityApp.tbl_User