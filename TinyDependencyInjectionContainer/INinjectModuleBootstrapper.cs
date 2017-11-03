using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace TinyDependencyInjectionContainer
{
    interface INinjectModuleBootstrapper
    {
        IList<INinjectModule> GetModules();
    }
}
