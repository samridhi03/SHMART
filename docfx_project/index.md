# SHMART - Simple Head-Mounted Marker-based Augmented Realty Toolkit 

![Image testing](./images/PNG_transparency_demonstration_1.png)


[![](./images/application.png)](https://drive.google.com/drive/u/0/folders/1kQ5BDMqjmCQr5vpDzNKsZwKKBIIUBLJj "")



SMART is a C# language plug-in that provides developers with a set of components and features used to create a rapid prototype of a cross-device Augmented Reality application in Unity.

One of the tricky parts of an AR application development is implementing the interactions among virtual images/objects which are exactly aligned with real world objects. Either you can use hand-held mobile device (HHD)) to interact with the objects using surface gestures or use head-mounted device (HMD)and change the pose (position and orientation) of an object using hand gestures. However, both HHD and HMD have pros and cons. Currently, HMD such as Google Glass and Microsoft HoloLens are advanced AR technology developed for training purposes and expensive in cost; hand-held devices have a field-of-view limited to mobile screen. In our work, the capabilities of both displays have been used to create a hybrid ARsystem.   A  simple  approach  of  using  Handheld  device  as  both  input  device  and  a display (i.e., smartphone attached on top of Samsung Gear headset ) is adopted to develop immersive, high-fidelity, interactive, and affordable prototypes.

This guide contains a complete description of the SMART library, how to install it, and how to use its functionality in AR applications. Examples are provided for better understanding the functions.

## Contents

# Getting started and Setting up SMART
* [Introduction](#introduction)
* [Installation Checklist](#installation_checklist)
* [Unity Setup](#unity_setup)
* [Getting Started](#getting_started)
* [Examples](#examples)
* [Live Demo](#live_demo)
* [Walkthough](#walthrough)


# Introduction
SMART is a collection of components and features, designed to be linked into application programs, and you must upload it on Unity software and build it to Android platform. 

Functions:
* Provides cross-device support and building blocks for 3D interactions in Augmented Reality.
* Enables rapid prototyping via components provided in the toolkit.

  
# Installation Checklist

Tools

Unity Hub and Unity 2019 (16.8 or above)
#[Link] To install the Unity Hub and Unity for Windows visit 

Visual Studio 2019 (16.8 or above)
#[Link] (https://visualstudio.microsoft.com/vs/unity-tools/)

Android Studio
#[Link] (https://developer.android.com/studio)
+ Add tools to the PATH.

Vuforia SDK
#[Link] (https://developer.vuforia.com/downloads/sdk)

*We are using Vuforia SDK for tracking and mapping the QR markers to anchor the objects in the physcial environment. Vuforia library uses computer vision technique to detect the feature points of an Image and map a 3D/2D object to a marker.

*You must have an account and a license to use the Vuforia library within Unity Engine.

## Unity Setup

*Before you get started with the application [#Link][Add Images for each step]

1. Launch Unity.
2. File > Build Settings > Switch Platform to Android.
3. Go to Player Settings > Scroll down to XR Settings > Check Virtual Reality Supported.
4. + Add Cardboard settings.
5. In "Other Settings" tab > Identification > Change Minimum API Level >= 25.
6. Set the screen resolution 2960 x 1440 portrait.

## Getting Started

* Import the two packages: Viewer [#Link] and Controller [#Link] to the Unity GameEngine.
* Explore the Assets folders in project window.
* Add ARCamera to the hierarchy window.
  * Add Vuforia License Key from your account.
  * Add Images to the website and download the Unity editor database.
* Add SocketIOComponent Prefab from Assets.
  * Add the server IP Address.
  
For more details refer the tutorials [#Link] and examples [#Link].

# Controller Application
* Install the controller application package into the Unity Game Engine.
* Select the main-scene from the assets.
* Build the application onto Android.
* Test all the surface gestures.

**Hold the mobile phone in the landscape mode**

# Gestures:

Center Screen
* Swipe Up/Swipe Down
* Swipe Left/ Swipe Right
* Pinch and Pan Gesture using two-fingers

Top_Left Button
* Single Tap

Bottom_Left Button
* Accelerometer

Top_Right Button
* Hold

Bottom_Right Button
* Rotation


# Viewer Application (State of the World)


## Features:

* Translate
* Rotate
* Placement (Pick and Place)
* Scale

## Examples

* Drawing Application
* Car Controller
















# This is the **HOMEPAGE**.
Refer to [Markdown](http://daringfireball.net/projects/markdown/) for how to write markdown files.
## Quick Start Notes:
1. Add images to the *images* folder if the file is referencing an image.
