

#include "task.h"
#include "msp.h"


int counter=0;
int ptr=0;
int ptr2=0;
bool nextrun=false;
void delay(){
	
	task::sleep(100);
	counter++;
	
}

void startLock(){
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
	
	int  code2[] = {5,2,6,7};
	//int  code[] = {1,0,0,9};
	int  code[] = {5};
	
	
    while(1){
	if((P4->IN & BIT1) == 0){
		nextrun=true;
		counter=0;
	}
	
	if((P5->IN & BIT1) == 0){
		delay();
	}
		
	
	if(nextrun){
	if(counter==code[ptr])
	{
		if(ptr==3){
			P2->OUT |= BIT4;
			task::sleep(1000);
			P2->OUT &= ~BIT4;
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
			P2->OUT |= BIT4;
			task::sleep(1000);
			P2->OUT &= ~BIT4;	
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
	nextrun=false;
	}
	
	
    }
}

int main(void)
{
    startLock();
}
