# Viewer Application


![hello](/images/tutorial_img1.png)

* Install Vuforia package which is available within the Unity software.

Window > Package Manager > VuforiaEngine

Vuforia Engine enables the use of an ARCamera object that can track and detect the image targets (fiducial markers) placed in the surrounding.

![hello](/images/tutorial_img2.png)

To detect image targets(fiducial markers) using Vuforia library. It provides the storage of 1,000 fiducial markers/month.

* Create an account on Vuforia website- Register and Login! - [#Link](https://developer.vuforia.com/vui/develop/licenses).
* Create a new development Key and a license which can be filled in the Unity. Hence, Unity software would be able to access the fiducial markers in the database.

![hello](/images/tutorial_img3.png)

* We can use any number image targets to create an application.
    * In our demonstration, we have used on of the image targets as a pointer_target to be identified uniquely from other targets.
    * Therefore, it is advised to use unique names related to the functions implemented for ease of use.
    

* To create a pointer, simply attach a pointer prefab provided.
    * The pointer prefab is an object that consists of following scripts such as: Select object, CurvedLineComponent, PickandPlace. 
    * Select-object code is responsible for the selection of an object on collision or through head-gaze.
    * Curved-Line-Component code is responsible to draw a line ofsphere object to create a freeform drawing strokes.
    * PickandPlace code is responsible to move the 3D objects from one marker to another.

![hello](/images/tutorial_1.png)


* To know which code can be used to manipulate a 3D object, we have shown an image with an attached script of code.
    * The 3D sphere object should have:
        * A rigidbody component.
        * A scale and rotate code scripts.

![hello](/images/tutorial_2.png)


* The image representated below shows a menu bar beside a fiducial marker. The menu bar can be used to place and add the 3D object on the fiducial marker.

![hello](/images/tutorial_3.png)

