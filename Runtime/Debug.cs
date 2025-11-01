using System.Diagnostics;
using UnityEngine;

namespace Bubble.Debug
{
    /// <summary>
    /// Error and notice handling class. 
    /// </summary>
    /// 
    public class BD
    {
        static bool showLogs = true;

        /// <summary>
        /// Returns a basic note
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Log(string message)
        {
            if (showLogs)
                UnityEngine.Debug.Log(Colour("Bubble.Debug.Log: ", Color.white) + message);
        }

        /// <summary>
        /// Returns the method this was called from, with an optional message
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Trace(string message = null, bool highlight = false)
        {
            if (showLogs)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(1);

                string logMessage = highlight ? Colour("Bubble.Debug.Trace: ", Color.green) : "Bubble.Debug.Trace: ";
                logMessage += sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name + " | " + message;
                UnityEngine.Debug.Log(logMessage);
            }
        }

        /// <summary>
        /// Returns a basic note
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Error(string message)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            UnityEngine.Debug.LogError(
                Colour("Bubble.Debug.Error: ", Color.red) +
                sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name  + " | " + message
            );
        }

        /// <summary>
        /// Returns a basic note
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Warning(string message)
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            UnityEngine.Debug.LogWarning(
                Colour("Bubble.Debug.Warning: ", Color.orange) +
                sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name  + " | " + message
            );
        }

        #region Formatting

        public static string ToHex(Color colour)
        {
            return string.Format(
                "#{0:X2}{1:X2}{2:X2}", 
                (byte)(colour.r * 255), 
                (byte)(colour.g * 255), 
                (byte)(colour.b * 255)
            );
        }

        public static string Colour(string text, Color colour)
        {
            string output;
            output = string.Format("<color={0}>{1}</color>", ToHex(colour), text);
            return output;
        } 

        #endregion
    }
}