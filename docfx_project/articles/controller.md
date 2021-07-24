# Controller Application
Get started for the development of a handheld controller using Unity Engine. Here, we are demonstrating a walk-through tutorial to create your own controller that would send event notification to the viewer over a server.

* Download and install controller package in the Unity and change the platform to Android.
* In the project window (left-corner), you can see the SocketIO folder which is responsible to connect the application with the server and the script folder consists of all the components required to create interactions such as gestures.


![hello](/images/tutorial_img1.png)

* Install Vuforia package which is available within the Unity software.

Window > Package Manager > VuforiaEngine

Vuforia Engine enables the use of an ARCamera object that can track and detect the image targets (fiducial markers) placed in the surrounding.

![hello](/images/tutorial_img2.png)

To detect image targets(fiducial markers) using Vuforia library. It provides the storage of 1,000 fiducial markers/month.

* Create an account on Vuforia website- Register and Login! - [#Link](https://developer.vuforia.com/vui/develop/licenses).
* Create a new development Key and a license which can be filled in the Unity. Hence, Unity software would be able to access the fiducial markers in the database.

![hello](/images/tutorial_img3.png)

* We have developed a simple controller image using canvas and GUI elements. Attach the code from the script folder.

![hello](/images/tutorial_img4.png)

![hello](/images/tutorial_img6.png)


At last, add your IP Address using Wifi of your computer.

![hello](/images/tutorial_img5.png)

# Next:
* Set the resolution of the display according to your mobile screen size.
* Go to players settings > Android > Other Settings > (Identification)Change the Minim. API Compatibility Level to "26 or above".
* (Configuration) API compatibility level -  .Net 4.x.

# Finally:
* Build and run the application to a handheld device.

