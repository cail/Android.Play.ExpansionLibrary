namespace ExpansionDownloader.Sample
{
    using Android.App;

    using ExpansionDownloader.Service;

#if NOTIFICATION_BUILDER
    using Android.Net;
    using Android.Telephony;

    using ExpansionDownloader.Service;

#endif

    [Service]
    public class SampleDownloaderService : DownloaderService
    {
        /// <summary>
        /// This public key comes from your Android Market publisher account, and it
        /// used by the LVL to validate responses from Market on your behalf.
        /// Note: MODIFY FOR YOUR APPLICATION!
        /// </summary>
        protected override string PublicKey
        {
            get
            {
                return "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqSEPO6frjPZ/qdSTT80dCBjsHZouZGadBRwlg9g34ueC6j4F348"
                       + "dy0Xgo4NdKX39pSX1RNl0kGaxX6sg04bp4qx6RfwVyD1CPSEYdWldkuAQ9aNaQZ/yq6V+lmrqaKfJJuh1olqtsK8VVnvJ"
                       + "48Q+VwkIaT5CXhqeRAyZRXMEmEGPTNybSYVf5P90CxdSRwpae/w3S9rzuXOnfUhLKc9WmovRLQ8GzXYzhbNBzbWrK0NE+"
                       + "iXdxDGOZPDQPiLEaU2KliaWOBGO+2Cx5MSXZ3Xlm7e0Yo3F4x8BpMDQHs+3RSYTEaMvQk/t4sfMbA4xCzAP57cl6Ae6S"
                       + "bWU46mk+lqDeQIDAQAB";
            }
        }

        /// <summary>
        /// This is used by the preference obfuscater to make sure that your
        /// obfuscated preferences are different than the ones used by other
        /// applications.
        /// </summary>
        protected override byte[] Salt
        {
            get
            {
                return new byte[] { 1, 43, 12, 1, 54, 98, 100, 12, 43, 2, 8, 4, 9, 5, 106, 108, 33, 45, 1, 84 };
            }
        }

        /// <summary>
        /// Fill this in with the class name for your alarm receiver. We do this
        /// because receivers must be unique across all of Android (it's a good idea
        /// to make sure that your receiver is in your unique package)
        /// </summary>
        protected override string AlarmReceiverClassName
        {
            get
            {
                return "expansiondownloader.sample.SampleAlarmReceiver";
            }
        }

#if NOTIFICATION_BUILDER

        /// <summary>
        /// Updates the network type based upon the info returned from the 
        /// connectivity manager. 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override NetworkState GetNetworkState(NetworkInfo info)
        {
            var state = NetworkState.Disconnected;

            if (info.Type == ConnectivityType.Mobile)
            {
                var networkType = (NetworkType)info.Subtype;
                switch (networkType)
                {
                    case NetworkType.Hspap:
                    case NetworkType.Ehrpd:
                    case NetworkType.Lte:
                        state = NetworkState.Is3G | NetworkState.Is4G;
                        break;
                }
            }

            return base.GetNetworkState(info) | state;
        }

#endif

    }
}
