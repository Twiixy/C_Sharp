

#include "task.h"
#include "msp.h"

#include "gpio_msp432.h"
#include "uart_msp432.h"
#include "posix_io.h"
#include "stdio.h"

int counter = 0;
int ptr = 0;
int ptr2 = 0;
bool nextrun = false;
void delay() {

	task::sleep(100);
	counter++;

}

void startLock() {
	// Schalter 1 (oben)
	P5->SEL0 &= ~BIT1;
	P5->SEL1 &= ~BIT1;
	P5->DIR &= ~BIT1;
	P5->REN |= BIT1;
	P5->OUT |= BIT1;


	// Joystick button
	P4->SEL0 &= ~BIT1;
	P4->SEL1 &= ~BIT1;
	P4->DIR &= ~BIT1;
	P4->REN |= BIT1;
	P4->OUT |= BIT1;

	// LED grün
	P2->SEL0 &= ~BIT4;
	P2->SEL1 &= ~BIT4;
	P2->DIR |= BIT4;
	P2->OUT &= ~BIT4;

	// LED blau
	P5->SEL0 &= ~BIT6;
	P5->SEL1 &= ~BIT6;
	P5->DIR |= BIT6;
	P5->OUT &= ~BIT6;

	int  code2[] = { 5,2,6,7 };
	//int  code[] = {1,0,0,9};
	//int arrayLength =4;
	int  code[] = { 5 };// Ein einfacher Code um die Bedingung schneller zu prüfen
	int arrayLength = 1;


	while (1) {
		if ((P4->IN & BIT1) == 0) {//"Joystick-Button (wenn man auf den Joystick drückt)" damit ist keine Bewegung gemeint, richtig?
			nextrun = true;
			task::sleep(200);
		}


		if ((P5->IN & BIT1) == 0) { //der Button reagiert manchmal nicht (eigentlich nur wenn man mittwig auf ihn drückt)
			P5->OUT |= BIT6;		//Bei seitlicher Anwendung klappt es meistens
			task::sleep(100);
			P5->OUT &= ~BIT6;
			delay();
			printf("%d\n", counter);     //um Eingaben besser nachzuvollziehen
			printf("ptr2 =  %d\n", ptr2);
		}


		if (nextrun) {
			if (counter == code[ptr])
			{
				if (ptr == arrayLength - 1) {
					P2->OUT |= BIT4;
					task::sleep(1000);
					P2->OUT &= ~BIT4;
				}
				else {
					ptr++;
				}

			}
			else {
				ptr = 0;
				if (counter == code[ptr]) {//um pos 1 zu checken
					ptr++;
				}
			}
			if (counter == code2[ptr2])
			{
				if (ptr2 == 3) {
					P2->OUT |= BIT4;
					task::sleep(1000);
					P2->OUT &= ~BIT4;
				}
				else {
					ptr2++;
				}

			}
			else {
				ptr2 = 0;
				if (counter == code2[ptr2])//um pos 0 zu checken
				{
					ptr2++;
				}
			}
			nextrun = false;
			counter = 0;
		}


	}
}

int main(void)
{
	uart_msp432 uart;
	posix_io::inst.register_stdout(uart);
	printf("%d\n", 99);
	startLock();
}
