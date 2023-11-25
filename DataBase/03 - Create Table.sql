Use ExamDb
Go

Create Table SecurityApp.tbl_User
(
	UserId Int identity(1,1) Primary key,
	FirstName Varchar(50)Not Null,
	LastName varchar(75) Not Null,
	Email Varchar(120) Not Null,
	Age Int Not Null,
	UserName Varchar(75) Not Null,
	AccessCode varchar(max) Not null,
	CreatedAt Datetime Not Null,
	CreatedBy Int Not Null,
	ModifiedAt Datetime Null,
	ModifiedBy Int Null,
	IsActive Bit 
)


Create Table SecurityApp.tbl_AuthorizerUser
(
	AuthorizerUserId Int Identity(1,1),
	UserId Int,
	Token varchar(Max),
	RefreshToken Varchar(Max),
	CreatedAt datetime,
	ExpiredAt Datetime,
	IsActive bit
	Constraint Pk_AuthorizerUserId Primary Key(AuthorizerUserId)
)
ALter Table SecurityApp.tbl_AuthorizerUser
Add Constraint Fk_AuthorizerUser_UserId Foreign Key(UserId) References SecurityApp.tbl_User(UserId);


