using System;
using System.Windows.Forms;
using Application.Services;
using Core;

namespace WindowsUI
{
    /// <summary>
    /// traps any exception thrown from a dispatcher and displays it as a MessageBox
    /// </summary>
    public class ExceptionTrapDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher _inner;

        public ExceptionTrapDispatcher(ICommandDispatcher inner)
        {
            _inner = inner;
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                _inner.Dispatch(command);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
           
        }
    }
}