   M S B A M L   `   `   `  ????B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	        WpfApp1.TicTacToeSpielFeld   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     ? Title$  TicTacToeSpielFeld??5   	   $	??450??6$   $	??800??61   .??5	      ? -   5         ?Name$ maingrid??5	      .+?5
   
   ?? $
??Left=?6   $??20(?6/   $??	10,18,0,0q?6=   $#??Aktueller Schwierigkeitsgrad:??6P   $
??Wrap=?6u   $	??Top=?6?   $	??385??6?   $??44??6?   ?? 5   
   -   5         ??Name$ schwierigkeitsgradLabel??5      $??20(?62   $??test
??6@   $
??Left=?6Y   $	??Top=?6u   $	??132??6?   $??54??6?   $??
280,13,0,0q?6?   ?? 5   
   $
??Left=?6   $??20(?6/   $??
679,10,0,0q?6=   $??
Spielstand??6Q   $
??Wrap=?6c   $	??Top=?6w   ?? 5   
   -   5        $ UserScoreLabel??5      $??X??6(   $??20(?64   
???  ??$
??Left=?6S   $??
685,42,0,0q?6n   $	??Top=?6?   ?? 5   
   -   5        $ ComputerScoreLabel??5      $??O??6,   $
??Left=?68   $??20(?6S   
??? ? ?$??
745,42,0,0q?6u   $	??Top=?6?   ?? 5   
   $??-??6   $
??Left=?6   $??20(?67   $??
715,40,0,0q?6E   $	??Top=?6Y   ?? 5   
   -   5         ??Name$
 btn0??5      $?? ??6   $
??Left=?6*   $??200,120,0,0q?6E   $	??Top=?6Z   $??75??6r   $??75??6~   6?   ?? 5   
   -   5        $
 btn1??5      $?? ??6   $
??Left=?6*   $??300,120,0,0q?6E   $	??Top=?6Z   $??75??6r   $??76??6~   6?   ?? 5   
   -   5        $
 btn2??5      $?? ??6   $
??Left=?6*   $??400,120,0,0q?6E   $	??Top=?6Z   $??75??6r   $??75??6~   6?   ?? 5   
   -   5        $
 btn3??5      $?? ??6   $
??Left=?6*   $??200,220,0,0q?6E   $	??Top=?6Z   $??75??6r   $??75??6~   6?   ?? 5   
   -	   5        $
 btn4??5      $?? ??6   $
??Left=?6*   $??300,220,0,0q?6E   $	??Top=?6Z   $??75??6r   $??76??6~   6?   ?? 5   
   -
   5        $
 btn5??5      $?? ??6   $
??Left=?6*   $??400,220,0,0q?6E   $	??Top=?6Z   $??75??6r   $??76??6~   6?   ?? 5   
   -   5        $
 btn6??5      $?? ??6   $
??Left=?6*   $??200,320,0,0q?6E   $	??Top=?6Z   $??75??6r   $??76??6~   6?   ?? 5   
   -   5        $
 btn7??5      $?? ??6   $
??Left=?6*   $??300,320,0,0q?6E   $	??Top=?6Z   $??75??6r   $??75??6~   6?   ?? 5   
   -   5        $
 btn8??5      $?? ??6   $
??Left=?6*   $??400,320,0,0q?6E   $	??Top=?6Z   $??74??6r   $??76??6~   6?   ?? 5   
   -   5        $??20(?5      
????  ?
???????$??Zum Hauptmenü??6D   $
??Left=?6\   $??613,300,0,0q?6w   $	??Top=?6?   $??58??6?   $	??165??6?   6?   5      5      