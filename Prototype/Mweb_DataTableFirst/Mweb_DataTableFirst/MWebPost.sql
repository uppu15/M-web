﻿--merge into Userss as Target
--using (values
--		('June', 'a@a.com', '1234', 'verified'),
--		('Ivan', 'i@i.com', 'qwer', 'notverified')
--	)
--as source (userName, userEmail, userPassword, userStatus)
--on Target.userID = Source.userID
--when not matched by Target then
--insert (userName, userEmail, userPassword, userStatus)
--values (userName, userEamil, userPassword, userStatus);

--merge into Markers as Target
--using (values
--		(1, 32.0000, -117.0000, 'photo.png', 'asdf'),
--		(2, 33.0000, -117.5000, 'photo.jpeg', 'zxcv')
--	)
--as source (userID, markerLat, markerLng, photo, photoPath)
--on Target.userID = source.userID
--when not matched by Target then
