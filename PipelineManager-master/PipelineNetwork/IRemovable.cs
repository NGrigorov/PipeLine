using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineNetwork
{
    interface IRemovable
    {
        bool removePipes(Component a, Component b);
    }
}
