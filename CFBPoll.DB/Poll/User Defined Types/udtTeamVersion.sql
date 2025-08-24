CREATE TYPE Poll.udtTeamVersion AS TABLE
(
	TeamName VARCHAR(50) NOT NULL,
	Conference VARCHAR(50) NOT NULL,
	Division VARCHAR(50) NULL,
	Season INT NOT NULL
);