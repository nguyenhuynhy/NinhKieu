////////////////////////////////////////////////////////////////////////////////
// MeadCo ScriptX Dynamic Event Binding
// http://www.meadroid.com/scriptx
// Contact us: feedback@meadroid.com

var factory = new ActiveXObject("ScriptX.Factory");

////////////////////////////////////////////////////////////////////////////////
// Open output window

var output = OpenOutput();
var outputSink = factory.NewEventSink(output);
outputSink("OnQuit") = function() {
  // detach the sink and release the waiting WSH.
  this.Unadvise(); 
}

////////////////////////////////////////////////////////////////////////////////
// Open the browser window

var browser = new ActiveXObject("InternetExplorer.Application");
browser.Visible = true;

var sink = factory.NewEventSink(browser);
sink("StatusTextChange") = onStatusTextChange;
sink("TitleChange") = onTitleChange;
sink("BeforeNavigate2") = onBeforeNavigate2;
sink("NewWindow2") = onNewWindow2;
sink("NavigateComplete2") = onNavigateComplete2;
sink("DocumentComplete") = onDocumentComplete;
sink("OnQuit") = onQuit;
sink("OnVisible") = onVisible;

browser.Navigate("http://www.microsoft.com");

// Wait for Output Window to close (by user)
outputSink.Wait();
factory.Shutdown();

////////////////////////////////////////////////////////////////////////////////
// Browser event sinks

function onStatusTextChange(Text) 
{
  OutputHtml("StatusTextChange: <b>" + Text + "</b><br>");
}

function onTitleChange(Text) 
{
  OutputHtml("TitleChange: <b>" + Text + "</b><br>");
}

function onBeforeNavigate2(pDisp, URL, Flags, TargetFrameName, PostData, Headers, Cancel)
{
  var frame = (pDisp.TopLevelContainer)? "top browser": "frame";
  OutputHtml("BeforeNavigate2: <b>" + URL + "</b>, TargetFrameName: <b>" +
    TargetFrameName + "</b>, " + frame + "<br>");
  factory.MessageBeep();

  if ( URL !== "about:NavigationCanceled" &&
       !Confirm("WSH: Confirm navigation to "+URL) ) 
  {
    Cancel.value = true; // cancel navigation
    OutputHtml("<i>Navigation canceled!</i><br>");
  }
}

function onNewWindow2(ppDisp, Cancel)
{
  OutputHtml("NewWindow2<br>");
  factory.MessageBeep();
  if ( !Confirm("WSH: Confirm creation of new window") ) 
  {
    Cancel.value = true; // cancel navigation
    OutputHtml("<i>New window canceled!</i><br>");
  }
}

function onNavigateComplete2(pDisp, URL)
{
  factory.MessageBeep();
  var frame = (pDisp.TopLevelContainer)? "top browser": "frame";
  OutputHtml("NavigateComplete2: <b>" + URL + "</b>, " + frame + "<br>");
}

function onDocumentComplete(pDisp, URL)
{
  factory.MessageBeep();
  var frame = (pDisp.TopLevelContainer)? "top browser": "frame";
  OutputHtml("DocumentComplete: <b>" + URL + "</b>, " + frame + "<br>");
  if ( pDisp.TopLevelContainer )
    pDisp.document.parentWindow.focus();
}

function onVisible(Visible)
{
  OutputHtml("OnVisible: <b>" + Visible + "</b><br>");
}

function onQuit()
{
  OutputHtml("OnQuit<br>");
  // detach the sink upon this last event
  this.Unadvise(); 
}

////////////////////////////////////////////////////////////////////////////////
// Open an "Output" window

function OpenOutput() {
  var output = new ActiveXObject("InternetExplorer.Application");
  output.StatusBar = output.ToolBar = output.MenuBar = false;
  output.Navigate("about:\
<body style='overflow:auto;background-color:infobackground'>\
<small id=idOutput></small></body>");
  while ( output.Busy ) factory.Wait(250);
  output.document.title = "WSH Output";
  output.Top = output.Left = 10;
  output.Width = 600; output.Height = 450;
  output.Visible = true;
  return output;
}

function Confirm(str) {
  var wnd = output.document.parentWindow;
  wnd.focus();
  return wnd.confirm(str);
}

function OutputHtml(html) {
  var idOutput = output.document.parentWindow.idOutput;
  idOutput.insertAdjacentHTML("BeforeEnd", html);
  idOutput.scrollIntoView(false);
}