
### Entrance Criteria

| TestNo.      | Test Description | Test Method |
| -----------: | :--------------- | :---------: |
| 1.1 | Application will support Register |  |
| 1.1.1 | application shall have a link to register view | Inspection |
| 1.1.2 | Application shall have register view | Inspection |
| 1.1.3 | Application shall keep user data in database | Analysis |
| 1.1.4 | Application shall encrypt input password | Analysis |
| 1.2 | Application will support login |  |
| 1.2.1 | application shall have an access(button) to log in form | Analysis |
| 1.2.2 | application shall have a form section for log in | Analysis |
| 1.2.3 | application shall encrypt input password and compare that to database | Analysis |
| 1.2.4 | application shall store log in data | Analysis |
| 1.3 | Application will support edit log-in data |  |
| 1.3.1 | application shall have view page to change user's log-in data | Inspection |
| 1.3.2 | application shall have access to edit user info form | Inspection |
| 1.3.3 | application shall have edit view | Demonstration |
| 1.3.4 | application shall have account detail view for users | Inspection |
| 1.4 | Application will let users delete account |  |
| 1.4.1 | application shall have access to delete account trigger | Demonstration |
| 1.4.2 | application shall delete the particular context from Db | Demonstration |
| 1.5 | Application will have index page for administrative purpose |  |
| 1.5.1 | application shall have authentication | Analysis |
| 1.5.2 | application shall not provide access to admin page to users | Analysis |
| 1.5.3 | Application shall have roles(users,admin) | Analysis |
| 2.1 | Application will implement map |  |
| 2.1.1 | Application shall project a map | Inspection |
| 2.1.2 | Map shall show dynamic views | Demonstration |
| 2.1.3 | Application shall have location search so users can check a place easier | Demonstration |
| 2.1.4 | Application will ask for permission to track user location | Inspection |
| 2.1.5 | Application shall have center button in case user permits user location tracker | Inspection |
| 2.2 | Application will show data on the map | Inspection |
| 2.2.1 | Application shall project a marker at a location where user saved a photo | Test |
| 2.2.2 | Application shall show image on top of marker | Demonstration |
| 2.2.3 | Application shall show selected images on the left panel | Demonstration |
| 2.2.4 | Application shall show comments saved onto images on the left panel | Demonstration |
| 2.3 | Modify markers |  |
| 2.3.1 | Application shall let users modify/delete photos | Inspection |
| 2.3.2 | Application shall let users modify/delete comments | Inspection |

### Requirements Tracebility

|       | User Login | Marker Creation | Marker Handling | Website Layout |
| ----: | :--------: | :--------------: | :--------------: | :------------: |
| 1.1 | | | | |
| 1.1.1 | | | | OK |
| 1.1.2 | | | | OK |
| 1.1.3 | OK | | | |
| 1.1.4 | OK | | | |
| 1.2.1 | | | | OK |
| 1.2.2 | | | | OK |
| 1.2.3 | OK | | OK | |
| 1.2.4 | OK | | OK | |
| 1.3 | | | | |
| 1.3.1 | | | | OK |
| 1.3.2 | | | | OK |
| 1.3.3 | | | | OK |
| 1.3.4 | | | | OK |
| 1.4 | | | | |
| 1.4.1 | | | | OK |
| 1.4.2 | OK | | | |
| 1.5 | | | | |
| 1.5.1 | OK | | | |
| 1.5.2 | OK | | | |
| 1.5.3 | OK | | | |
| 2.1 | | | | |
| 2.1.1 | | | | OK |
| 2.1.2 | | | | OK |
| 2.1.3 | | | | OK |
| 2.1.4 | | | | OK |
| 2.1.5 | | | | OK |
| 2.2 | | | | | 
| 2.2.1 | | OK | | |
| 2.2.2 | | OK | | |
| 2.2.3 | | OK | | |
| 2.2.4 | | OK | | |
| 2.3 | | | | |
| 2.3.1 | | | OK | |
| 2.3.2 | | | OK | |

### Exit Criteria

| TestNo. | Status | Build | TimeStamp | Requirement |
| ----: | :--------: | :--------------: | :--------------: | :------------: |
| 1.1 | Not Implemented | | 11/3/2019 | User Login |
| 1.1.1 | Passed | | 11/3/2019 | |
| 1.1.2 | Passed | | 11/3/2019 | |
| 1.1.3 | Passed | | 11/3/2019 | |
| 1.1.4 | Failed | | 11/3/2019 | |
| 1.2.1 | Passed | | 11/3/2019 | |
| 1.2.2 | Passed | | 11/3/2019 | |
| 1.2.3 | Failed | | 11/3/2019 | |
| 1.2.4 | Passed | | 11/3/2019 | |
| 1.3 | | | | |
| 1.3.1 | Passed | | 11/3/2019 | |
| 1.3.2 | Failed | | 11/3/2019 | |
| 1.3.3 | Passed | | 11/3/2019 | |
| 1.3.4 | Passed | | 11/3/2019 | |
| 1.4 | | | | |
| 1.4.1 | Failed | | 11/3/2019 | |
| 1.4.2 | Passed | | 11/3/2019 | |
| 1.5 | | | | |
| 1.5.1 | Failed | | 11/3/2019 | |
| 1.5.2 | Failed | | 11/3/2019 | |
| 1.5.3 | Failed | | 11/3/2019 | |
| 2.1 | | | | |
| 2.1.1 | Passed | | 11/3/2019 | |
| 2.1.2 | Passed | | 11/3/2019 | |
| 2.1.3 | Passed | | 11/3/2019 | |
| 2.1.4 | Passed | | 11/3/2019 | |
| 2.1.5 | Passed | | 11/3/2019 | |
| 2.2 | | | | | 
| 2.2.1 | Passed | | 11/3/2019 | |
| 2.2.2 | Passed | | 11/3/2019 | |
| 2.2.3 | Passed | | 11/3/2019 | |
| 2.2.4 | Passed | | 11/3/2019 | |
| 2.3 | | | | |
| 2.3.1 | Failed | | 11/3/2019 | |
| 2.3.2 | Failed | | 11/3/2019 | |

67% Tests currently passed

### Findings
 - Need work on authentication / authorization
 - Need work on comment controller / partial view
 - All map related features (non-Users/UserSetting/Comment controllers) work as intended
