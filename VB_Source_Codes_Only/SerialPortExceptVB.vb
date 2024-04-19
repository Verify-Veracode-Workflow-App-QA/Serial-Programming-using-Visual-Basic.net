'+=====================================================================================================+
'| Using Serial Port Exceptions in VB.net                                                              |
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
Imports System.IO.Ports

Module SerialPortExceptVB

    Sub Main()

        Dim MyCOMPort As SerialPort
        MyCOMPort = New SerialPort() 'Create a Serial Port Object 

        MyCOMPort.PortName = "COM3"        'Assign the port name to the MyCOMPort object 
        MyCOMPort.BaudRate = 9600          'Assign the Baudrate to the MyCOMPort object 
        MyCOMPort.Parity = Parity.None   'Parity bits = none   
        MyCOMPort.DataBits = 8             'No of Data bits = 8 
        MyCOMPort.StopBits = StopBits.One  'No of Stop bits = 1

        Try
            MyCOMPort.Open()
        Catch ex As Exception
            Console.WriteLine("An Exception Occured here")
            'Console.WriteLine(ex.Message())
            Console.WriteLine(ex.ToString())
        End Try

        If MyCOMPort.IsOpen Then    'if MyCOMPort.IsOpen is True ,Port is open
            Console.WriteLine("Port Opened")
        Else
            Console.WriteLine("Port Not Opened")
        End If



    End Sub
End Module





