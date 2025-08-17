CREATE PROCEDURE Poll.TeamScores_Insert @TeamScoresData Poll.udtTeamScores READONLY
AS
BEGIN
	DROP TABLE IF EXISTS #ScoresInsertData;
	
	SELECT td.[Week],
		td.Date,
		HomeTeamVersionID = tvHome.TeamID,
		td.HomeScore,
		AwayTeamVersionID = tvAway.TeamID,
		td.AwayScore,
		td.IsNeutralSite
	INTO #ScoresInsertData
	FROM @TeamScoresData td
	LEFT JOIN Poll.Team tHome
		ON td.HomeTeam = tHome.Name
	LEFT JOIN Poll.TeamAlias taHome
		ON td.HomeTeam = taHome.Alias
	LEFT JOIN Poll.Team tAway
		ON td.AwayTeam = tAway.Name
	LEFT JOIN Poll.TeamAlias taAway
		ON td.AwayTeam = taAway.Alias
	JOIN Poll.Season s
		ON td.Season = s.[Year]
	JOIN Poll.TeamVersion tvHome
		ON tvHome.TeamID = ISNULL(tHome.ID, taHome.TeamID)
			AND tvHome.SeasonID = s.ID
	JOIN Poll.TeamVersion tvAway
		ON tvAway.TeamID = ISNULL(tAway.ID, taAway.TeamID)
			AND tvAway.SeasonID = s.ID;

	MERGE INTO Poll.TeamScores WITH (HOLDLOCK) AS target
	USING #ScoresInsertData AS source
		ON target.HomeTeamVersionID = source.HomeTeamVersionID
			AND target.AwayTeamVersionID = source.AwayTeamVersionID
			AND target.[Week] = source.[Week]
	WHEN MATCHED THEN
		UPDATE SET 
			target.Date = source.Date,
			target.HomeScore = source.HomeScore,
			target.AwayScore = source.AwayScore,
			target.IsNeutralSite = source.IsNeutralSite
	WHEN NOT MATCHED BY TARGET THEN
		INSERT ([Week],
			Date,
			HomeTeamVersionID,
			HomeScore,
			AwayTeamVersionID,
			AwayScore,
			IsNeutralSite)
		VALUES (source.[Week],
			source.Date,
			source.HomeTeamVersionID,
			source.HomeScore,
			source.AwayTeamVersionID,
			source.AwayScore,
			source.IsNeutralSite);
END;