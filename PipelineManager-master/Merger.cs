using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipelineNetwork
{
    class Merger: Component
    {
        public Merger(Component inputA, Component inputB, Component output, int sumOfFlows, int x, int y)
            :base(x,y)
        {
            InputA = inputA;
            InputB = inputB;
            Output = output;
            SumOfFlows = sumOfFlows;

        }
        public Component InputA { get; set; }
        public Component InputB { get; set; }
        public Component Output { get; set; }
        public int SumOfFlows { get; set; }
        
    }
}
