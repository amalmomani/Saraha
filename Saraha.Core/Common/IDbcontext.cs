using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Saraha.Core.Common
{
    public interface IDbcontext
    {
      DbConnection Connection { get; }
        
    }
}
