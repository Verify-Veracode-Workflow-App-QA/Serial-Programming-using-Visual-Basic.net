
'+=====================================================================================================+
'| Simple read from Serial port                                                                        |
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
'| Date	         :	19-April-2024                                                                      |
'+=====================================================================================================+


Imports System.IO.Ports
Imports System.Threading

Module SimpleReadDataSerialPort

    Sub Main()
        Dim MyCOMPort As SerialPort
        Dim DataReceived As String

        MyCOMPort = New SerialPort("COM3", 9600) 'Create a Serial Port Object 

        'Should be inside a Try..Catch() statement 
        MyCOMPort.Open()

        MyCOMPort.ReadTimeout = 3000 'set timeout to 3 second or 3000mS

        'Try to read data from SerialPort
        Try
            DataReceived = MyCOMPort.ReadLine() 'Read data send from Arduino
        Catch ex As TimeoutException
            Console.WriteLine(ex.Message)         'In case of not receiving any data from Arduino
        Finally
            MyCOMPort.Close()
        End Try

        Console.WriteLine($"Data Received from Arduino = {DataReceived}")

    End Sub






End Module
