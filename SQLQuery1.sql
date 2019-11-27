Create Table RegisterTable(

Email Varchar(100) Not Null,
Password Varchar(100),
ConfirmPassword Varchar(100),
PRIMARY KEY(Email),

CratedDate DateTime Default(GetDate()) Not null)