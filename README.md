# xbox-controller-battery-status

A simple personal project. The app is a WPF solution for Windows which uses the open-source [SlimDX library](https://slimdx.org/) to access the recourses of the Xbox 360 controller, and the [Hardcodet WPF NotifyIcon library](http://www.hardcodet.net/wpf-notifyicon) to allow the app to run with a tray icon.
Both of these libraries can be found in "Manage NuGet Packages" from Visual Studio.

Credit goes to [Icon Works](http://www.flaticon.com/authors/icon-works) from http://www.flaticon.com for the battery icon.

## NOTE
**The application currently only works for when the controller is set to Player 1 (usually default)**. Battery status will not be read otherwise.

## When Running
When the application is running, a battery icon will show up in the Windows tray:

![tray icon](http://i.imgur.com/uTCo1FB.png)

## Battery States
There are 5 states in which the battery level will be read as: Full(![full icon](http://imgur.com/qqGGKhZ.png)), Medium (![medium icon](http://imgur.com/M6TKYrG.png)), Low (![low icon](http://imgur.com/fOUMCxb.png)), or Empty (![empty icon](http://imgur.com/mz1Uk98.png)) Charge; or Not Connected (![not connected icon](http://imgur.com/IyQmFJO.png)).

## Tooltips
There are two types of messages that could be given when hovering the mouse over the battery icon:

### When the controller is connected

![tooltip when controller connected, medium charge](http://imgur.com/hfl2Ll6.png)
### When it isn't 

![tooltip when controller not connected](http://imgur.com/BYD5sjR.png)
