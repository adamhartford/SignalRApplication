# .NET Core + Nancy + SignalR

An example project using DNX/DNU, Nancy, and SignalR. I used:

* Mac OS 10.11 running Mono 4.3.0
* DNX runtime 1.0.0-rc1-update1
* Visual Studio Code

## Running

* `cd SignalRApplication`
* `dnu restore`
* `bower install`
* `dnx web`

Browse to localhost:5000 and click the "Send Simple Message" button to invoke a SignalR server method. I'm using this project to demo [SwiftR](https://github.com/adamhartford/SwiftR "SwiftR"), a SignalR "client" for Mac/iOS.