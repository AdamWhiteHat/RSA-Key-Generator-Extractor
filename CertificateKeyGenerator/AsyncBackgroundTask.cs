using System;
using System.ComponentModel;

namespace CertificateKeyGenerator
{
    public class AsyncBackgroundTask : IDisposable
    {
        #region Public Properties & Events

        /// <summary>
        /// Gets a value indicating whether the AsyncBackgroundTask is running an asynchronous operation.
        /// </summary>
        public bool IsBusy { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the Dispose() method has been called.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the application has requested cancellation of a background operation.
        /// </summary>
        public bool CancellationPending { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the AsyncBackgroundTask class
        /// supports cancellation of a background operation. This value always returns true.
        /// </summary>
        public bool WorkerSupportsCancellation { get { return true; } }

        /// <summary>
        /// Occurs when AsyncBackgroundTask.RunWorkerAsync() is called.
        /// </summary>		
        public event DoWorkEventHandler DoWork
        {
            add { if (!IsDisposed) { _backgroundWorker.DoWork += value; } }
            remove { if (!IsDisposed) { _backgroundWorker.DoWork -= value; } }
        }

        /// <summary>
        /// Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        public event RunWorkerCompletedEventHandler RunWorkerCompleted
        {
            add { if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted += value; } }
            remove { if (!IsDisposed) { _backgroundWorker.RunWorkerCompleted -= value; } }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///  Initializes a new instance of the AsyncBackgroundTask class.
        /// </summary>		
        public AsyncBackgroundTask()
        {
            _backgroundWorker = new BackgroundWorker();

            IsBusy = false;
            IsDisposed = false;
            CancellationPending = false;
        }

        /// <summary>
        /// Starts execution of a background operation.
        /// </summary>
        /// <returns>True if a new background operation was started,
        /// or false if a background operation was already running, was pending cancellation, or the object was disposed.</returns>
        public bool RunWorkerAsync(object argument = null)
        {
            if (!CancellationPending && !IsBusy && !IsDisposed)
            {
                IsBusy = true;
                this.DoWork += BeginDoWork;
                _backgroundWorker.RunWorkerAsync(argument);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Requests cancellation of a pending background operation.
        /// </summary>
        /// <returns>True if the background worker was running and a cancellation request was sent,
        /// or false if no background operations were running, the operation had already been canceled,
        /// or the object was disposed.</returns>
        public bool CancelAsync()
        {
            if (IsBusy && !CancellationPending && !IsDisposed)
            {
                CancellationPending = true;
            }
            return false;
        }

        /// <summary>
        /// Releases all resources used by the class.
        /// </summary>
        public void Dispose()
        {
            if (!IsDisposed)
            {
                IsDisposed = true;

                if (_backgroundWorker != null)
                {
                    _backgroundWorker.Dispose();
                    _backgroundWorker = null;
                }
            }
        }

        public void SetWorkerStatus(bool isBusy)
        {
            IsBusy = isBusy;
        }

        #endregion

        #region Private Members

        private BackgroundWorker _backgroundWorker = null;

        private void BeginDoWork(object sender, DoWorkEventArgs e)
        {
            this.DoWork -= BeginDoWork;
            if (IsBusy && !CancellationPending && !IsDisposed)
            {
                this.RunWorkerCompleted += BeginWorkerCompleted;
            }
        }

        private void BeginWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.RunWorkerCompleted -= BeginWorkerCompleted;
            IsBusy = false;
        }

        #endregion
    }
}
