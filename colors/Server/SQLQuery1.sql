--SELECT name
--FROM sys.key_constraints
--WHERE parent_object_id = OBJECT_ID('Colors') AND type = 'PK';

--ALTER TABLE Colors DROP CONSTRAINT PK__tmp_ms_x__92B908E98C9E259A;

--SELECT TABLE_SCHEMA, TABLE_NAME, COLUMN_NAME
--FROM INFORMATION_SCHEMA.COLUMNS
--WHERE TABLE_NAME = 'Colors';


--EXEC sp_rename 'Colors.presentationOrder', 'colorId', 'COLUMN';


--ALTER TABLE Colors ADD CONSTRAINT PK_Colors PRIMARY KEY CLUSTERED (colorId);

--SELECT name, type_desc
--FROM sys.key_constraints
--WHERE parent_object_id = OBJECT_ID('dbo.Colors');

--EXEC sp_help 'dbo.Colors';