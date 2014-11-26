import lejos.nxt.*;
import lejos.nxt.comm.*;
import java.io.*;

/*
  NXTControlLeJOS application for remote controlling the NXT brick
  This file is an extended / modified version of the 
  btreceive.java file of Lawrie Griffiths
  
  2009/2010 by Guenther Hoelzl
  see http://sites.google.com/site/ghoelzl/

  This file is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 3 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  General Public License for more details.
*/

public class NXTControlLeJOS {

    public static final int MOTOR_A_C_STOP = 0;
    public static final int MOTOR_A_FORWARD = 1;
    public static final int MOTOR_A_BACKWARD = 2;
    public static final int MOTOR_C_FORWARD = 3;
    public static final int MOTOR_C_BACKWARD = 4;    
    public static final int TACHOCOUNT_RESET = 8;    
    public static final int TACHOCOUNT_READ = 9;    
    public static final int DISCONNECT = 99;    

    public static void main(String [] args)  throws Exception 
    {
        String connected = "Connected";
        String waiting = "Waiting...";
        String closing = "Closing...";        

        while (true)
        {
            LCD.drawString(waiting,0,0);
            LCD.refresh();

            BTConnection btc = Bluetooth.waitForConnection();
                
            LCD.clear();
            LCD.drawString(connected,0,0);
            LCD.refresh();    

            DataInputStream dis = btc.openDataInputStream();
            DataOutputStream dos = btc.openDataOutputStream();
            
            while (true) {
                int command = dis.readInt();
                int value   = dis.readInt();

                switch (command) {
                    case MOTOR_A_FORWARD: 
                        Motor.A.setSpeed(value);
                        Motor.A.forward();
                        break;
                    case MOTOR_A_BACKWARD: 
                        Motor.A.setSpeed(value);
                        Motor.A.backward();
                        break;
                    case MOTOR_C_FORWARD: 
                        Motor.C.setSpeed(value);
                        Motor.C.forward();
                        break;
                    case MOTOR_C_BACKWARD: 
                        Motor.C.setSpeed(value);
                        Motor.C.backward();
                        break;
                    case TACHOCOUNT_RESET: 
                        Motor.A.resetTachoCount();
                        break;
                    case TACHOCOUNT_READ: 
                        dos.writeInt(Motor.A.getTachoCount());
                        dos.flush();
                        break;
                    case DISCONNECT: 
                        break;
                    default: 
                        Motor.A.stop();    
                        Motor.C.stop();                            
                }
                if (command == DISCONNECT) break;

            }
            
            dis.close();
            dos.close();
            Thread.sleep(100); // wait for data to drain
            LCD.clear();
            LCD.drawString(closing,0,0);
            LCD.refresh();
            btc.close();
            LCD.clear();
        }
    }
}

