DROP TABLE IF EXISTS #TempConferences;
CREATE TABLE #TempConferences (Name VARCHAR(50), Abbreviation VARCHAR(10));
INSERT INTO #TempConferences (Name, Abbreviation) 
VALUES ('American', 'AAC'),
    ('Atlantic Coast', 'ACC'),
    ('Big 12','B12'),
    ('Big East','BE'),
    ('Big Ten','B10'),
    ('Conference USA','CUSA'),
    ('FBS Independents','Indep'),
    ('FCS Conference','FCS'),
    ('Mid-American','MAC'),
    ('Mountain West','MWC'),
    ('Pac-10','P10'),
    ('Pac-12','P12'),
    ('Southeastern','SEC'),
    ('Sun Belt','SBC');

INSERT INTO Poll.Conference (Name, Abbreviation)
    SELECT Name, Abbreviation
    FROM #TempConferences
    WHERE Name NOT IN (
        SELECT DISTINCT Name
        FROM Poll.Conference
    );
GO