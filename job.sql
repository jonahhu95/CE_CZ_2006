CREATE DATABASE IF NOT EXISTS job;

USE job;

CREATE TABLE IF NOT EXISTS user_t(
id					INT 						NOT NULL 		AUTO_INCREMENT,
username 		VARCHAR(40)	NOT NULL,
pws				VARCHAR(40)	NOT NULL,
PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS score_t(
id						INT 				NOT NULL		AUTO_INCREMENT,
username 				VARCHAR(40)			NOT NULL,
datet					TIMESTAMP			NOT NULL,
workLocation			VARCHAR(80)			NOT NULL,
workLongitude			FLOAT				NOT NULL,
workLatitude			FLOAT				NOT NULL,
workArea				VARCHAR(80)			NOT NULL,
homeLocation			VARCHAR(80)			NOT NULL,
homeLongitude			FLOAT				NOT NULL,
homeLatitude			FLOAT				NOT NULL,
homeArea				VARCHAR(80)			NOT NULL,
salary					INT 				NOT NULL,
salarySat				INT 				NOT NULL,
medianSalary			INT					NOT NULL,
jobInterest				INT 				NOT NULL,
commuteType				CHAR				NOT NULL,
ridersArea				INT					NOT NULL,
AvgRidersArea			INT					NOT NULL,
commuteTime				FLOAT 				NOT NULL,
AvgCommuteTime			FLOAT				NOT NULL,
monthCost				FLOAT				NOT NULL,
PRIMARY KEY(id,username,datet)
);

CREATE TABLE IF NOT EXISTS feedback_t(
id							INT 									NOT NULL		AUTO_INCREMENT,
username			INT 									NOT NULL,
feedback				NVARCHAR(500) 			NOT NULL,
PRIMARY KEY(id)
);

