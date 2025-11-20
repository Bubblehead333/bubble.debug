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
        public static void Log(string message, Object context = null)
        {
            if (showLogs)
                UnityEngine.Debug.Log(Colour("Bubble.Debug.Log: ", Color.white) + message, context);
        }

        /// <summary>
        /// Returns the method this was called from, with an optional message
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Trace(string message = null, bool highlight = false, Object context = null)
        {
            if (showLogs)
            {
                string logMessage = highlight ? Colour("Bubble.Debug.Trace: ", Color.green) : "Bubble.Debug.Trace: ";
                UnityEngine.Debug.Log(logMessage + GetMethodName() + " | " + message, context);
            }
        }

        /// <summary>
        /// Returns a basic note
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Error(string message, Object context = null)
        {
            UnityEngine.Debug.LogError(
                Colour("Bubble.Debug.Error: ", Color.red) + GetMethodName() + " | " + message, context
            );
        }

        /// <summary>
        /// Returns a basic note
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Warning(string message, Object context = null)
        {
            UnityEngine.Debug.LogWarning(
                Colour("Bubble.Debug.Warning: ", Color.orange) + GetMethodName() + " | " + message, context
            );
        }

        static string GetMethodName()
        {
            var st = new StackTrace(true);
            var sf = st.GetFrame(2);
            return sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name + GetLineNumber(sf);
        }

        static string GetLineNumber(StackFrame stackFrame)
        {
            int lineNumber = stackFrame.GetFileLineNumber();
            return lineNumber > 0 ? $"({lineNumber})" : "";
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