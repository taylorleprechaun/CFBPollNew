DROP TABLE IF EXISTS #TempAlias;
CREATE TABLE #TempAlias (Name VARCHAR(50), Alias VARCHAR(50));
INSERT INTO #TempAlias (Name, Alias) 
VALUES 
	('Alabama-Birmingham','UAB'),
	('Central Florida','UCF'),
	('Louisiana-Lafayette','Louisiana'),
	('Louisiana State','LSU'),
	('Sam Houston','Sam Houston State'),
	('SMU','Southern Methodist'),
	('Southern Miss','Southern Mississippi'),
	('Texas Christian','TCU'),
	('USC','Southern California');

INSERT INTO Poll.TeamAlias (TeamID, Alias)
    SELECT t.ID, a.Alias
    FROM #TempAlias a
	JOIN Poll.Team t
		ON a.Name = t.Name
    WHERE a.Alias NOT IN (
        SELECT DISTINCT Alias
        FROM Poll.TeamAlias
    );
GO