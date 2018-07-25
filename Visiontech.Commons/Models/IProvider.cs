using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Visiontech.Commons.Models
{
    public interface IProvider<T>
    {

        T Provided { get; }

    }
}
