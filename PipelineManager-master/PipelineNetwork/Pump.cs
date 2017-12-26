using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PipelineNetwork
{
    class Pump: Component
    {
        public Pump(Component output, int maxflow, int currentflow, int x, int y)
            :base(x,y)
        {
            Output = output;
            MaxFlow = maxflow;
            CurrentFlow = currentflow;
            listOfNg = new List<Component>();
            this.compFlow = this.CurrentFlow;

        }
        public List<Component> listOfNg { get; set; }
        public Component Output { get; set; }
        public int MaxFlow { get; set; }
        public int CurrentFlow { get; set; }
        

        
    }
}
