using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PipelineNetwork
{
    class Splitter:Component
    {
        public Splitter(Component input, Component outputA, Component outputB, int inputLevel, int x, int y)
            :base(x,y)
        {
            Input = input;
            OutputA = outputA;
            OutputB = outputB;
            InputLevel = inputLevel;
        }
        public Component Input { get; set; }
        public Component OutputA { get; set; }
        public Component OutputB { get; set; }
        public int InputLevel { get; set; }
    }
}
