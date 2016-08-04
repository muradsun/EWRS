using ADMA.EWRS.Data.Access;
using ADMA.EWRS.Data.Models.Validation;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class BaseManager : IDisposable
    {
        internal UnitOfWork _unitOfWork;
        private IServiceProvider _provider;
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        //private IClaimsSecurityManager _claimsSecurityManager;

        public BaseManager(IServiceProvider provider)

        {
            _provider = provider;
            _unitOfWork = new UnitOfWork();
        }

        public BaseManager(IServiceProvider provider, UnitOfWork unitOfWork)
        {
            _provider = provider;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ADMA.EWRS.Data.Models.Validation.ValidationError> BusinessErrors { get; set; }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
                if (_unitOfWork != null)
                    _unitOfWork.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }

}
