A tool that allow you to write Blackberry mobile device applications using C#.

# Version 0.5: New Compiler + Platform Going Forward #

First versions of the compiler up to version 0.3 took a C# application and convert it into Java, compiled and then run on the Blackberry device.

The method above works but have problems:

1) Conversion of C# into Java... this is a very complicated task for the compiler since both languages are very different. <br />
2) Full support for the Blackberry OS APIs... Yes this is a very big task... The library support version 4.x to date but new OS 5.0 and 6.0 added a lot of additional APIs... To support these APIs are a big task to make sure that the library/run-time is always up to date. <br />
3) New platforms like Blackberry Playbook tablet PC not to support Java for awhile. Currently this platform supports only Adobe AIR and WebWorks support to b added next year around Feb 2011.<br />

Because of above reasons I had to re-architect the compiler... So the next compiler and toolkit (the run-time etc) version 0.5 will run on top of the WebWorks framework. WebWorks use HTML 5, CSS, JavaScript to run applications on top of the latest Blackberry 5.0 and later devices.

What about the existing code base? The existing version up to 0.4 will be maintained and then discontinued... We will focus on targeting Blackberry 5.0 and later devices only but support will cater for Blackberry 4.x devices in version 0.6 using PhoneGap as a platform.

## How Can I Contribute ##

Join the developer mailing lists, pull the source down from sub-version and start to use the tool.
Please follow instructions in the Wiki page if you wish to contribute a patch which can b additional features, a bug fix etc.

Finally this is a community project... lets work on it together to make Blackberry development easy!