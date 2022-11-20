using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePrismShell.Core
{
    public interface IAllowCloseTheTab
    {
        void ConfirmNavigationRequest(Action<bool> continuationCallback);
    }
}
