CREATE TABLE Poll.TeamScores 
(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	SeasonID INT NOT NULL,
	[Week] INT NOT NULL,
	[Date] DATETIME NOT NULL,
	HomeTeamID INT NOT NULL,
	HomeScore INT NOT NULL,
	AwayTeamID INT NOT NULL,
	AwayScore INT NOT NULL,
	IsNeutralSite BIT NOT NULL DEFAULT 0,
	CONSTRAINT FK_TeamScores_Season FOREIGN KEY (SeasonID) REFERENCES Poll.Season(ID),
	CONSTRAINT FK_TeamScores_Team_Home FOREIGN KEY (HomeTeamID) REFERENCES Poll.Team(ID),
	CONSTRAINT FK_TeamScores_Team_Away FOREIGN KEY (AwayTeamID) REFERENCES Poll.Team(ID),
	CONSTRAINT UC_TeamScores_Week_HomeTeam_AwayTeam UNIQUE (SeasonID, [Week], [Date], HomeTeamID, AwayTeamID)
);