' MeadCo ScriptX Dynamic Event Binding
' http://www.meadroid.com/scriptx
' Contact us: scriptx@meadroid.com

Set Browser = CreateObject("InternetExplorer.Application")
Browser.Visible = true

' Handle events from browser
Set Factory = CreateObject("ScriptX.Factory")
Factory.script = me
Set Sink = Factory.NewEventSink(Browser)
Sink("BeforeNavigate2")="BeforeNavigate2"
Sink("DocumentComplete")="DocumentComplete"
Sink("OnQuit")="OnQuit"

' Navigate and wait until DocumentComplete occurs
Browser.Navigate2 "http://msdn.microsoft.com/scripting/"
Sink.Wait
Factory.Shutdown

' Event handlers
Sub BeforeNavigate2(ByVal pDisp, URL, Flags, TargetFrameName, PostData, Headers, Cancel)
  MsgBox "BeforeNavigate2: " & URL
End Sub

Sub DocumentComplete(ByVal pDisp, URL)
  MsgBox "Document complete: " & URL
  call me.CancelWait() ' release the Sink.Wait above
End Sub

Sub OnQuit
  MsgBox "OnQuit"
  call me.Unadvise() ' no more events
End Sub
