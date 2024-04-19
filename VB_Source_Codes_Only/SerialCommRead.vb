
'+=====================================================================================================+
'| Program reads the string send from Arduino and displays it on Console                               |
'+=====================================================================================================+
'| www.xanthium.in										       |                                        
'| Copyright (C) 2024 Rahul.S                                                                          |
'|                                                                                                     |
'| http://www.xanthium.in/serial-port-programming-visual-basic-dotnet-for-embedded-developers          |
'+=====================================================================================================+

'+=====================================================================================================+
'| Compiler/IDE  :	Visual StudioCommunity 2022                                                        |
'| Library       :  SerialPort Class from Dotnet Framework/.NET Platform                                              |
'| Language      :  Visual Basic.net                                                                   |
'| OS            :	Windows                                                                            |
'| Programmer    :	Rahul.S                                                                            |
'| Date	         :	19-April-2024                                                                      |
'+=====================================================================================================+

'+=====================================================================================================+
'|  Hardware Connections                                                                               |
'+=====================================================================================================+
'|                                                                                                     |
'|     +--------+         +----------------+                +----------------------+                   |
'|     |	    |         |            TXD |----------------|RXD                   |                   |
'|     | PC     | =======>|USB         RXD |----------------|TXD  MicroController  |                   |
'|    / [] []   /         |            GND |----------------|GND                   |                   |
'|   /[] [] [] /          +----------------+                +----------------------+                   |
'|  +---------+              USB to Serial     TTL signals       MSP430/8051/PIC                       |
'|   Windows PC                                                                                        |
'+-----------------------------------------------------------------------------------------------------+
'| Please Note that:                                                                                   |
'| 		    TXD of the USB2SERIAL converter is connected to RXD of  MicroController            |
'|                  RXD of the USB2SERIAL converter is connected to TXD of  MicroController            |
'+=====================================================================================================+


Imports System
Imports System.IO.Ports 'To Access the SerialPort Object

Module SerialCommRead

    Sub Main()
        Console.WriteLine("+---------------------------------------------+")
        Console.WriteLine("| Serial Communication using Visual Basic.net |")
        Console.WriteLine("+---------------------------------------------+")
        Console.WriteLine()

        'Declaration of Variables used in the Program
        Dim MyCOMPort As SerialPort        
        Dim PortName As String         'To Store the Portname of the form COMxx,eg COM31
        Dim BaudRate As Integer        'To Store the Baudrate at which you wish to transmit eg:4800,9600,19200
        Dim DataReceived As String     'To Store the Received Data

        '+------------------------------------------------------------------+'
        '|   To Display the available Serial Ports attached to your PC      |'
        '+------------------------------------------------------------------+'
        
        'using SerialPort.GetPortNames() static property to get a list of available com ports 
        'and assign it to the array AvailablePorts
        Dim AvailablePorts() As String = SerialPort.GetPortNames()

        Console.WriteLine("Available Ports ::")

        'use a For Each Loop to Display the available Ports 
        Dim Port As String
        For Each Port In AvailablePorts
            Console.WriteLine(Port)
        Next Port

        Console.WriteLine()

        Console.WriteLine("Enter Your Port ->")    'Ask for the Port Name you wish to Connect 
        PortName = Console.ReadLine()

        Console.WriteLine("Enter Baudrate ->")         'Ask for Baudrate you wish to communicate 
        BaudRate = Convert.ToInt32(Console.ReadLine()) 'Convert the character to integer
      
       '+------------------------------------------------------------------+'
       '|              Configuring the SerialPort Parameters               |'
       '+------------------------------------------------------------------+'

        MyCOMPort = New SerialPort()

        MyCOMPort.PortName = PortName          ' Assign the port name to the MyCOMPort object
        MyCOMPort.BaudRate = BaudRate          ' Assign th Baudrate to the MyCOMPort object
		MyCOMPort.Parity   = Parity.None       ' Parity bits = none  
		MyCOMPort.DataBits = 8                 ' No of Data bits = 8
	    MyCOMPort.StopBits = StopBits.One      ' No of Stop bits = 1

        Try
            MyCOMPort.Open()                       ' Open the port
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Setting Read timeouts
        MyCOMPort.ReadTimeout = 5000 'set timeout to 5 second or 5000mS

        Console.WriteLine("Waiting for Data to be Received")


        'Try to read data from SerialPort
        ' Waiting for Data to be send from the microcontroller
        Try
            DataReceived = MyCOMPort.ReadLine() 'Read data send from Arduino
        Catch ex As TimeoutException
            Console.WriteLine(ex.Message)         'In case of not receiving any data from Arduino
        Finally
            MyCOMPort.Close() 'Çlose the serialport
        End Try


        Console.WriteLine()
        Console.WriteLine("Data received -> {0}",DataReceived)
        Console.WriteLine("+---------------------------------------------+")
        Console.ReadLine()
    End Sub

End Module
