@echo off
Echo.
Echo ************************************
Echo * PortalQH Command Line Compiler *
Echo ************************************
Echo.
Rem - Let's make sure we are in the right directory.
If exist PortalQH.sln GoTo MkRspCheck
Echo This program must be run from the root directory of PortalQH.
Echo Please ensure that you have placed this file and the MK.RSP file
Echo in the Root directory.
Goto End
:MkRspCheck
Rem - Let's make sure the response file is there.
If exist mk.rsp GoTo VBCExistCheck
Echo You don't seem to have the response file.
Echo Please place the MK.RSP file in your PortalQH Root directory.
Goto End
:VBCExistCheck
Rem - Check for the VBC component first
If exist %SYSTEMROOT%\Microsoft.NET\Framework\v1.1.4322\VBC.exe GoTo VBC1Exist
If exist %SYSTEMROOT%\Microsoft.NET\Framework\v1.0.3705\VBC.exe GoTo VBC0Exist
Rem - The file VBC.EXE doesn't appear to exist.
Echo You don't seem to have the Microsoft .NET Framwork installed.
Echo Please read the documentation for further help.
GoTo End
Rem - The file VBC.EXE appears to exist in the v1.0 directory
:VBC0Exist
SET DotNetFrameworkDir=v1.0.3705
GoTo Action
Rem - The file VBC.EXE appears to exist in the v1.1 directory
:VBC1Exist
SET DotNetFrameworkDir=v1.1.4322
GoTo Action
Rem - This where we will action what we have learned.
Rem - There is a small change where we will pull the information required for
Rem - the build from a response file. This is easier to read and understand.
:Action
Set VBCPATH=%SYSTEMROOT%\Microsoft.NET\Framework\%DotNetFrameworkDir%\VBC.EXE
%VBCPATH% @mk.rsp
GoTo End
:End
Pause
