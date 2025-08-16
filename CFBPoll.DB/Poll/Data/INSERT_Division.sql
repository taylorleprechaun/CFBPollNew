USE CFBPoll
GO
DROP TABLE IF EXISTS #TempDivisions;
CREATE TABLE #TempDivisions (Name VARCHAR(50));
INSERT INTO #TempDivisions (Name) 
VALUES ('Atlantic'),
    ('Coastal'),
    ('East'),
    ('Leaders'),
    ('Legends'),
    ('Mountain'),
    ('North'),
    ('South'),
    ('West');

INSERT INTO Poll.Division (Name)
    SELECT Name
    FROM #TempDivisions
    WHERE Name NOT IN (
        SELECT DISTINCT Name
        FROM Poll.Division
    );
GO