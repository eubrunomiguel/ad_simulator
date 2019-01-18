# Autonomous Drive Simulator

This project aims to create a live 3D representation for the @autonomousDrive project.

It receives http::get requests to update the main actor position.
It continously sends http::get requests to the main server, to query all the objects in the map and then create a 3D representation for each reported object with its respective position.

To integrate on your @autonomousDrive project, simply add a http::get to your main loop, in order to update your position. Example in Python: 
```
urllib2.urlopen("http://<ip>:<port>?carId=<carId>&position=<carPosition>)
```

## Usage

Compile it using your Unity client

## Builds

Available Builds for MAC and Windows 32b on builds folder

## Pictures

![alt text](https://i.imgur.com/3DzqrCn.png)

![alt text](https://imgur.com/iI1oij5)
