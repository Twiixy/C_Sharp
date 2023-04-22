// ---------------------------------------------
//           This file is part of
//      _  _   __    _   _    __    __
//     ( \/ ) /__\  ( )_( )  /__\  (  )
//      \  / /(__)\  ) _ (  /(__)\  )(__
//      (__)(__)(__)(_) (_)(__)(__)(____)
//
//     Yet Another HW Abstraction Library
//      Copyright (C) Andreas Terstegge
//      BSD Licensed (see file LICENSE)
//
// ---------------------------------------------
//
// A simple blink example using the red LED on
// Port 1 pin 0. The delay is implemented with
// a simple for-loop.

#include "gpio_msp432.h"
#include "task.h"


#define SWITCH1 PORT_PIN(1,1)
#define SWITCH2 PORT_PIN(1,4)
int counter=0;
int ptr=0;
int ptr2=0;
bool nextrun=false;
void delay(){
	
	task::sleep(250);//das sleep ist zwar nicht optimal, funktioniert aber zu 90 % :)
	counter++;
	
}

void startLock(){
    gpio_msp432_pin led( PORT_PIN(1,0) );//red
	gpio_msp432_pin green_led( PORT_PIN(2,1) );//grün
	gpio_msp432_pin blue_led( PORT_PIN(2,2) );
    led.gpioMode( GPIO::OUTPUT );
	blue_led.gpioMode( GPIO::OUTPUT );
	green_led.gpioMode( GPIO::OUTPUT );
	gpio_msp432_pin s1( SWITCH1 );
	gpio_msp432_pin s2( SWITCH2 );
	s1.gpioMode( GPIO::INPUT | GPIO::PULLUP );
	s2.gpioMode( GPIO::INPUT | GPIO::PULLUP );
	int  code2[] = {5,2,6,7};
	int  code[] = {1,0,0,9};
	
	
    while(1){
	//led.gpioWrite(!s1.gpioRead());
	while(!s1.gpioRead()){
		led=LOW;
		if(!s2.gpioRead()){
			delay();
		}
		nextrun=true;
	}
	
	if(nextrun){
	if(counter==code[ptr])
	{
		if(ptr==3){
			green_led=HIGH;
			task::sleep(1000);
			green_led=LOW;	
		}
		else{
			ptr++;
		}
		 
	}
	else{
		ptr=0;
		if(counter==code[ptr]){//um pos 1 zu checken
			ptr++;
		}
	}
	if(counter==code2[ptr2])
	{
		if(ptr2==3){
			green_led=HIGH;
			task::sleep(1000);
			green_led=LOW;	
		}
		else{
			ptr2++;
		}
		 
	}
	else{
		ptr2=0;
		if(counter==code2[ptr2])//um pos 0 zu checken
		{
			ptr2++;
		}
	}
	}
	counter=0;
	nextrun=false;
    }
}

int main(void)
{
    startLock();
}
