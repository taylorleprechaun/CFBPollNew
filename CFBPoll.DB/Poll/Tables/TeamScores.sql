CREATE TABLE Poll.TeamScores 
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Week] INT NOT NULL,
	Date DATETIME NOT NULL,
	HomeTeamVersionID INT NOT NULL,
	HomeScore INT NOT NULL,
	AwayTeamVersionID INT NOT NULL,
	AwayScore INT NOT NULL,
	IsNeutralSite BIT NOT NULL DEFAULT 0,
	CONSTRAINT FK_TeamScores_TeamVersion1 FOREIGN KEY (HomeTeamVersionID) REFERENCES Poll.TeamVersion(ID),
	CONSTRAINT FK_TeamScores_TeamVersion2 FOREIGN KEY (AwayTeamVersionID) REFERENCES Poll.TeamVersion(ID),
	CONSTRAINT UC_TeamScores_Week_HomeTeam_AwayTeam UNIQUE ([Week], HomeTeamVersionID, AwayTeamVersionID)
);