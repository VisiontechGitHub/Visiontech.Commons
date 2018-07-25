using System;
using System.Collections.Generic;
using System.Text;

namespace VisiontechCommons.Models
{
    public interface IProvider<T>
    {

        T Provided { get; }

    }
}
