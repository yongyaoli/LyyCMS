using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Runtime.Session
{

    public interface LyyCMSIAbpSession :IAbpSession
    {
        String Site { get; set; }
    }
}
