# Version 0.2.0 Release #

Version 0.2.0 binaries are available for download.
This include binaries only, source code can be retrieved via SVN.

The compiler call both the Microsoft C# compiler and the final Blackberry compiler to create the binary file that can be deployed to the simulator or a real device.

# Setup #

Extract and install in any folder.
Edit "CS4BB.exe.config":

- BlackberryCompilerBin: Location to the Blackberry API where rapc.exe is located.<br>
- BlackberryCompilerLib: Location to the main Blackberry API library JAR (net_rim_api.jar)<br>
- CSFolder: Location to where you installed CS4BB.<br>

<h1>What Is Next?</h1>

Next am going to focus on the library to port more of the Blackberry API over to the C# library (CS4BBLib.dll) as well as more examples.