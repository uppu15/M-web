--https://developers.google.com/maps/documentation/javascript/mysql-to-maps  //sql ref
--https://developers.google.com/maps/solutions/store-locator/clothing-store-locator#populating-the-table  //locate markers within radius of pin?
--https://developers.google.com/maps/documentation/javascript/tutorial#The_Hello_World_of_Google_Maps_v3
--https://developers.google.com/maps/documentation/javascript/reference/
--Google Map API ref

------------------------------------------------------------------------------------------------------------------------------
use master;
DROP DATABASE IF EXISTS Project;

CREATE DATABASE Project;

USE Project;

------------------------------------------------------------------------------------------------------------------------------

---------------------------------------------User INFO------------------------------------------------------------------------
ALTER TABLE Users_settings
DROP CONSTRAINT FK_Settings_Users;
ALTER TABLE Thread
DROP CONSTRAINT FK_Thread_User;
ALTER TABLE Post
DROP CONSTRAINT FK_Post_User;


DROP TABLE IF EXISTS Users;
CREATE TABLE Userss
(
	userID			int				IDENTITY(1,1)	NOT NULL,	/* Identity = Do not have to enter value */
	userName		varchar(18)						NOT NULL,
	userEmail		varchar(MAX)					NOT NULL,
	userPassword	varchar(50)						NOT NULL,
	created			timestamp,
	userStatus		varchar(19)						NOT NULL,	/* 'EMAIL_NOT_VERIFIED', 'VERIFIED', 'BLOCKED' */

	CONSTRAINT "PK_Users" PRIMARY KEY  CLUSTERED 
	(
		"userID"
	)
);

select * from Users

-----------------------------------------------User Settings------------------------------------------------------------------
DROP TABLE IF EXISTS UserSetting;

CREATE TABLE UserSettings
(
	settingID		int				IDENTITY(1,1)	NOT NULL,
	userID			int								NOT NULL,	/* PRIMARY KEY */
	centerLat		decimal (10,6)					NOT NULL,	/* latitude */
	centerLng		decimal (10,6)					NOT NULL,	/* longitude */
	centerZoom		int								NOT NULL,	/* 0 being world map to 20 being building view per google */
	mapType			varchar(10)						NOT NULL,	/* map? or satellite? */
	pinRadius		int								NOT NULL,	/* how far around the pin user want to look up */
	GPS				bit								NOT NULL,	/* on or off */
	CONSTRAINT "PK_Setting" PRIMARY KEY CLUSTERED("settingID"),
	CONSTRAINT "FK_Settings_Users" FOREIGN KEY
	("userID") REFERENCES "Userss" ("userID")
);

select * from UserSetting

-------------------------------------------------Pins on the map--------------------------------------------------------------

DROP TABLE IF EXISTS Marker;


CREATE TABLE Markers
(
	markerID		int				IDENTITY(1,1)	NOT NULL,
	userID			int								NOT NULL,
	markerLat		decimal (10,6)					NOT NULL,    
	markerLng		decimal (10,6)					NOT NULL,
	photo			"image"							NOT NULL,
	photoPath		varchar(255)					NOT NULL,
	CONSTRAINT "PK_Marker" PRIMARY KEY
	("markerID"),

	CONSTRAINT "FK_Marker_User" FOREIGN KEY
	("userID") REFERENCES "Userss" ("userID")
);

select * from Marker
----------------------------------------------Comment--------------------------------------------------
DROP TABLE IF Exists Comment
CREATE TABLE Comments
(
	commentID		int					IDENTITY(1,1)		NOT NULL,
	markerID		int										NOT NULL,
	userID			int										NOT NULL,
	comment			nvarchar(MAX)							NOT NULL
	CONSTRAINT "PK_Comment" PRIMARY KEY ("commentID"),
	CONSTRAINT "FK_Comment_Marker" FOREIGN KEY ("markerID") REFERENCES "Markers" ("markerID"),
	CONSTRAINT "FK_Comment_User" FOREIGN KEY ("userID") REFERENCES "Userss" ("userID")
);

----------------------------------------------Forum------------------------------------------------------------
--DROP TABLE IF EXists Forum;

--CREATE TABLE Forum
--(
--	threadid		int				NOT NULL,
--	threadtitle		varchar(100)	NOT NULL,
--	num_comment		int				NOT NULL

--	CONSTRAINT "PK_Thread" Primary KEY
--	("threadid")
--);

--select * from Forum

----------------------------------------------Thread under Forum----------------------------------------------------------------
--ALTER TABLE Post
--DROP CONSTRAINT FK_Post_Thread;

--DROP TABLE IF EXISTS Thread;

--CREATE TABLE Thread
--(
--	threadid		int				NOT NULL,
--	threadtitle		varchar(100)	NOT NULL,
--	userid			int				NOT NULL,	/* Foreign key */
--	created			DATE

--	CONSTRAINT "FK_Thread_Forum" FOREIGN KEY
--	("threadid") REFERENCES "Forum" ("threadid"),

--	CONSTRAINT "FK_Thread_User" FOREIGN KEY
--	("userid") REFERENCES "Users" ("userid")
--);

--select * from Thread

--------------------------------------------Post under Thread under Forum-------------------------------------------------------
--ALTER TABLE Post
--DROP CONSTRAINT "FK_Post_Forum"
--ALTER TABLE Post
--DROP CONSTRAINT "FK_Post_User"

--DROP TABLE IF EXISTS Post;

