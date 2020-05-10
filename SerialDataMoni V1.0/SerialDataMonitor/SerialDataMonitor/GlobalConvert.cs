using System;
using System.Text;
using System.Windows.Forms;

namespace SerialDataMonitor
{
    public class GlobalConvert
    {
        /*Convert string to hex*/
        #region StringToHex
        public string StringToHex(string hexstring)
        {
            var sb = new StringBuilder();
            foreach (char t in hexstring)
                sb.Append(Convert.ToInt32(t).ToString("x") + " ");
            return sb.ToString();
        }
        #endregion

        /*Convert hex string to byte array*/
        #region HexToByte
        public byte[] HexToByte(string msg)
        {
            string tempSting = null;
            //Remove any space from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of thestring divide by 2
            byte[] comBuffer = new byte[(msg.Length / 2) + (msg.Length % 2)];
            // Loop through the length of the provide string
            for (int i = 0; i < msg.Length; i += 2)
            {
                //convert each set of 2 character to a byte and add to the array
                try
                {
                    try
                    {
                        tempSting = msg.Substring(i, 2);  //Sub string 2 char
                    }
                    catch
                    {
                        // msg is odd (12 34 5) -> add 0 at last digit (12 34 05)
                        msg = msg.Insert(i, "0");
                        tempSting = msg.Substring(i, 2);
                    }
                    //convert sting to byte
                    comBuffer[i / 2] = (byte)Convert.ToByte(tempSting, 16);  // 16 = Base
                    //comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);  // 16 = Base
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect input format! : " + ex.Message, "Status",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return comBuffer;

        }
        #endregion

        #region ByteToHex
        public string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            //return the converted value
            return builder.ToString().ToUpper();
        }

        static byte[] EncodeToBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        #endregion /*Convert Data*/
       
    }
}
