#include "stDHT.h"
DHT sens(DHT11);
#include <Wire.h>
#include <Adafruit_BMP085.h>

Adafruit_BMP085 bmp;
void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
pinMode(D3, INPUT);
  digitalWrite(D3, HIGH);
  pinMode(D4,INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

  int t = sens.readTemperature(D3); // чтение датчика на пине 2
  int h = sens.readHumidity(D3);    // чтение датчика на пине 2
  int r=digitalRead(D4);
  delay(300);
  
  
  Serial.print("H");
  Serial.println(h);
  Serial.print("T");
  Serial.println(t);
  Serial.print("R");
  Serial.println(r);
  
}
