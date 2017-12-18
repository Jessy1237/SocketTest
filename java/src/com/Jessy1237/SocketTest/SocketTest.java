package com.Jessy1237.SocketTest;

import java.io.IOException;
import java.io.OutputStream;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class SocketTest
{

    public static void main( String[] args )
    {
        try
        {
            Socket socket = new Socket( "127.0.0.1", 4014 );
            OutputStream os = socket.getOutputStream();
            Scanner sc = new Scanner( System.in );
            String str = "";
            do
            {
                str = sc.nextLine();
                sendStringToPort( os, str );
            }
            while ( !str.equals( "done" ) );
            sc.close();
            socket.close();
        }
        catch ( UnknownHostException e )
        {
            e.printStackTrace();
        }
        catch ( IOException e )
        {
            e.printStackTrace();
        }
    }

    public static void sendStringToPort( OutputStream os, String str ) throws IOException
    {
        try
        {
            os.write( str.getBytes() );
        }
        catch ( IOException e )
        {
            System.err.print( e );
        }
    }

}
