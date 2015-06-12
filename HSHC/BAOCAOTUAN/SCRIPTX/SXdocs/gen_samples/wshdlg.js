var scriptPath = WScript.ScriptFullName; // get dir part of script path
scriptPath = scriptPath.substr(0, scriptPath.lastIndexOf('\\')+1);

var factory = new ActiveXObject("ScriptX.Factory");
var input = factory.ShowHtmlDialog(scriptPath+"dialog.htm", "Hello, World!");
if ( input != null ) WScript.echo("You entered: "+input);
