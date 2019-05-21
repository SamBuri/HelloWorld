
/***************************************************************
This Script is a property of ClinicMaster INTERNATIONAL
Un authorised use or ammendment is not permitted
-- Last updated 10/02/2016 by Wilson Kutegeka
***************************************************************/

USE master
GO

IF EXISTS (SELECT name FROM sysdatabases WHERE name = 'ClinicMaster')
	DROP DATABASE ClinicMaster
GO

CREATE DATABASE ClinicMaster 
GO

