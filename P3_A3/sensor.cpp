#include "gpio_msp432.h"
#include "adc14_msp432.h"
#include "uart_msp432.h"
#include "posix_io.h"
#include "stdio.h"
#include "task.h"




//cd C:\Users\di461643\MicroControllTechnik\YAHAL\examples\msp432-launchpad\P3_A3\build

int main(void)
{
	//ein und ausgabe
	uart_msp432 uart;
    posix_io::inst.register_stdout(uart);
	
	
	adc14_msp432_channel pos_x(14);
	pos_x.adcMode(ADC::ADC_14_BIT);
	adc14_msp432_channel pos_y(13);
	pos_y.adcMode(ADC::ADC_14_BIT);
	adc14_msp432_channel pos_z(11);
	pos_z.adcMode(ADC::ADC_14_BIT);
	
	
	float offset = 1.65;//typical value. 
	float mV_in_mps = 0.06524;
	
	while(1){
		
		//640 mV = 1g  //640 anstatt 660, weil der durchschnittliche wert beim liegenden board (z Achse) 639 war
		//1g = 9,81 m/s²
		//1 m/s² = 65,24 mV

		task::sleep(1000);
		
		
		//man könnte auch jeder Achse einen unterschiedlichen offset verleihen, sodass sie beim
		//ruhenden Zustand 9,81 m/s² anzeigen
		float val_x = pos_x.adcReadVoltage()-offset;
		float val_y = pos_y.adcReadVoltage()-offset;
		float val_z = pos_z.adcReadVoltage()-offset;
		
		float val_x_mps = val_x/mV_in_mps;
		float val_y_mps = val_y/mV_in_mps;
		float val_z_mps = val_z/mV_in_mps;
		
		printf("\nNext: \n");
		printf("x= %.2f V   ", val_x);
		printf("m/s²= %.2f\n", val_x_mps);
    	printf("y= %.2f V   ", val_y);
		printf("m/s	²= %.2f\n", val_y_mps);
	    printf("z= %.2f V   ", val_z);
		printf("m/s²= %.2f\n", val_z_mps);
		
		
	    

	    
		
		
	}
	
	
    
}












