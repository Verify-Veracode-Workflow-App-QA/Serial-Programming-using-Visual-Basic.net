
'+=====================================================================================================+
'| Serial Port Programming using Dot net Framework and Visual Basic.net on Windows7 (Read)             |
'+=====================================================================================================+
'| The Program runs on the PC side and uses dotnet framework to open a serial port and Reads an ASCII  |
'| character send from a microcontroller 	                                                           |
'+=====================================================================================================+
'| www.xanthium.in										                                               |
'| Copyright (C) 2016 Rahul.S                                                                          |
'|                                                                                                     |
'| http://www.xanthium.in/serial-port-programming-visual-basic-dotnet-for-embedded-developers          |
'+=====================================================================================================+
	
'+=====================================================================================================+
'| Compiler/IDE  :	Visual Studio/Visual Studio Express/SharpDevelop                                   |
'| Library       :  SerialPort Class from Dotnet Framework                                             |
'| Language      :  Visual Basic.net                                                                   |
'| OS            :	Windows                                                                            |
'| Programmer    :	Rahul.S                                                                            |
'| Date	         :	20-March-2016                                                                      |
'+=====================================================================================================+

'+=====================================================================================================+
'|  Hardware Connections                                                                               |
'+=====================================================================================================+
'|                                                                                                     |
'|     +--------+         +----------------+                +----------------------+                   |
'|	   |	    |         |            TXD |----------------|RXD                   |                   |
'|     | PC     | =======>|USB         RXD |----------------|TXD  MicroController  |                   |
'|    / [] []   /         |            GND |----------------|GND                   |                   |
'|   /[] [] [] /          +----------------+                +----------------------+                   |
'|  +---------+              USB to Serial     TTL signals       MSP430/8051/PIC                       |
'|   Windows PC                                                                                        |
'+-----------------------------------------------------------------------------------------------------+
'| Please Note that:                                                                                   |
'| 					TXD of the USB2SERIAL converter is connected to RXD of  MicroController            |
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

		MyCOMPort.Open()                       ' Open the port

        Console.WriteLine("Waiting for Data to be Received")
       
        'Reading from Serial Port 

		DataReceived = MyCOMPort.ReadLine()    ' Waiting for Data to be send from the microcontroller
		MyCOMPort.Close()                      ' Close port
        
        Console.WriteLine()
        Console.WriteLine("Data received -> {0}",DataReceived)
        Console.WriteLine("+---------------------------------------------+")
        Console.ReadLine()
    End Sub

End Module
