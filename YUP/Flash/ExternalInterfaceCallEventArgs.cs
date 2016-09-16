using System;

namespace Ca.Magrathean.Yup.Flash
{
    /// <summary>
    /// This is the external interface callback event delegate, for flash calls
    /// </summary>
    /// <param name="sender">The ActiveX container sending the event</param>
    /// <param name="e">The ActiveX args returned from the callback</param>
    /// <returns>The ActiveX Object</returns>
	public delegate object ExternalInterfaceCallEventHandler(object sender, ExternalInterfaceCallEventArgs e);

	/// <summary>
	/// Event arguments for the ExternalInterfaceCallEventHandler.
	/// </summary>
	public class ExternalInterfaceCallEventArgs : System.EventArgs
	{
		private ExternalInterfaceCall _functionCall;

		public ExternalInterfaceCallEventArgs(ExternalInterfaceCall functionCall)
			: base()
		{
			_functionCall = functionCall;
		}

		public ExternalInterfaceCall FunctionCall
		{
			get { return _functionCall; }
		}
	}
}