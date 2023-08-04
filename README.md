# SunbaseData-Assignment
Submission for SunbaseData Assignment

## Task 1: Client Data Display

### API Address
API Address: [https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data](https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data)

### Overview
For Task 1, I have created a Unity project to fetch client data from the provided API and display a list of clients. 
The list contains client labels and points, and there is a filtering dropdown to view all clients, managers only, or non-managers. 
When clicking on a client in the list, a popup window displays the client's name, points, and address. 
To make the UI more engaging, I have implemented simple animations using DOTween whenever the user clicks on a menu item.
Additionally, I have ensured that the UI layout is responsive.

### Demo
https://github.com/Th0masCat/SunbaseData-Assignment/assets/74812563/ba205508-7d46-41a0-a6b0-af3cc89fedbb

### Implementation Details
1. I made a web request to the provided API URL to fetch the JSON data containing client information(UnityWebRequest).

2. The fetched data was used to populate a list of clients. Each client in the list displays their label and points.

3. I have added a filtering dropdown that allows users to filter the list based on "All clients," "Managers only," or "Non-managers only."

4. A popup window was created to show client details when a client is clicked in the list.

5. To make the UI more visually appealing, I have used DOTween for smooth animations when showing/hiding the popup window and transitioning between filtered views.



## Task 2: Circle-Line Game

### Overview
For Task 2, I have made a game users can draw a line using their cursor or finger.
When they lift their finger or release the mouse after drawing a line, all circles intersecting the line disappear with a smooth scaling animation. 
A restart button that resets the scene, places circles at random positions, and allows users to draw again has also been added.

### Implementation Details
1. I spawned 5 circles at random position.

2. I have used line renderer to draw the lines on the screen.

3. Using collision detection between the line and the circle colliders, an array of gameobjects is filled whenever the user draws over a circle.

4. When the user lifts their finger from the mouse button, the line is destroyed and the objects that had a line on them get deactivated
(I don't destroy them since that would lead to unnecessary instantiation of new prefabs, this effectively creates a mini object pooling system and helps me recycle the same)  

6. A "Restart" button was provided, which resets the scene, reactivates all circles, and allows users to draw again.

### Dependencies
- Unity Engine: Unity was used to develop and run the project. Version: 2022.3.0
- DOTween

### Demo
https://github.com/Th0masCat/SunbaseData-Assignment/assets/74812563/bec2bead-d363-489a-a8aa-9b49d5b51caf


## Instructions to Run
1. Clone the project repository to your local machine.

2. Open the Unity project in Unity Editor.

3. Import and set up the DOTween plugin.

4. Navigate to the "Scenes" folder where you can find Task 1 and test it in the Unity Editor. Similarly you can test out Task 2 from the same folder.

Thank you for considering my submission!💖

Made by [Sahil Jangra](https://github.com/Th0masCat)
