-- =======================================================
-- Create Stored Procedure Obtener Trabajadores
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT 1
			FROM sys.procedures 
			WHERE name = 'UspGetTrabajadores')

	BEGIN
		DROP PROCEDURE UspGetTrabajadores
	END

GO

CREATE  PROCEDURE UspGetTrabajadores
(
	@Id INT = NULL
)
AS
/*
-- =============================================
-- Author:      Gean Segura 
-- Create Date: 22/06/2025
-- Description: Retorna la lista de trabajadores
-- =============================================
*/
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT 
	 t.Id							as in_id
	,t.TipoDocumento				as vc_tipo_documento
	,t.NumeroDocumento				as vc_numero_documento
	,t.Nombres						as vc_nombres
	,t.Sexo							as ch_sexo
	,de.NombreDepartamento			as vc_nombre_departamento
	,p.NombreProvincia				as vc_nombre_provincia
	,di.NombreDistrito				as vc_nombre_distrito
	FROM Trabajadores t
	INNER JOIN Departamento de
	ON t.IdDepartamento = de.Id
	INNER JOIN Provincia p
	ON t.IdProvincia = p.Id
	INNER JOIN Distrito di
	ON t.IdDistrito = di.Id
	
END
GO