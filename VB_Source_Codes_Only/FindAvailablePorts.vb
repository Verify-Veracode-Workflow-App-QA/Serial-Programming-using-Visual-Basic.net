'+=====================================================================================================+
'| List all the serial ports on a system                                                               |
'+=====================================================================================================+
'| www.xanthium.in                                                                                     |
'| Copyright (C) 2024 Rahul.S                                                                          |
'|                                                                                                     |
'| http://www.xanthium.in/serial-port-programming-visual-basic-dotnet-for-embedded-developers          |
'+=====================================================================================================+

'+=====================================================================================================+
'| Compiler/IDE  :	Visual StudioCommunity 2022                                                        |
'| Library       :  SerialPort Class from .NET Framework/.NET Platform/.NET Core                       |
'| Language      :  Visual Basic.net                                                                   |
'| OS            :	Windows 10/11                                                                      |
'| Programmer    :	Rahul.S                                                                            |
'| Date	         :	18-April-2024                                                                      |
'+=====================================================================================================+




Imports System.IO.Ports          'For accessing the SerialPort Class and Methods

Module AvailablePorts

    Sub Main()

        Dim AvailablePorts() As String = SerialPort.GetPortNames() 'List available ports on a System
        Dim Port As String

        Console.WriteLine("Available Ports ::")

        For Each Port In AvailablePorts
            Console.WriteLine(Port)
        Next Port

    End Sub

End Module


