CREATE PROCEDURE Poll.TeamStatistics_Insert @TeamStatData Poll.udtTeamStatistics READONLY
AS
BEGIN
	DROP TABLE IF EXISTS #StatInsertData;

	SELECT TeamVersionID = tv.ID,
		StatisticsTypeID = st.ID,
		td.[Week],
		td.Games,
		td.Points,
		td.PassCompletions,
		td.PassAttempts,
		td.PassPercent,
		td.PassYards,
		td.PassTDs,
		td.RushAttempts,
		td.RushYards,
		td.RushAverage,
		td.RushTDs,
		td.TotalPlays,
		td.TotalYards,
		td.FirstDownsPass,
		td.FirstDownsRush,
		td.FirstDownsPenalty,
		td.FirstDownsTotal,
		td.PenaltiesNumber,
		td.PenaltiesYards,
		td.TurnoversFumble,
		td.TurnoversInterception,
		td.TurnoversTotal
	INTO #StatInsertData
	FROM @TeamStatData td
	LEFT JOIN Poll.Team t
		ON td.TeamName = t.Name
	LEFT JOIN Poll.TeamAlias ta
		ON td.TeamName = ta.Alias
	JOIN Poll.Season s
		ON td.Season = s.[Year]
	JOIN Poll.TeamVersion tv
		ON tv.TeamID = ISNULL(t.ID, ta.TeamID)
			AND tv.SeasonID = s.ID
	JOIN Poll.StatisticsType st
		ON td.StatisticsType = st.Type;

	MERGE INTO Poll.TeamStatistics WITH (HOLDLOCK) AS target
	USING #StatInsertData AS source
		ON target.TeamVersionID = source.TeamVersionID
			AND target.StatisticsTypeID = source.StatisticsTypeID
			AND target.[Week] = source.[Week]
	WHEN MATCHED THEN
		UPDATE SET 
			target.Games = source.Games,
			target.Points = source.Points,
			target.PassCompletions = source.PassCompletions,
			target.PassAttempts = source.PassAttempts,
			target.PassPercent = source.PassPercent,
			target.PassYards = source.PassYards,
			target.PassTDs = source.PassTDs,
			target.RushAttempts = source.RushAttempts,
			target.RushYards = source.RushYards,
			target.RushAverage = source.RushAverage,
			target.RushTDs = source.RushTDs,
			target.TotalPlays = source.TotalPlays,
			target.TotalYards = source.TotalYards,
			target.FirstDownsPass = source.FirstDownsPass,
			target.FirstDownsRush = source.FirstDownsRush,
			target.FirstDownsPenalty = source.FirstDownsPenalty,
			target.FirstDownsTotal = source.FirstDownsTotal,
			target.PenaltiesNumber = source.PenaltiesNumber,
			target.PenaltiesYards = source.PenaltiesYards,
			target.TurnoversFumble = source.TurnoversFumble,
			target.TurnoversInterception = source.TurnoversInterception,
			target.TurnoversTotal = source.TurnoversTotal
	WHEN NOT MATCHED BY TARGET THEN
		INSERT (TeamVersionID,
			StatisticsTypeID,
			[Week],
			Games,
			Points,
			PassCompletions,
			PassAttempts,
			PassPercent,
			PassYards,
			PassTDs,
			RushAttempts,
			RushYards,
			RushAverage,
			RushTDs,
			TotalPlays,
			TotalYards,
			FirstDownsPass,
			FirstDownsRush,
			FirstDownsPenalty,
			FirstDownsTotal,
			PenaltiesNumber,
			PenaltiesYards,
			TurnoversFumble,
			TurnoversInterception,
			TurnoversTotal)
		VALUES (source.TeamVersionID,
			source.StatisticsTypeID,
			source.[Week],
			source.Games,
			source.Points,
			source.PassCompletions,
			source.PassAttempts,
			source.PassPercent,
			source.PassYards,
			source.PassTDs,
			source.RushAttempts,
			source.RushYards,
			source.RushAverage,
			source.RushTDs,
			source.TotalPlays,
			source.TotalYards,
			source.FirstDownsPass,
			source.FirstDownsRush,
			source.FirstDownsPenalty,
			source.FirstDownsTotal,
			source.PenaltiesNumber,
			source.PenaltiesYards,
			source.TurnoversFumble,
			source.TurnoversInterception,
			source.TurnoversTotal);
END;