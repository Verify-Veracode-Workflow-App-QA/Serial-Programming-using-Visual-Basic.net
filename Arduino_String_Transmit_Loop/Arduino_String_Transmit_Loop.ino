// Sends the text "Hello From Arduino to VB.Net" to PC 
// 
// Code also sends \n character
// www.xanthium.in (c) 2024

void setup() 
{
  // Start serial communication at 9600 baud rate
  Serial.begin(9600);

  // Wait for serial port to initialize
  while (!Serial);// Wait for serial port to connect

  char DataToSend[] = "Hello From Arduino to VB.Net" ;
 
  Serial.flush(); // Flush the serial buffers

   Serial.println(DataToSend);
  
}

void loop() 
{
  
}
