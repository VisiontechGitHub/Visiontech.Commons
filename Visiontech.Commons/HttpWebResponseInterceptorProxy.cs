using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.ServiceModel;

namespace SoapClientService
{
    public class HttpWebResponseInterceptorProxy<T> : ExceptionInterceptorProxy<T>
    {

        public static T Create(T proxified, ICollection<Action<HttpWebResponse>> handlers, ICollection<Action<FaultException>> faultHandlers = default, ICollection<Action<Exception>> genericHandlers = default) {
            return Create(proxified, new Collection<Action<Exception>> {
                exception => 
                {
                    if (genericHandlers is object)
                        foreach (Action<Exception> handler in genericHandlers)
                                handler.Invoke(exception);
                    for (Exception e = exception; e is object; e = e.InnerException)
                        if (e is WebException webException && webException.Response is HttpWebResponse httpWebResponse)
                            foreach (Action<HttpWebResponse> handler in handlers)
                                handler.Invoke(httpWebResponse);
                        else if (e is FaultException faultException)
                            foreach (Action<FaultException> handler in faultHandlers)
                                handler.Invoke(faultException);
                } 
            }
            );
        }

    }
}
