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


void delay(int ms){
    gpio_msp432_pin led( PORT_PIN(1,0) );
    led.gpioMode( GPIO::OUTPUT );
    while(1){
    led=HIGH;
    task::sleep(ms);
    led=LOW;
    task::sleep(ms);
    }
}

int main(void)
{
    // Use P1.0 as output
    

    // This loop will never end ...
    delay(500);
}
