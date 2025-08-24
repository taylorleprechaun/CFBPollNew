/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Poll\Data\INSERT_League.sql
:r .\Poll\Data\INSERT_Conference.sql
:r .\Poll\Data\INSERT_Division.sql
:r .\Poll\Data\INSERT_StatisticsType.sql
:r .\Poll\Data\INSERT_Team.sql