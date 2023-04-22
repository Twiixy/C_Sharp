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

gpio_msp432_pin s1( SWITCH1 );
s1.gpioMode( GPIO::INPUT | GPIO::PULLUP );
	
gpio_msp432_pin s2( SWITCH2 );
s2.gpioMode( GPIO::INPUT | GPIO::PULLUP ); //if(!s2.gpioRead())



gpio_msp432_pin led( PORT_PIN(1,0) );//red  led=HIGH; led=LOW;
led.gpioMode( GPIO::OUTPUT );

gpio_msp432_pin green_led( PORT_PIN(2,1) );//grün
green_led.gpioMode( GPIO::OUTPUT );

gpio_msp432_pin blue_led( PORT_PIN(2,2) );
blue_led.gpioMode( GPIO::OUTPUT );

//task::sleep(1000);

include /interfaces/ timer_interface 
blink_timer.cpp


int main(void)
{
    
}
