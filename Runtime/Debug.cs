using System.Diagnostics;

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
                UnityEngine.Debug.Log("BubbleLog: " + message);
        }

        /// <summary>
        /// Returns the method this was called from, with an optional message
        /// </summary>
        /// <param name="message"></param>
        /// 
        public static void Trace(string message = null)
        {
            if (showLogs)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(1);

                UnityEngine.Debug.Log(
                    "BDTrace: " + sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name + " | " + message
                );
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
                "BDError: " + sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name  + " | " + message
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
                "BDWarning: " + sf.GetMethod().DeclaringType.Name + "." + sf.GetMethod().Name  + " | " + message
            );
        }

    }
}
