# Mweb
> Repos for project I am working on at MSSA.  This is only a reference for the future outcome.  This readme will serve me as Readme Whiteboard.

The purpose of this application is to empower the image features on the google map (During research, I learned that google actually alraedy have exact same feature as my application is intending to do.  However, I would like to create this project only using my own code).  Let users upload photos, so that others who visit the location will have better understanding of the location.

## Table of Contents


[1. Database Diagram](#1-database-diagram)

[2. Entity Relationship Diagram](#2-entity-relationship-diagram)

[3. Requirements Traceability Matrix](#3-requirements-traceability-matrix)

[4. UML](#4-uml)

[5. Wireframe sketch](#5-wireframe-sketch)

[6. Task list](#6-task-list)

## 1. Database Diagram
preliminary tables.
![database](https://i.imgur.com/z5mGIAY.jpg)

I originally thought to create seperate view page for forum to have users talk about photos.  I later come to think that it will be better to have a little comment section like how facebook have it rather than having user navigate away from the photo they are looking at.

![new_database](https://github.com/uppu15/M-web/blob/master/Sources/New_databasediagram20190928.JPG?raw=true)


[Top](#table-of-contents)

## 2. Entity Relationship Diagram
![ERD](https://i.imgur.com/Xiyfv0E.png)


[Top](#table-of-contents)

## 3. Requirements Traceability Matrix
https://github.com/uppu15/M-web/blob/master/Sources/RTM.xlsx


[Top](#table-of-contents)

## 4. UML
![UML](https://github.com/uppu15/M-web/blob/master/Sources/UML_edit.jpg?raw=true)


[Top](#table-of-contents)

## 5. Wireframe Sketch

![FirstLook](https://i.imgur.com/0aeOKFV.jpg)
First look at the UI before log in.  I find the UI of PC version of Google Maps very simple and thus very easy to navigate around.  I purposely tried to avoid having multiple pages so the users do not have to navigate away from the map.  I decided to replicate Google's UI on my project then take away and add some according to my object for the project.


![Logged in](https://i.imgur.com/CzdQwAh.jpg)
Log in to see use comment section.  At first, all and only UI that will be shown to users are Google Maps default UI, left hamburger menu button and search bar which will be place on top left of the screen and log in button which will be placed on top right of the screen.  Users will still be able to locate markers and see the contents ( photo and comments if there is any ), but will not be able to upload or set settings for the google map.


![UsePin](https://i.imgur.com/WtI5xJp.jpg)
Use of Pin.  Ultimately, logged-in users will be able to set option to set the distance where markers ( post ) will be shown on the map from the clicked location.  By default, my application will set it to '500' distance on Google Maps API.


![userbubble](https://i.imgur.com/cfVyGdU.jpg)
What is on the right? Upon logging in, the button that was used to call panel for Log in panel will either be replaced by a account menu like edit account information or delete account, or be set to invisible.  In return, logging in also will set button for user setting panel visible.  This panel will have a welcome greeting on the top, another set of sliding panels for settings, albums and log-out. 

![album look](https://i.imgur.com/DpyYMBr.jpg)
How one can access their own album.  Sliding panels will be placed right below 'Settings' and 'Albums' section on option panel.  Clicking each button will trigger to have panel expanded.

![Image](https://i.imgur.com/TCvIXda.jpg)
See pictures.  Just like how any other SNS will project full screen photo.  I would like to set it so that when user click location other than the photo itself, unless moving through series of photos in the marker, photo screen will be turned off and back to main page.

### 5.1 UI in work
![current](https://github.com/uppu15/M-web/blob/master/Sources/UI%20in%20work.JPG?raw=true)

![current1](https://github.com/uppu15/M-web/blob/master/Sources/UI%20in%20work_a.JPG?raw=true)


[Top](#table-of-contents)

## 6. TASK LIST

### TODO:

https://github.com/uppu15/M-web/projects/1
  

[Top](#table-of-contents)
