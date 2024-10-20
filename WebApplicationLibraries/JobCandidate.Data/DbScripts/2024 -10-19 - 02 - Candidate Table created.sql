USE JobCandidate;

GO

CREATE TABLE Candidates (
	CandidateId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName nvarchar(250) NOT NULL,
	LastName nvarchar(250) NOT NULL,
	PhoneNumber nvarchar(50),
	Email nvarchar(250) NOT NULL UNIQUE,
	TimeToCall nvarchar(250),
	LinkedInUrl nvarchar(500),
	GitHubUrl nvarchar(500),
	Comment nvarchar(max) NOT NULL
);