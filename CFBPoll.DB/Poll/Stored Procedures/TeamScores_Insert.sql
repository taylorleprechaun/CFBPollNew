CREATE PROCEDURE Poll.TeamScores_Insert @TeamScoresData Poll.udtTeamScores READONLY
AS
BEGIN
	DROP TABLE IF EXISTS #ScoresInsertData;
	DROP TABLE IF EXISTS #TeamScoresDataModified;

	--Copy the input data to a temp table to allow for modifications
	SELECT tsd.Season,
		tsd.Week,
		tsd.Date,
		tsd.HomeTeam,
		tsd.HomeScore,
		tsd.AwayTeam,
		tsd.AwayScore,
		tsd.IsNeutralSite
	INTO #TeamScoresDataModified
	FROM @TeamScoresData tsd;

	--Replace all FCS team names with the generic catch-all "FCS Team" name
	UPDATE tsd
	SET tsd.HomeTeam = 'FCS Team'
	FROM #TeamScoresDataModified tsd
	LEFT JOIN Poll.Team t
		ON tsd.HomeTeam = t.Name
	WHERE t.ID IS NULL;
	UPDATE tsd
	SET tsd.AwayTeam = 'FCS Team'
	FROM #TeamScoresDataModified tsd
	LEFT JOIN Poll.Team t
		ON tsd.AwayTeam = t.Name
	WHERE t.ID IS NULL;

	--Insert the TeamScores data into a temp table to prepare for the merge
	SELECT SeasonID = s.ID,
		td.[Week],
		td.Date,
		HomeTeamID = tHome.ID,
		td.HomeScore,
		AwayTeamID = tAway.ID,
		td.AwayScore,
		td.IsNeutralSite
	INTO #ScoresInsertData
	FROM #TeamScoresDataModified td
	JOIN Poll.Team tHome
		ON td.HomeTeam = tHome.Name
	JOIN Poll.Team tAway
		ON td.AwayTeam = tAway.Name
	JOIN Poll.Season s
		ON td.Season = s.[Year];

	--Perform the merge to insert or update the TeamScores table
	MERGE INTO Poll.TeamScores WITH (HOLDLOCK) AS target
	USING #ScoresInsertData AS source
		ON target.SeasonID = source.SeasonID
			AND target.[Week] = source.[Week]
			AND target.Date = source.Date
			AND target.HomeTeamID = source.HomeTeamID
			AND target.AwayTeamID = source.AwayTeamID
	WHEN MATCHED THEN
		UPDATE SET 
			target.HomeScore = source.HomeScore,
			target.AwayScore = source.AwayScore,
			target.IsNeutralSite = source.IsNeutralSite
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (SeasonID,
			[Week],
			Date,
			HomeTeamID,
			HomeScore,
			AwayTeamID,
			AwayScore,
			IsNeutralSite)
		VALUES (source.SeasonID,
			source.[Week],
			source.Date,
			source.HomeTeamID,
			source.HomeScore,
			source.AwayTeamID,
			source.AwayScore,
			source.IsNeutralSite);
END;