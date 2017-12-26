using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace PipelineNetwork
{
   abstract class Component
    {
        public delegate void Messanger(Component sender);

        //public event Messanger NeighborChanged;
        public event Messanger FlowChanged;

       protected Component[] pipesConnected;
        public Component(int x, int y)
        {
            X = x;
            Y = y;
            pipesConnected = new Component[3];
        }
        public int X { get; set; }
        public int Y { get; set; }

        public int compFlow { get; set; }
        
        public bool Pressed { get; set; }
        public Component[] PipesConnected { get { return this.pipesConnected; } set { this.pipesConnected = value; } }
        public bool ContainsPoint(int xmouse, int ymouse, int size)
        {
            if (Math.Abs(xmouse - X) <=  size/2)
            {
                if (Math.Abs(ymouse -Y) <= size/2)
                {
                    return true;
                }
            }
            return false;
        }
        protected virtual void OnFlowChange(int newFlow)
        {
            int oldFlow = compFlow;
            compFlow = newFlow;
            if (compFlow != oldFlow)
            {
                if (FlowChanged!= null)
                {
                    FlowChanged(this);
                }
            }
        }

    }
}
