﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    class NullQueryResultException : Exception
    {
        public NullQueryResultException(string message) : base(message)
        {
        }

    }
}
