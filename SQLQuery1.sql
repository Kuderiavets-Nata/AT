USE Lab10AT


	CREATE TABLE Group666 (
		ID int PRIMARY KEY IDENTITY(1,1),
		FirstName varchar(255),
		LastName varchar(255),
		Lab1 float,
		Lab2 float,
		Lab3 float,
	)

INSERT INTO Group666(FirstName, LastName, Lab1, Lab2, Lab3)
VALUES 
	 ('StudentName1', 'StudentLastName1', 1, 2, 3),
	 ('StudentName2', 'StudentLastName2', 4, 5, 6),
	 ('StudentName3', 'StudentLastName3', 7, 8, 9)
	


GO

CREATE OR ALTER PROCEDURE CalculateAvarageScore @FirstName nvarchar(255), @Lastname nvarchar(255) 
AS
BEGIN
	DECLARE @ReturnValue float

	SELECT @ReturnValue = (Lab1 + Lab2 + Lab3) / 3 
							FROM Group666
							WHERE @FirstName = FirstName and @Lastname = LastName

	RETURN @ReturnValue
END
GO

EXEC tSQLt.NewTestClass 'test';
GO

CREATE OR ALTER PROCEDURE test.[test first ]
AS
BEGIN
	DECLARE @actual int

	SET @actual = (SELECT COUNT(FirstName) as count FROM Group666 WHERE 
	FirstName IS NOT NULL
	AND LastName IS NOT NULL
	AND Lab1 IS NOT NULL
	AND Lab2 IS NOT NULL
	AND Lab3 IS NOT NULL)

    EXEC tSQLt.AssertNotEquals 0, @actual
	
END
GO


CREATE OR ALTER PROCEDURE test.[test second ]
AS
BEGIN

	DECLARE @actual float
	DECLARE @expected float

	SET @expected = 2
	EXEC @actual = CalculateAvarageScore @FirstName = 'StudentName1', @Lastname = 'StudentLastName1'
	EXEC tSQLt.AssertEquals @expected, @actual

	SET @expected = 5
	EXEC @actual = CalculateAvarageScore @FirstName = 'StudentName2', @Lastname = 'StudentLastName2'
	EXEC tSQLt.AssertEquals @expected, @actual

	SET @expected = 8
	EXEC @actual = CalculateAvarageScore @FirstName = 'StudentName3', @Lastname = 'StudentLastName3'
	EXEC tSQLt.AssertEquals @expected, @actual

END
GO

CREATE OR ALTER PROCEDURE test.[test third ]
AS
BEGIN
	
	DECLARE @actual int;
	SET @actual = (SELECT COUNT(*) as count FROM Group666 WHERE Lab1 <= 0 or Lab2 <= 0 or Lab3 <= 0);
    EXEC tSQLt.AssertEquals 0, @actual;

END
GO


EXEC tSQLt.RunAll
GO

EXEC tSQLt.DropClass 'test';
GO

DROP TABLE IF EXISTS Group666;
GO