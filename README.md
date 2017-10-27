# Windows Spotlight Wallpaper
If you enjoy the windows spotlight images and would like to have a copy of the pictures locally or have the same windows background as the dynamic spotlight lockscreen, this simple tool will help you. 


## Features

- Copy cached spotlight images to your pictures
- Schedule to synchronize windows spotlight images
- Set the current spotlight as your wallpaper


## How To Use

You can either run the application manually or schedule it, for example using the windows task scheduler.
The app takes arguments in order to do anything. Currently you can use **copy**, **set**, **hide** and **help**.

For a complete list of available options, refer to the wiki or run the app with using **help**:
```PowerShell
C:\Projects\WindowsSpotlightWallpaper>.\WindowsSpotlightWallpaper.exe help
```

#### Create a windows shortcut to the executable:

Create a simple shortcut to the executable using the arguments needed and run it manually or using your own methods. 

_Example for a shortcute using arguments:_

![Windows shortcut example](https://github.com/RaulSebastian/WindowsSpotlightWallpaper/blob/master/documentation/assets/shortcut.png)


#### Schedule using the windows task scheduler

Open the windows scheduler and a basic task with the action to start a program. Dont forget to add the arguments. Use **hide** as one of the arguments to run silently and not bother you every time it runs.

_One possible trigger that should cover setting the wallpaper whenever the spotlight changes:_

![Windows shortcut example](https://github.com/RaulSebastian/WindowsSpotlightWallpaper/blob/master/documentation/assets/winSchedulerTrigger.png)

You can also use reocuring schedules or combine different triggers. 

Another possible usage would be to schedule the app for **copy** only and use a slideshow as windows background, referencing the copy outputfolder ```C:\Users\[current]\Pictures\Spotlight```. Right now, there is no option to change the output folder, yet it is a planed feature.


## Download

You can [download](https://github.com/RaulSebastian/WindowsSpotlightWallpaper/releases/tag/v1.1.0) latest version for Windows 10.


## Build from source 

To build and run this application from the source, you'll need .NET Framework 4.0 or newer.
The current app can bei either built opening the solution in visual studio or using **msbuild.exe**.

_Example for a command line using msbuild:_
```
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild "C:\Projects\WindowsSpotlightWallpaper\source\WindowsSpotlightWallpaper\WindowsSpotlightWallpaper.csproj" /p:Configuration=Release;PackageAsSingleFile=False; outdir=C:\Projects\WindowsSpotlightWallpaper\Release\
```

## Contribute

Feel free to clone, send pull requests or fork this repository.


## License

[Apache Version 2.0](https://github.com/RaulSebastian/WindowsSpotlightWallpaper/blob/master/LICENSE)


## Credits

This software uses .NET native labraries only. 
