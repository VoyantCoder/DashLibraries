
// Author: Dashie


using System;


namespace DashFramework
{
    namespace Networking
    {
        public enum PSFormatType
        {
            Singular, Ranged, Specific
        }

        public enum PSSettingsType
        {
            Address, Port, Timeout, Packets
        }

        public partial class Network
        {
            public partial class PortScanner
            {
                public bool DoCheckAddressFormat = true;
                public bool DoCheckPortFormat = true;
                public bool DoCheckTimeout = true;
                public bool SendPacketOnConnect = false;

                public void ToggleSetting(PSSettingsType Setting)
                {
                    try
                    {
                        switch (Setting)
                        {
                            case PSSettingsType.Address:
                                {
                                    DoCheckAddressFormat =
                                        (DoCheckAddressFormat == true ? false : true);

                                    break;
                                }
                            case PSSettingsType.Packets:
                                {
                                    SendPacketOnConnect =
                                        (SendPacketOnConnect == true ? false : true);

                                    break;
                                }
                            case PSSettingsType.Timeout:
                                {
                                    DoCheckTimeout =
                                        (DoCheckTimeout == true ? false : true);

                                    break;
                                }
                            case PSSettingsType.Port:
                                {
                                    DoCheckPortFormat =
                                        (DoCheckPortFormat == true ? false : true);

                                    break;
                                }
                        }
                    }

                    catch
                    {
                        throw;
                    }
                }
            }
        }
    }
}
