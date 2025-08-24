CREATE PROCEDURE Poll.TeamVersion_Insert @TeamVersionData Poll.udtTeamVersion READONLY
AS
BEGIN
	DROP TABLE IF EXISTS #TeamVersionInsertData;
	
	--Create the season if it does not exist yet
	INSERT Poll.Season ([Year])
	SELECT DISTINCT Season 
	FROM @TeamVersionData td
	LEFT JOIN Poll.Season s
		ON s.[Year] = td.Season
	WHERE s.ID IS NULL;

	--Get the LeagueID for FBS and FCS
	DECLARE @LeagueID_FBS INT = (
		SELECT TOP 1 ID 
		FROM Poll.League 
		WHERE Name = 'FBS'
	);
	DECLARE @LeagueID_FCS INT = (
		SELECT TOP 1 ID 
		FROM Poll.League 
		WHERE Name = 'FCS'
	);

	--Insert the TeamVersion data into a temp table to prepare for the merge
	SELECT TeamID = t.ID,
		SeasonID = s.ID,
		LeagueID =	CASE
						--The team name "FCS Team" is the catch-all for all FCS teams and so we assign it the FCS LeagueID
						WHEN td.TeamName = 'FCS Team' THEN @LeagueID_FCS
						--All other teams are assumed to be FBS
						ELSE @LeagueID_FBS
					END,
		ConferenceID = c.ID,
		DivisionID = d.ID
	INTO #TeamVersionInsertData
	FROM Poll.Team t
	LEFT JOIN @TeamVersionData td
			ON td.TeamName = t.Name
	LEFT JOIN Poll.Conference c
		ON c.Name = td.Conference
			OR c.Abbreviation = td.Conference
	LEFT JOIN Poll.Division d
		ON d.Name = td.Division
	LEFT JOIN Poll.Season s
		ON s.[Year] = td.Season;

	--Perform the merge to insert or update the TeamVersion table
	MERGE INTO Poll.TeamVersion WITH (HOLDLOCK) AS target
		USING #TeamVersionInsertData AS source
			ON target.TeamID = source.TeamID
				AND target.SeasonID = source.SeasonID
				AND target.LeagueID = source.LeagueID
		WHEN MATCHED THEN
			UPDATE SET 
				target.ConferenceID = source.ConferenceID,
				target.DivisionID = source.DivisionID
		WHEN NOT MATCHED BY TARGET THEN
			INSERT (TeamID,
				SeasonID,
				LeagueID,
				ConferenceID,
				DivisionID)
			VALUES (source.TeamID,
				source.SeasonID,
				source.LeagueID,
				source.ConferenceID,
				source.DivisionID);
END;