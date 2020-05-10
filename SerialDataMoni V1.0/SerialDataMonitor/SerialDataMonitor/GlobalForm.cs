using System;
using System.IO.Ports;

namespace SerialDataMonitor
{
    public class GlobalForm
    {
    }

    public class DataSetting
    {
        // Serial port
        public string ComPortName { get; set; }
        public Int32 Baudrate     { get; set; }
        public Int16 DataBits     { get; set; }
        public Parity Parity      { get; set; }
        public StopBits StopBits  { get; set; }

        // Font
        public string FontNumberColor { get; set; }
        public string FontTextColor1  { get; set; }
        public string FontTextColor2  { get; set; }
        public string FontTextColor3  { get; set; }
        public string FontTextColor4  { get; set; }
        public string FontTextColor5  { get; set; }
        public string FontTextColor6  { get; set; }
        public string FontTextColor7  { get; set; }
        public string FontTextColor8  { get; set; }

        // Find
        public bool FindMatchCase      { get; set; }
        public bool FindMatchWholeWord { get; set; }
        public bool FindRegex          { get; set; }

        // Display
        public bool DispScroll         { get; set; }
    }

    /*Back up data class*/
    public class BackupData
    {
        public static string ComPortName { get; set; }      // static var <ComPortName
        public static Int32  Baudrate    { get; set; }      // static var <Baudrate
        public static Int16  DataBits    { get; set; }      // static var <DataBits
        public static Parity Parity      { get; set; }      // static var <Parity
        public static StopBits StopBits  { get; set; }      // static var <StopBits

        // Font
        public static string FontNumberColor    { get; set; }      // Number color
        public static string FontTextColor1     { get; set; }      // Text color 1 
        public static string FontTextColor2     { get; set; }      // Text color 2
        public static string FontTextColor3     { get; set; }      // Text color 3
        public static string FontTextColor4     { get; set; }      // Text color 4
        public static string FontTextColor5     { get; set; }      // Text color 5
        public static string FontTextColor6     { get; set; }      // Text color 6
        public static string FontTextColor7     { get; set; }      // Text color 7
        public static string FontTextColor8     { get; set; }      // Text color 8

        // Find
        public static bool FindMatchCase        { get; set; }      // Find option match case
        public static bool FindMatchWholeWord   { get; set; }      // Find option match whole word
        public static bool FindRegex            { get; set; }      // Find option regex

        // Display
        public static bool DispScroll           { get; set; }      // Display option scroll
    }
}
