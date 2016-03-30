using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace mv.MAQL
{

    /// <summary>
    /// Log categories.
    /// </summary>
    public enum LogCategory : int
    {
        /// <summary>
        /// Debug logging.
        /// Will only logged if in debug mode.
        /// </summary>
        [Description("DEBUG")]
        lcDebug,

        /// <summary>
        /// Info logging.
        /// </summary>
        [Description("INFO")]
        lcInfo,

        /// <summary>
        /// Warning logging.
        /// </summary>
        [Description("WARNING")]
        lcWarning,

        /// <summary>
        /// Error logging.
        /// </summary>
        [Description("ERROR")]
        lcError,

        /// <summary>
        /// Fatal error logging.
        /// </summary>
        [Description("FATAL")]
        lcFatal
    }//end LogCategory

    class Logger : TextWriterTraceListener
    {
        private RichTextBox output_;

        public Logger(RichTextBox output, string logFile, string logName)
            : base(logFile, logName)
        {
            output_ = output;
        }

        public override void WriteLine (string message)
        {
            message += "\n";
            output_.SelectionColor = Color.Black;
            output_.AppendText(message);
            output_.ScrollToCaret();
            Trace.Flush();
        }

        public override void WriteLine (string message, string category)
        {
            switch(category.ToLower())
            {
                case "info":
                    output_.SelectionColor = Color.DarkGreen;
                    break;
                case "warning":
                    output_.SelectionColor = Color.Orange;
                    break;
                case "error":
                    output_.SelectionColor = Color.Red;
                    break;
                default:
                    output_.SelectionColor = Color.Black;
                    break;
            }
            message += "\n";
            output_.AppendText(message);
            output_.ScrollToCaret();
            Trace.Flush();
        }
    }
}
