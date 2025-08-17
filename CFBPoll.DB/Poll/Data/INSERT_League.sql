DROP TABLE IF EXISTS #TempLeagues;
CREATE TABLE #TempLeagues (Name VARCHAR(50));
INSERT INTO #TempLeagues (Name) 
VALUES ('FBS'),
    ('FCS');

INSERT INTO Poll.League (Name)
    SELECT Name
    FROM #TempLeagues
    WHERE Name NOT IN (
        SELECT DISTINCT Name
        FROM Poll.League
    );
GO