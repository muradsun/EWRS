﻿using ADMA.EWRS.Data.Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.BizDomain
{
    public class BaseManager
    {
        private IServiceProvider _provider;
        //private IClaimsSecurityManager _claimsSecurityManager;

        public BaseManager(IServiceProvider provider)

        {
            _provider = provider;
        }

        public IEnumerable<ADMA.EWRS.Data.Models.Validation.ValidationError> BusinessErrors { get; set; }

    }

}
