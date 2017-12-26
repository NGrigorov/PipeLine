using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipelineNetwork
{
    class AdjustableSplitter:Splitter
    {
        public AdjustableSplitter(int flowOnOutputA, int flowOnOutputB, int proportion, Component input, Component outputA, Component outputB, int inputLevel, int x, int y) 
            :base(input, outputA, outputB, inputLevel, x,y)
        {
            FlowOnOutputA = flowOnOutputA;
            FlowOnOutputB = flowOnOutputB;
            Proportion = proportion;
        }
        public int FlowOnOutputA { get; set; } //Percentage number * 10 / 100
        public int FlowOnOutputB { get; set; } // allFlow - topflow
        public int Proportion { get; set; } //Percanteg Number
    }
}
