# Dashboard_DALI
This is a cross platform application built with Unity.
The application downloads json strings and image files from acquired urls and displays necessary information in a visually orgnanized manner.

## Game Objects
### Scene 1
1) Main Camera
2) Photo Frames
```
1) A single click on a photo will display the member information on the right panel of the canvas.
2) A double click on a photo will launch a new scene with a globe, where the selected member's location is highlighted in red and every other member's location is marked with yellow square.
```
3) Chalkboard
```
Chalkboard is a panel on top of which member information will be displayed.

There are 2 user-interactive texts overlaid on top of the chalkboard: 1) Prev and 2) Next

1) A click on prev will load 5 previous images.
2) A click on next will load 5 next images.
```
4) Static Variable
```
An empty game object is used to store cross-scenes data.

Such include:

1) Selected Member Object
2) Json object necessary for data visualizer
```
### Scene 2
1) Globe
2) Data Visualizer
```
Whenever Data Visualizer is launched, it will instantiate a game object to mark every DALI member's location (information received via static variable).

And it highlights the location of the selected member in red, and scales the point prefab 150% larger.
```
3) Point Prefab
```
Is a uniform game object used to mark each member location.
```
4) Static Variable
```
Serves the same purpose as that in Scene 1.
```
## Work Flow
Once the application launches, the script attached to the main camera blocks the rest of the process to make an initial download for the necessary json array.

Once the download is complete, json array is parsed into json objects via custom written function as Unity does not support Json Arrays yet. The parsed json objects will be initialized as a json objects, which will be used by other game objects within the scene.

There are 5 photo game objects; every time they are signaled, they download an image from the designated url to display on top.

Once a double-click on a photo object is detected, a new scene will be launched after storing necessary data in Static Variable object; doing so allows transmitting necessary information over to globe scene and also restoring necessary information once the user returns to the first scene (Downloaded member objects, Displayed information on the chalkboard, order of photos, etc.).

## Final Note
This project was an engaging challenge for me as this marks my first time using Unity and C#. There were many new concepts that I was not familiar with, such as Mesh, Scene, GameObject, etc. However, thanks to Unity Tutorial, Online Resources, and a help from one of DALI members, I was able to learn my way through.
