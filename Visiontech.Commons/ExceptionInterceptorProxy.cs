using System;
using System.Collections.Generic;
using System.Reflection;

namespace SoapClientService
{
    public class ExceptionInterceptorProxy<T> : DispatchProxy
    {

        private T proxified;
        private ICollection<Action<Exception>> handlers;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try {
                return targetMethod.Invoke(proxified, args);
            } catch (Exception exception)
            {
                foreach (Action<Exception> handler in handlers)
                {
                    handler.Invoke(exception);
                }
                return default;
            }
        }

        public static T Create(T proxified, ICollection<Action<Exception>> handlers) {
            T proxy = Create<T, ExceptionInterceptorProxy<T>>();
            (proxy as ExceptionInterceptorProxy<T>).proxified = proxified;
            (proxy as ExceptionInterceptorProxy<T>).handlers = handlers;
            return proxy;
        }

    }
}
