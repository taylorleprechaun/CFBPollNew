USE CFBPoll
GO
DROP TABLE IF EXISTS #TempConferences;
CREATE TABLE #TempConferences (Type VARCHAR(50));
INSERT INTO #TempConferences (Type) 
VALUES ('Defense'),
    ('Offense');

INSERT INTO Poll.StatType (Type)
    SELECT Type
    FROM #TempConferences
    WHERE Type NOT IN (
        SELECT DISTINCT Type
        FROM Poll.StatType
    );
GO