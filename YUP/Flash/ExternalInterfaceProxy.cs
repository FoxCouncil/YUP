﻿using System;
using System.Collections.Generic;
using System.Text;
using AxShockwaveFlashObjects;
using System.Runtime.InteropServices;

namespace Ca.Magrathean.Yup.Flash
{
    public class ExternalInterfaceProxy
    {
        #region Private Fields

        private AxShockwaveFlash _flashControl;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new ExternalInterfaceProxy for the specified Shockwave Flash ActiveX control.
        /// </summary>
        /// <param name="flashControl">The Shockwave Flash ActiveX control with whom communication
        /// is managed by this proxy.</param>
        public ExternalInterfaceProxy(AxShockwaveFlash flashControl)
        {
            _flashControl = flashControl as AxShockwaveFlash;
            _flashControl.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(_flashControl_FlashCall);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Calls the ActionScript function which is registered as a callback method with the
        /// ActionScript ExternalInterface class.
        /// </summary>
        /// <param name="functionName">The function name registered with the ExternalInterface class
        /// corresponding to the ActionScript function that is to be called</param>
        /// <param name="arguments">Additional arguments, if any, to pass to the ActionScript function.</param>
        /// <returns>The result returned by the ActionScript function, or null if no result is returned.</returns>
        /// <exception cref="System.Runtime.Interop.COMException">Thrown when there is an error
        /// calling the method on Flash Player. For instance, this exception is raised if the
        /// specified function name is not registered as a callable function with the ExternalInterface
        /// class; it is also raised if the ActionScript method throws an Error.</exception>
        public object Call(string functionName, params object[] arguments)
        {
            try
            {
                string request = ExternalInterfaceSerializer.EncodeInvoke(functionName, arguments);
                string response = _flashControl.CallFunction(request);
                object result = ExternalInterfaceSerializer.DecodeResult(response);
                return result;
            }
            catch (AccessViolationException e)
            {
                return e;
            }
            catch (COMException e)
            {
                System.Windows.Forms.MessageBox.Show("A call to the ActionScript has failed.\n\nThis is a serious error; and it's beta software.", "Serious Error");
            }

            return null;
        }
        #endregion

        #region Events

        /// <summary>
        /// Raised when an External Interface call is made from Flash Player.
        /// </summary>
        public event ExternalInterfaceCallEventHandler ExternalInterfaceCall;

        /// <summary>
        /// Raises the ExternalInterfaceCall event, indicating that a call has come from Flash Player.
        /// </summary>
        /// <param name="e">The event arguments related to the event being raised.</param>
        protected virtual object OnExternalInterfaceCall(ExternalInterfaceCallEventArgs e)
        {
            if (ExternalInterfaceCall != null)
            {
                return ExternalInterfaceCall(this, e);
            }
            return null;
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Called when Flash Player raises the FlashCallEvent (when an External Interface call
        /// is made by ActionScript)
        /// </summary>
        /// <param name="sender">The object raising the event</param>
        /// <param name="e">The arguments for the event</param>
        private void _flashControl_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            ExternalInterfaceCall functionCall = ExternalInterfaceSerializer.DecodeInvoke(e.request);
            ExternalInterfaceCallEventArgs eventArgs = new ExternalInterfaceCallEventArgs(functionCall);
            object response = OnExternalInterfaceCall(eventArgs);
            _flashControl.SetReturnValue(ExternalInterfaceSerializer.EncodeResult(response));
        }

        #endregion
    }
}
