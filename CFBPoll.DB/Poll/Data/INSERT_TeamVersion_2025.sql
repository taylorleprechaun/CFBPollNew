USE CFBPoll
GO
--Year
DECLARE @Year INT = 2025
IF NOT EXISTS (SELECT TOP 1 ID FROM Poll.Season WHERE [Year] = @Year)
BEGIN
	INSERT INTO Poll.Season ([Year]) VALUES (@Year);
END;

--Team Info
DROP TABLE IF EXISTS #TempTeamInfo;
CREATE TABLE #TempTeamInfo (Name VARCHAR(50), Conference VARCHAR(50), Division VARCHAR(50) NULL);
INSERT INTO #TempTeamInfo (Name, Conference, Division)
VALUES ('Air Force','Mountain West',NULL),
	('Akron','Mid-American',NULL),
	('Alabama','Southeastern',NULL),
	('Alabama-Birmingham','American',NULL),
	('Appalachian State','Sun Belt','East'),
	('Arizona','Big 12',NULL),
	('Arizona State','Big 12',NULL),
	('Arkansas','Southeastern',NULL),
	('Arkansas State','Sun Belt','West'),
	('Army','American',NULL),
	('Auburn','Southeastern',NULL),
	('Ball State','Mid-American',NULL),
	('Baylor','Big 12',NULL),
	('Boise State','Mountain West',NULL),
	('Boston College','Atlantic Coast',NULL),
	('Bowling Green','Mid-American',NULL),
	('Brigham Young','Big 12',NULL),
	('Buffalo','Mid-American',NULL),
	('California','Atlantic Coast',NULL),
	('Central Florida','Big 12',NULL),
	('Central Michigan','Mid-American',NULL),
	('Charlotte','American',NULL),
	('Cincinnati','Big 12',NULL),
	('Clemson','Atlantic Coast',NULL),
	('Coastal Carolina','Sun Belt','East'),
	('Colorado','Big 12',NULL),
	('Colorado State','Mountain West',NULL),
	('Connecticut','FBS Independents',NULL),
	('Delaware','Conference USA',NULL),
	('Duke','Atlantic Coast',NULL),
	('East Carolina','American',NULL),
	('Eastern Michigan','Mid-American',NULL),
	('Florida','Southeastern',NULL),
	('Florida Atlantic','American',NULL),
	('Florida Int''l','Conference USA',NULL),
	('Florida State','Atlantic Coast',NULL),
	('Fresno State','Mountain West',NULL),
	('Georgia','Southeastern',NULL),
	('Georgia Southern','Sun Belt','East'),
	('Georgia State','Sun Belt','East'),
	('Georgia Tech','Atlantic Coast',NULL),
	('Hawaii','Mountain West',NULL),
	('Houston','Big 12',NULL),
	('Illinois','Big Ten',NULL),
	('Indiana','Big Ten',NULL),
	('Iowa','Big Ten',NULL),
	('Iowa State','Big 12',NULL),
	('Jacksonville State','Conference USA',NULL),
	('James Madison','Sun Belt','East'),
	('Kansas','Big 12',NULL),
	('Kansas State','Big 12',NULL),
	('Kennesaw State','Conference USA',NULL),
	('Kent State','Mid-American',NULL),
	('Kentucky','Southeastern',NULL),
	('Liberty','Conference USA',NULL),
	('Louisiana Tech','Conference USA',NULL),
	('Louisiana-Lafayette','Sun Belt','West'),
	('Louisiana-Monroe','Sun Belt','West'),
	('Louisville','Atlantic Coast',NULL),
	('Louisiana State','Southeastern',NULL),
	('Marshall','Sun Belt','East'),
	('Maryland','Big Ten',NULL),
	('Massachusetts','Mid-American',NULL),
	('Memphis','American',NULL),
	('Miami FL','Atlantic Coast',NULL),
	('Miami OH','Mid-American',NULL),
	('Michigan','Big Ten',NULL),
	('Michigan State','Big Ten',NULL),
	('MTSU','Conference USA',NULL),
	('Minnesota','Big Ten',NULL),
	('Mississippi','Southeastern',NULL),
	('Mississippi State','Southeastern',NULL),
	('Missouri','Southeastern',NULL),
	('Missouri State','Conference USA',NULL),
	('Navy','American',NULL),
	('Nebraska','Big Ten',NULL),
	('Nevada','Mountain West',NULL),
	('New Mexico','Mountain West',NULL),
	('New Mexico State','Conference USA',NULL),
	('North Carolina','Atlantic Coast',NULL),
	('North Carolina State','Atlantic Coast',NULL),
	('North Texas','American',NULL),
	('Northern Illinois','Mid-American',NULL),
	('Northwestern','Big Ten',NULL),
	('Notre Dame','FBS Independents',NULL),
	('Ohio U.','Mid-American',NULL),
	('Ohio State','Big Ten',NULL),
	('Oklahoma','Southeastern',NULL),
	('Oklahoma State','Big 12',NULL),
	('Old Dominion','Sun Belt','East'),
	('Oregon','Big Ten',NULL),
	('Oregon State','Pac-12',NULL),
	('Penn State','Big Ten',NULL),
	('Pittsburgh','Atlantic Coast',NULL),
	('Purdue','Big Ten',NULL),
	('Rice','American',NULL),
	('Rutgers','Big Ten',NULL),
	('Sam Houston','Conference USA',NULL),
	('San Diego State','Mountain West',NULL),
	('San Jose State','Mountain West',NULL),
	('SMU','Atlantic Coast',NULL),
	('South Alabama','Sun Belt','West'),
	('South Carolina','Southeastern',NULL),
	('South Florida','American',NULL),
	('Southern Miss','Sun Belt','West'),
	('Stanford','Atlantic Coast',NULL),
	('Syracuse','Atlantic Coast',NULL),
	('Temple','American',NULL),
	('Tennessee','Southeastern',NULL),
	('Texas','Southeastern',NULL),
	('Texas A&M','Southeastern',NULL),
	('Texas Christian','Big 12',NULL),
	('Texas State','Sun Belt','West'),
	('Texas Tech','Big 12',NULL),
	('Toledo','Mid-American',NULL),
	('Troy','Sun Belt','West'),
	('Tulane','American',NULL),
	('Tulsa','American',NULL),
	('UCLA','Big Ten',NULL),
	('UNLV','Mountain West',NULL),
	('USC','Big Ten',NULL),
	('Utah','Big 12',NULL),
	('Utah State','Mountain West',NULL),
	('UTEP','Conference USA',NULL),
	('UTSA','American',NULL),
	('Vanderbilt','Southeastern',NULL),
	('Virginia','Atlantic Coast',NULL),
	('Virginia Tech','Atlantic Coast',NULL),
	('Wake Forest','Atlantic Coast',NULL),
	('Washington','Big Ten',NULL),
	('Washington State','Pac-12',NULL),
	('West Virginia','Big 12',NULL),
	('Western Kentucky','Conference USA',NULL),
	('Western Michigan','Mid-American',NULL),
	('Wisconsin','Big Ten',NULL),
	('Wyoming','Mountain West',NULL);

--Teams
INSERT INTO Poll.Team (Name)
    SELECT Name
    FROM #TempTeamInfo
    WHERE Name NOT IN (
        SELECT DISTINCT Name
        FROM Poll.Team
    );

--2025 FBS TeamVersion
DECLARE @FBSID INT = (
	SELECT TOP 1 ID 
	FROM Poll.League 
	WHERE Name = 'FBS'
);
DECLARE @SeasonID INT = (
	SELECT TOP 1 ID 
	FROM Poll.Season 
	WHERE [Year] = @Year
);
INSERT INTO Poll.TeamVersion (TeamID, SeasonID, LeagueID, ConferenceID, DivisionID)
	SELECT t.ID, @SeasonID, @FBSID, c.ID, d.ID
	FROM #TempTeamInfo tt
	LEFT JOIN Poll.Team t
		ON tt.Name = t.Name
	LEFT JOIN Poll.Conference c
		ON tt.Conference = c.Name
	LEFT JOIN Poll.Division d
		ON tt.Division = d.Name
	WHERE t.Name NOT IN (
        SELECT DISTINCT Name
        FROM Poll.Team t
		JOIN Poll.TeamVersion tv
			ON t.ID = tv.TeamID
    );
GO