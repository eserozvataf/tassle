// --------------------------------------------------------------------------
// <copyright file="Service.cs" company="-">
// Copyright (c) 2008-2017 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
// Web: http://eser.ozvataf.com/ GitHub: http://github.com/eserozvataf
// </copyright>
// <author>Eser Ozvataf (eser@ozvataf.com)</author>
// --------------------------------------------------------------------------

//// This program is free software: you can redistribute it and/or modify
//// it under the terms of the GNU General Public License as published by
//// the Free Software Foundation, either version 3 of the License, or
//// (at your option) any later version.
//// 
//// This program is distributed in the hope that it will be useful,
//// but WITHOUT ANY WARRANTY; without even the implied warranty of
//// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//// GNU General Public License for more details.
////
//// You should have received a copy of the GNU General Public License
//// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Tassle.Services {
    /// <summary>
    /// Service class.
    /// </summary>
    public abstract class Service : IService {
        // fields

        /// <summary>
        /// The status
        /// </summary>
        private ServiceStatus _status;

        /// <summary>
        /// The status date
        /// </summary>
        private DateTimeOffset _statusDate;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger = null;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        // constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        protected Service(ILoggerFactory loggerFactory) {
            this._status = (this is ControllableService) ? ServiceStatus.Stopped : ServiceStatus.Passive;
            this._statusDate = DateTimeOffset.UtcNow;

            this._logger = loggerFactory.CreateLogger(this.Name);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Service"/> class.
        /// </summary>
        ~Service() {
            this.Dispose(false);
        }

        // abstract properties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description {
            get => string.Empty;
        }

        // properties

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ServiceStatus Status {
            get => this._status;
            protected set => this._status = value;
        }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>
        /// The status date.
        /// </value>
        public DateTimeOffset StatusDate {
            get => this._statusDate;
            protected set => this._statusDate = value;
        }

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger Logger {
            get => this._logger;
            protected set => this._logger = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Service"/> is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disposed; otherwise, <c>false</c>.
        /// </value>
        public bool Disposed {
            get => this._disposed;
            protected set => this._disposed = value;
        }

        // methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Called when [dispose].
        /// </summary>
        /// <param name="releaseManagedResources"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources</param>
        protected virtual void OnDispose(bool releaseManagedResources) {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="releaseManagedResources"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources</param>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        [SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "log")]
        protected void Dispose(bool releaseManagedResources) {
            if (this._disposed) {
                return;
            }

            this.OnDispose(releaseManagedResources);

            this._disposed = true;
        }
    }
}
