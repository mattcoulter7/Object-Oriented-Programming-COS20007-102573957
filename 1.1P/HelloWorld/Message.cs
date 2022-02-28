using System;
using System.Collections.Generic;
using System.Text;

public class Message
{
    public string text;
    public Message (string txt)
    {
        text = txt;
    }

    public void Print()
    { 
        Console.WriteLine (text);
    }

}
