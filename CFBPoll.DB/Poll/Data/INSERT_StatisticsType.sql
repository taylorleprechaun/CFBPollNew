DROP TABLE IF EXISTS #TempStatisticsTypes;
CREATE TABLE #TempStatisticsTypes (Type VARCHAR(50));
INSERT INTO #TempStatisticsTypes (Type) 
VALUES ('Defense'),
    ('Offense');

INSERT INTO Poll.StatisticsType (Type)
    SELECT Type
    FROM #TempStatisticsTypes
    WHERE Type NOT IN (
        SELECT DISTINCT Type
        FROM Poll.StatisticsType
    );
GO