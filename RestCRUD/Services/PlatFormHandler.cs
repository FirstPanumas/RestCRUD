using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestCRUD.Services
{
    public class PlatformHandler : IPlatformHandler
    {
        public HttpMessageHandler GetPlatFormHandler()
        {
#if ANDROID

#if NET7_0_OR_GREATER

            var h = new Xamarin.Android.Net.AndroidMessageHandler();
#endif
            h.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert == null && cert.Issuer.Equals("CN=localhost"))
                {
                    return true;

                }

                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return h;

#elif WINDOWNS || MACCATALYST 

            return null;
#else 
            throw new PlatformNotSupportedException("...");
#endif
        }
 
    }
}
