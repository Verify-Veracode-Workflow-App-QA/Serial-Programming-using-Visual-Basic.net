'+=====================================================================================================+
'| Configuring the Serial Port Parameters using VB.Net                                                 |
'+=====================================================================================================+
'| www.xanthium.in                                                                                     |
'| Copyright (C) 2024 Rahul.S                                                                          |
'|                                                                                                     |
'| http://www.xanthium.in/serial-port-programming-visual-basic-dotnet-for-embedded-developers          |
'+=====================================================================================================+

'+=====================================================================================================+
'| Compiler/IDE  :	Visual Studio Community 2022                                                       |
'| Library       :  SerialPort Class from .NET Framework/.NET Platform/.NET Core                       |
'| Language      :  Visual Basic.net                                                                   |
'| OS            :	Windows 10/11                                                                      |
'| Programmer    :	Rahul.S                                                                            |
'| Date	         :	18-April-2024                                                                      |
'+=====================================================================================================+




Imports System.IO.Ports          'For accessing the SerialPort Class and Methods

Module ConfigSerialParam

    Sub Main()

        Dim MyCOMPort As SerialPort
        MyCOMPort = New SerialPort() 'Create a Serial Port Object 

        MyCOMPort.PortName = "COM3"        'Assign the port name to the MyCOMPort object 
        MyCOMPort.BaudRate = 9600          'Assign the Baudrate to the MyCOMPort object 
        MyCOMPort.Parity = Parity.None   'Parity bits = none   
        MyCOMPort.DataBits = 8             'No of Data bits = 8 
        MyCOMPort.StopBits = StopBits.One  'No of Stop bits = 1

        Console.WriteLine(MyCOMPort.PortName)
        Console.WriteLine(MyCOMPort.BaudRate)
        Console.WriteLine(MyCOMPort.Parity)
        Console.WriteLine(MyCOMPort.DataBits)
        Console.WriteLine(MyCOMPort.StopBits)

    End Sub
End Module