--CREATE TABLE Post
--(
--	postid			int				NOT NULL,
--	content			varchar(1000)	NOT NULL,
--	threadid		int				NOT NULL,	/* Foreign Key */
--	userid			int				NOT NULL,	/* Foreign Key */
--	post_title		varchar(100)	NOT NULL,
--	created			TIMESTAMP

--	CONSTRAINT "PK_postid" PRIMARY KEY CLUSTERED
--	("postid"),
	
--	CONSTRAINT "FK_Post_Forum" FOREIGN KEY
--	("threadid") REFERENCES "Forum" ("threadid"),

--	CONSTRAINT "FK_Post_User" FOREIGN KEY
--	("userid") REFERENCES "Users" ("userid")	
--);

--select * from Post

--INSERT
------------------------------------------------------------------------------------------------------------------------------
--DROP SEQUENCE IF EXISTS userIDGEN 
--CREATE SEQUENCE userIDGen AS INT
--	START WITH 00001
--	NO CYCLE;

INSERT INTO Users (userid, username, user_email, user_password, user_status)
VALUES
	(00000, 'ADMIN', 'admin@admin.com', 'admin1234', 'ADMIN'),
	(00001, 'qwerty', 'qwerty@gmail.com', '1234qwer', 'EMAIL_NOT_VERIFIED'),		--CURRENT_TIMESTAMP syntax doesn't work?
	(00002, 'asdfgh', 'asdfgh@yahoo.com', '5678tyui', 'VERIFIED'),
	(00003,	'zxcvbn', 'zxcvbn@dandomain.com', 'asdfzxcv', 'BLOCKED'),
	(00004, 'Garrosh Hellscream', 'def@orgrimmar.com', 'ghjkbnm,', 'VERIFIED'),
	(00005, 'Sylvanas Windrunner', 'abc@undercity.com', '1qaz2wsx', 'VERIFIED');

------------------------------------------------------------------------------------------------------------------------------

INSERT INTO User_settings (userid, map_center_lat, map_center_long, map_zoom, map_type, pin_radius, GPS)
VALUES
	(00001, 32.8141013, -117.1382401, 15.69, 'map', 20, 0),  --20km
	(00002, 33.067438, -117.112678, 8.32, 'satellite', 10, 1),
	(00003, 48.981066, 13.4165815, 5.21, 'map', 5, 0),
	(00004, 48.852896, 2.307749, 13.82, 'map', 5, 1),
	(00005, 50.041856, -5.656938, 13.66, 'satellite', 2, 0);

------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Forum (threadid, threadtitle, num_comment)
VALUES
	(00001, 'Discussion', 3),
	(00002, 'Question And Answer', 2),
	(00003, 'General', 2),
	(00004, 'Plenty of rooms at Hotel California', 0)
	--((select threadid from Thread), (select threadtitle from thread), (	select COUNT(*)	
	--																	from Post
	--																	join Thread 
	--																		on Post.threadid = Thread.threadid
	--																	where ))

------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Thread (threadid, threadtitle, userid, created )
VALUES
	(00001, 'Discussion', 00000, GETDATE()),
	(00002, 'Question and Answer', 00000, GETDATE()),
	(00003, 'General', 00000, GETDATE()),
	(00004, 'Plenty of rooms at Hotel California', 00001, GETDATE())

------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Post (postid, threadid, userid, post_title, content)
VALUES
	(00001, 00001, 00000, 'Discussion about this', 'Welcome to Hotel California'),
	(00002, 00001, 00003, 'Discussion about that', 'Hello World!  INSERT BODY HERE'),
	(00003, 00001, 00004, 'Discuss even more', 'MAIN CONTENT GOES HERE'),
	(00004, 00002, 00000, 'Ask questions here', 'Any question?'),
	(00005, 00002, 00001, 'I have several questions', 'I have several questions about this course'),
	(00006, 00003, 00000, 'This is General forum', 'Anything in your mind just dump here'),
	(00007, 00003, 00005, 'Command me, general', 'At your call')

------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Marker (userid, loc_id, loc_name, loc_address, loc_lat, loc_long, loc_type, loc_photo, photo_path)
VALUES
	(00001, '00003281960001171388', 'Embry-Riddle Aeronautical University', '8799 Balboa Ave #125, San Diego, CA 92123', 32.8196, 117.1388, 'urban',0x15FE,'http://accweb//embryriddle.bmp'),
	(00002, '00003282040001171377', 'Unique Sandwiches', '8865 Balboa Ave # C, San Diego, CA 92123', 32.8204, 117.1377, 'urban', 0x1512, 'http://accweb//uniquesandwiches.bmp'),
	(00003, '00328427460117057257', 'N Fortuna Mountain Summit Trail', 'Unnamed Road, San Diego, CA 92124', 32.842746, -117.057257, 'mountain', 0x1512CF00001010100005FE,'http://accweb//asdf.bmp'),
	(00001, '00338593010118402516', 'Unavailable', 'Unavailable', 33.859301, -118.402516, 'beach', 0x1512CF0000100101000F5FE, 'http://accweb//asdfdfdf.bmp'),
	(00004, '00377274300129898654', 'East Sea', 'East Sea', 37.727430, 129.898654, 'sea', 0x151C2F00000005FE, 'http://accweb/ewioropwqei/work.bmp'),
	(00000, '00228296970026005237', 'Qesm Al Wahat Ad Dakhlah', ',Qesm Al Wahat Ad Dakhlah', 22.829697, 26.005237, 'desert', 0x151C2F0000001005FE, 'http://accweb/qwpoijf/budget.bmp')

------------------------------------------------------------------------------------------------------------------------------


