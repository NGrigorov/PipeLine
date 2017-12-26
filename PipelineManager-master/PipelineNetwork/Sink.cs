using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipelineNetwork
{
    class Sink: Component
    {//[0,1,2] //0,1 
        public Sink(Component input, int flowOnInput, int x, int y)
            :base(x,y)
        {
            Input = input;
            FlowOnInput = flowOnInput;
            
        }
        public Component Input { get; set; }

        public int FlowOnInput { get; set; }
    }
}
