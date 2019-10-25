using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace SoapClientService
{
    public class HttpWebResponseInterceptorProxy<T> : ExceptionInterceptorProxy<T>
    {

        public static T Create(T proxified, ICollection<Action<HttpWebResponse>> handlers) {
            return Create(proxified, new Collection<Action<Exception>> {
                exception => 
                {
                    for (Exception e = exception; e is object; e = e.InnerException)
                        if (e is WebException webException && webException.Response is HttpWebResponse httpWebResponse)
                            foreach (Action<HttpWebResponse> handler in handlers)
                                handler.Invoke(httpWebResponse);
                } 
            }
            );
        }

    }
}
