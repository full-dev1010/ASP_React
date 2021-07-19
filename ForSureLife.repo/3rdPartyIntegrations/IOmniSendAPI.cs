using System;
using System.Collections.Generic;
using System.Text;

namespace ForSureLife.repo._3rdPartyIntegrations
{
    public interface IOmniSendAPI
    {
        public bool SendToOmniSend(Application application);
    }
}
