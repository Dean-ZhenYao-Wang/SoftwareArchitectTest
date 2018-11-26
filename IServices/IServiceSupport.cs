using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZYW.IServices
{
    /// <summary>
    /// An identification interface, which must be implemented by all services
    /// This ensures that only real service implementation classes will be registered with Autofac
    /// </summary>
    public interface IServiceSupport
    {
    }
}
