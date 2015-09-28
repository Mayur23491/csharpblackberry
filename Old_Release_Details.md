## Version 0.2 Release ##

You can download version 0.2. See Wiki page for information on setup.

## Version 0.2 Work In Progress ##

Version 0.2 is being worked on.

Main goals:

- Port more of the Java examples over to C# together with Blackberry API. <br><br>
- Object oriented programming (OOP) features. <br><br>
- Call the Blackberry compiler. <br><br>

<h2>Version 0.1 Here</h2>

Finally after some hard work version 0.1 is done, the Hello World demo actually compile and run successfully on the Blackberry!! :-)<br>
<br>
The work is far from done,  A couple of more tiny issues to resolve then can continue with rest of the port... going to focus on the following:<br>
<br>
- Change the generator so that I can fix the namespace problem and b able to flexibly generate pass and future code, currently its only line by line.<br><br>
- Port more of the Java examples over to C# together with Blackberry API. <br><br>
- More C# language features like full OOP for example: base() on the constructor to call the super-class constructor in Java etc etc.<br><br>
- Unit tests for everything<br><br>
- More configurable with XML configs<br><br>

<h2>How Does Blackberry Development Work?</h2>

To write applications for the Blackberry you use J2ME with some additional Blackberry APIs, can then compile and run this using Eclipse or the separate JDE IDE (which am using)... some guys even try to use Netbeans... I must still give that a try.<br>
<br>
There is no GUI design for drag-and-drop (or RAD) development but you write code for everything... there was a designer before but was discontinued (only the universe will know why!)<br>
<br>
<h2>How Does This Tool Work?</h2>

Above is also true for this tool, you code in C# using the same Blackberry APIs and restrictions. My plan is not to port Silverlight, XAML or WinForms to the Blackberry.<br>
<br>
Create a new .Net framework 3.5 with C# 2.0 console application, add the CS4BBLib.dll as a reference then code your application. The application doesn't run in Visual Studio.Net yet since the API classes are just empty stubs for now... maybe later I'll let them create a WinForm and you can see something.<br>
<br>
Compile then using this tool, it generate all the Java files for you... you can then copy and paste these into Eclipse / JDE and compile... Later on am going to automate this process.<br>
<br>
<h2>C# Language Support</h2>

Not the entire C# language isn't supported, for example:<br>
<br>
- The var keyword since there is no type inference in Java <br>
- The dynamic keyword from C# 4.0 since in Java there is no DLR <br>
- Indexers.. they don't exist in Java <br>
- A C# file must contain 1 class or interface not multiple, same restrictions that Java have <br>
- Only C# 3.0 style auto properties with no "readonly" indication etc. <br>
- No LINQ <br>
- Some OOP features are missing and development in progress <br>
- You can't add an external DLL in C# and want to call it... All classes must b available and in your current source so that they can b translated into Java. I'm thinking on an idea to make this better or a good solution... any advise welcome <br>
- C# is the only language... no VB.Net, C++ CLI (yet), F# etc. <br>
- No extension methods, delegates, anonymous methods etc <br>
- Porting over the .Net framework base classes like Convert.ToXXX etc a work in progress... Still need to see what solution am going for here. <br>
- You need to manually compile and copy the files into Eclipse/JDE... I'm working to make this better / automated as well <br><br>

Yes the tool have limits but its all a progress, you don't build something that translate C# that is such a full feature language into a language like Java that have limitations and haven't been updated for awhile (we're still waiting for JDK 7...) over night or as a weekend hack.