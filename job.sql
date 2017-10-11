CREATE DATABASE IF NOT EXISTS job;

USE job;

DROP TABLE user_t;

CREATE TABLE user_t(
id					INT 						NOT NULL 		AUTO_INCREMENT,
username 	VARCHAR(40)	NOT NULL,
pws				VARCHAR(40)	NOT NULL,
PRIMARY KEY(id)
);

DROP TABLE score_t;

CREATE TABLE IF NOT EXISTS score_t(
id							INT 						NOT NULL		AUTO_INCREMENT,
username 			VARCHAR(40)	NOT NULL,
datet					DATETIME			NOT NULL,
score					INT 						NOT NULL,
PRIMARY KEY(id,username,datet)
);

CREATE TABLE IF NOT EXISTS optional_t(
id							INT 						NOT NULL		AUTO_INCREMENT,
username 			VARCHAR(40)	NOT NULL,
datet					DATETIME			NOT NULL,
commuteTime		INT 						NOT NULL,
commuteComfort INT 						NOT NULL,
salary					INT 						NOT NULL,
salarySat				INT 						NOT NULL,
jobInterest			INT 						NOT NULL,
monthRatio			INT 						NOT NULL,
PRIMARY KEY(id,username,datet)
);
