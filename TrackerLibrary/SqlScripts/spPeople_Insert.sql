SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Drop procedure dbo.spPeople_Insert
go

CREATE PROCEDURE dbo.spPeople_Insert
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@EmailAddress nvarchar(100),
	@CellphoneNumber varchar(20),
	@id int = 0 output
AS
BEGIN

	SET NOCOUNT ON;
	insert into dbo.People(FirstName,LastName,EmailAddress,cellphoneNumber)
	values(@FirstName,@LastName,@EmailAddress,@CellphoneNumber);

	select @id=SCOPE_IDENTITY();
END
GO
