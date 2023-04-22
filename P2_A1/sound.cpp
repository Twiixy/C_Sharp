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
#include "timer_msp432.h"
//#include "pitches.h"
//#define NOTE_C4_1 260
//#include "energia"

//#define SWITCH1 PORT_PIN(5,1)
//include /interfaces/ timer_interface 
//blink_timer.cpp
bool next=false;


void delay(double us) {
    // Setup the second time in ONE_SHOT mode
    // and simply wait until the callback
    // method has changed the 'expired' variable.
    // The interrupt handler is realized as a
    // lambda expression, which can access this
    // variable (capture [&]).
    bool expired = false;
    timer_msp432 timer2(TIMER32_1);
    timer2.setPeriod(us, TIMER::ONE_SHOT);
    timer2.setCallback([&]() { expired = true; });
    timer2.start();
    // Now (actively) wait until the callback
    // method has changed the 'expired' variable...
    while(!expired) ;

	
	
}
	
void delay2	(int us,int ton) {
	gpio_msp432_pin s1( PORT_PIN(5,1) );
	s1.gpioMode( GPIO::INPUT | GPIO::PULLUP );
	
	gpio_msp432_pin buzzer( PORT_PIN(2,7) );
	buzzer.gpioMode( GPIO::OUTPUT );
    // Setup the second time in ONE_SHOT mode
    // and simply wait until the callback
    // method has changed the 'expired' variable.
    // The interrupt handler is realized as a
    // lambda expression, which can access this
    // variable (capture [&]).
    bool expired = false;
    timer_msp432 timer2(TIMER32_2);
    timer2.setPeriod(us, TIMER::ONE_SHOT);
    timer2.setCallback([&]() { expired = true; });
    timer2.start();

	
    // Now (actively) wait until the callback
    // method has changed the 'expired' variable...
	
    while(!expired) {
		delay(	1*(1000000/(ton)));//1000000 = 1 sekunde =>  1sek/noten frequenz 
								   //anscheinend klappt das nicht richtig. 
	buzzer.gpioToggle();
	
	}
	
}	



	void f1(void * arg){
		gpio_msp432_pin *gpioa=static_cast<gpio_msp432_pin *>(arg);
		gpioa->gpioToggle();
	}
	



int main(void)
{
	
	
	//gpio_msp432_pin clk( PORT_PIN(1,5) );
	//clk.gpioMode( GPIO::INPUT );
	
	timer_msp432 timer2;
    timer2.setPeriod(500000, TIMER::PERIODIC);
	//noten in frequenz:
	int c=264;
	int d=297;
	int e=330;
	int f=352;
	int g=396;
	int a=440;
	int b=495;
				//E 	A 	 C   D     E    A   C   D  B   G    D   G    C    B   D   G  C  B  A
	//int arr [] = {e,b,g,d,a,e,e,b,g,d,a,e,e,b,g,d,a,e,e,b,g,d,a,e,e,g,d,a,e};
	int arr [] = {g,g,a,g,c,b,g,g,a,g,d,c,g,g,g,e,c,b,a,f,f,e,c,d,c};
	int ptr=0;
	
	
	while(1){
		//die noten dauer als ersten parameter
		delay2(1000000,arr[ptr]);//noten jede sekunde wechseln
		
		
		
		
		ptr+=1;
		if(ptr==std::size(arr)){
			ptr=0;
		}
		
		
		//tone(pin_number, frequency)
		//buzzer=timer2.;
		//tone(buzzer,timer2);
		//buzzer=timer2
		//buzzer.gpioMode(timer2);
		//gpioToogle()
		//timer2.setCallback([&]() { led1.gpioToggle(); });
		
		//timer2.setCallback(f1,&buzzer);
		
		
	}
	
	
    
}












