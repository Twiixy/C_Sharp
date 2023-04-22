

#include "gpio_msp432.h"
#include "adc14_msp432.h"
#include "uart_msp432.h"
#include "posix_io.h"
#include "stdio.h"
//TAxCCR0 = 50 MHz
//EQU0:
//rechts =4%  = 2    MHz  =>    0
//mitte = 7,5%= 3,75 MHz  =>  503
//links = 11% = 5,5  MHz  => 1023
//output 6 toogle/set = 110
//10 Continuous The timer repeatedly counts from zero to 0FFFFh.
void setTimerA(uint16_t value){//setzt EQU1
	
}

int main()
{
	gpio_msp432_pin servo_pin  (PORT_PIN(2, 5));
    servo_pin.gpioMode(GPIO::OUTPUT);
	
    uart_msp432 uart;
    posix_io::inst.register_stdout(uart);

	adc14_msp432_channel joy_X(15);
	joy_X.adcMode(ADC::ADC_10_BIT);
	
	while(true) {
	    uint16_t val = joy_X.adcReadRaw();
	    
		setTimerA(val);
	    printf("%d\n", val);
	}
}
