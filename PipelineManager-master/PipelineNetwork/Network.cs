using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PipelineNetwork
{
    class Network
    {
        private List<Component> listOfComponents;


        public Network()
        {
            listOfComponents = new List<Component>();

        }
        public void RemoveConnection(Component ab, Component ba)
        {
            FindConnection(ab.PipesConnected, ba);
            if (ba != null)
                FindConnection(ba.PipesConnected, ab);

            Recalc(ab);
            Recalc(ba);

        }

        private bool FindConnection(Component[] a, Component ab)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (ab == a[i])
                {
                    a[i] = null;
                    return true;
                }
            }
            return false;
        }
        public bool AddComponent(Component component)
        {
            Component temp = component;
            listOfComponents.Add(component);
            return true;
        }
        // Adding pipeline is actually connecting the elements -
        //we do not need the pipeline Class!
        public bool AddPipeline(Component a, Component b, int SideA, int SideB)//0 for top, 1 for bot
        {
            //Checks to prevent wrong pipe placement
            if (a == b || b is Pump)
            {
                return false;
            }
            else
            {
                if (a is Pump && a.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (a is Sink && a.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (a is Merger && a.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (a is Splitter && SideA == 0 && a.PipesConnected[1] != null)
                {
                    return false;
                }
                else if (a is Splitter && SideA == 1 && a.PipesConnected[2] != null)
                {
                    return false;
                }

                //For B
                if (b is Pump && b.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (b is Sink && b.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (b is Splitter && b.PipesConnected[0] != null)
                {
                    return false;
                }
                else if (b is Merger && SideB == 0 && b.PipesConnected[1] != null)
                {
                    return false;
                }
                else if (b is Merger && SideB == 1 && b.PipesConnected[2] != null)
                {
                    return false;
                }

                // Connection part
                if (a is Pump)
                {
                    ((Pump)a).Output = b;
                    ((Pump)a).PipesConnected[0] = b;
                }
                else if (a is Merger)
                {
                    ((Merger)a).Output = b;
                    ((Merger)a).PipesConnected[0] = b;
                }
                else if (a is AdjustableSplitter)
                {
                    if (SideA == 0)
                    {
                        ((AdjustableSplitter)a).OutputA = b;
                        ((AdjustableSplitter)a).PipesConnected[1] = b;
                    }
                    else
                    {
                        ((AdjustableSplitter)a).OutputB = b;
                        ((AdjustableSplitter)a).PipesConnected[2] = b;
                    }
                }
                else if (a is Splitter)
                {
                    if (SideA == 0)
                    {
                        ((Splitter)a).OutputA = b;
                        ((Splitter)a).PipesConnected[1] = b;
                    }
                    else
                    {
                        ((Splitter)a).OutputB = b;
                        ((Splitter)a).PipesConnected[2] = b;
                    }
                }

                if (b is AdjustableSplitter)
                {
                    ((AdjustableSplitter)b).Input = a;
                    ((AdjustableSplitter)b).PipesConnected[0] = a;
                }
                else if (b is Splitter)
                {
                    ((Splitter)b).Input = a;
                    ((Splitter)b).PipesConnected[0] = a;
                }
                else if (b is Sink)
                {
                    ((Sink)b).Input = a;
                    ((Sink)b).PipesConnected[0] = a;
                }
                else if (b is Merger)
                {

                    if (SideB == 0)
                    {
                        ((Merger)b).InputA = a;
                        ((Merger)b).PipesConnected[1] = a;
                    }
                    else
                    {
                        ((Merger)b).InputB = a;
                        ((Merger)b).PipesConnected[2] = a;
                    }
                }
                Recalc(a);
                return true;
            }
        }

        // We need delete component and if there were connected the pipeline
        // we need to redraw also pipelines. 
        public bool DeleteComponent(Component component)
        {
            Component temp;
            for (int i = 0; i < component.PipesConnected.Length; i++)
            {
                temp = component.PipesConnected[i];
                if (component.PipesConnected[i] != null)
                {
                    FindConnection(component.PipesConnected[i].PipesConnected, component);

                }
                Recalc(temp);
            }
            listOfComponents.Remove(component);
            return true;

        }
        //changes pumps flow in the one element, but of course, we need to implement
        //recalculation for further elements!!
        public void ChangePumpFlow(Pump pump, int max_flow, int cur_flow)
        {
            foreach (Component c in listOfComponents)
            {
                if (pump == c)
                {
                    ((Pump)c).CurrentFlow = cur_flow;
                    ((Pump)c).MaxFlow = max_flow;
                    ((Pump)c).compFlow = cur_flow;
                }
            }
        }
        //Here is the same! We need after changing adjustment to recalculate flows!
        public void AdjustSplitter(AdjustableSplitter adjSplitter)
        {

        }
        // Saves the Network to the file
        public void SaveNetwork()
        {

        }
        //Here is just loading from the file
        public void LoadNetwork()
        {

        }
        //public void Recalculate(Component a)
        //{
        //    for(int i = 0; i < 3; i++)
        //    {
        //        a.PipesConnected[i].
        //    }
        //}
        //Drawing Components is done for now.
        public void DrawAllComponents(Graphics gr, ImageList il)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               16,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            foreach (Component component in listOfComponents)
            {
                if (component is Sink)
                {
                    Sink temp = component as Sink;
                    gr.DrawImage(il.Images[0], component.X - il.ImageSize.Width / 2, component.Y - il.ImageSize.Height / 2);
                    gr.DrawString(temp.FlowOnInput.ToString(), font, Brushes.Red, temp.X + 15, temp.Y - 30);
                }
                else if (component is Pump)
                {
                    Pump temp = component as Pump;
                    gr.DrawImage(il.Images[1], temp.X - il.ImageSize.Width / 2, temp.Y - il.ImageSize.Height / 2);
                    gr.DrawString(temp.CurrentFlow.ToString(), font, Brushes.Red, temp.X + 15, temp.Y - 30);
                }
                else if (component is Splitter)
                {
                    if (component is AdjustableSplitter)
                    {
                        AdjustableSplitter temp = component as AdjustableSplitter;
                        gr.DrawImage(il.Images[3], component.X - il.ImageSize.Width / 2, component.Y - il.ImageSize.Height / 2);
                        gr.DrawString(temp.FlowOnOutputA.ToString(), font, Brushes.Red, temp.X + 15, temp.Y - 30);
                        gr.DrawString(temp.FlowOnOutputB.ToString(), font, Brushes.Red, temp.X + 15, temp.Y + 30);
                    }
                    else
                    {
                        Splitter temp = component as Splitter;
                        gr.DrawImage(il.Images[2], component.X - il.ImageSize.Width / 2, component.Y - il.ImageSize.Height / 2);
                        gr.DrawString((temp.InputLevel - temp.InputLevel / 2).ToString(), font, Brushes.Red, temp.X + 15, temp.Y - 30);
                        gr.DrawString((temp.InputLevel / 2).ToString(), font, Brushes.Red, temp.X + 15, temp.Y + 30);
                    }
                }
                else if (component is Merger)
                {
                    Merger temp = component as Merger;
                    gr.DrawImage(il.Images[4], component.X - il.ImageSize.Width / 2, component.Y - il.ImageSize.Height / 2);
                    gr.DrawString(temp.SumOfFlows.ToString(), font, Brushes.Red, temp.X + 15, temp.Y + 30);
                }

                if (component.Pressed == true)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(120, 120, 5, 15));
                    gr.FillRectangle(brush, component.X - il.ImageSize.Width / 2, component.Y - il.ImageSize.Height / 2, il.ImageSize.Width, il.ImageSize.Height);
                }
            }


        }

        //We need draw the pipelines - the loop which we discussed today
        public void DrawAllPipelines(Graphics gr)
        {
            Pen pen = new Pen(Color.Orange, 5);
            Pen pen1 = new Pen(Color.Red, 5);
            Pen pen2 = new Pen(Color.Blue, 5);
            foreach (Component c in listOfComponents)
            {
                if (c.PipesConnected[0] != null)
                {
                    gr.DrawLine(pen, c.X, c.Y, c.PipesConnected[0].X, c.PipesConnected[0].Y);
                }
                if (c.PipesConnected[1] != null)
                {
                    gr.DrawLine(pen1, c.X, c.Y - 10, c.PipesConnected[1].X, c.PipesConnected[1].Y);
                }
                if (c.PipesConnected[2] != null)
                {
                    gr.DrawLine(pen2, c.X, c.Y + 10, c.PipesConnected[2].X, c.PipesConnected[2].Y);
                }
            }
        }
        /*

    HERE I JUST LIST THE METHODS THAT IMO WE HAVE TO IMPLEMENT

    GET_NEIGBOUR? ADD NEIGHBOUR - > These methods imo should be in the component class
    we would need them i think for usage in drawing components and recalculation after
    we do some changes

    OPEN_Project
    Close Project - very simple, so dont bother with these now :D
    */
        public Component GetComponent(int xmouse, int ymouse, int size)
        {
            foreach (Component component in listOfComponents)
            {
                if (component.ContainsPoint(xmouse, ymouse, size))
                {
                    return component;
                }
            }
            return null;
        }

        public List<Component> GetAllComponents()
        {
            return this.listOfComponents;
        }

        public void RemoveAllComponents()
        {
            listOfComponents.Clear();
        }

        public void Recalc(Component c)
        {

            if (c is Sink)
            {
                Sink sinkComponent = (Sink)c;
                if (sinkComponent.PipesConnected[0] != null)
                {
                    if(sinkComponent.PipesConnected[0] is Splitter)
                    {
                        if(sinkComponent.PipesConnected[0] is AdjustableSplitter)
                        {
                            if (sinkComponent.PipesConnected[0].PipesConnected[1] == sinkComponent)
                            {
                                sinkComponent.FlowOnInput = ((AdjustableSplitter)sinkComponent.PipesConnected[0]).FlowOnOutputA;
                                sinkComponent.compFlow = sinkComponent.FlowOnInput;
                            }
                            else if (sinkComponent.PipesConnected[0].PipesConnected[2] == sinkComponent)
                            {
                                sinkComponent.FlowOnInput += ((AdjustableSplitter)sinkComponent.PipesConnected[0]).FlowOnOutputB;
                                sinkComponent.compFlow = sinkComponent.FlowOnInput;
                            }
                        }
                        else if(sinkComponent.PipesConnected[0] is Splitter)
                        {
                            if (sinkComponent.PipesConnected[0].PipesConnected[1] == sinkComponent)
                            {
                                sinkComponent.FlowOnInput = sinkComponent.PipesConnected[0].compFlow - sinkComponent.PipesConnected[1].compFlow / 2;
                                sinkComponent.compFlow = sinkComponent.FlowOnInput;
                            }
                            else if (sinkComponent.PipesConnected[0].PipesConnected[2] == sinkComponent)
                            {
                                sinkComponent.FlowOnInput = sinkComponent.PipesConnected[1].compFlow / 2;
                                sinkComponent.compFlow = sinkComponent.FlowOnInput;
                            }
                        }
                    }
                    else
                    {
                        sinkComponent.FlowOnInput = sinkComponent.PipesConnected[0].compFlow;
                        sinkComponent.compFlow = sinkComponent.FlowOnInput;
                        return;
                    }
                    
                }
            }

            else if (c is Merger)
            {
                int tempOldFlowA = 0;
                int tempOldFlowB = 0;
                Merger mergerComponent = (Merger)c;
                if (mergerComponent.PipesConnected[1] != null && mergerComponent.PipesConnected[2] != null)
                {
                    
                        if (mergerComponent.PipesConnected[1] is AdjustableSplitter)
                        {
                            if (mergerComponent.PipesConnected[1].PipesConnected[1] == mergerComponent)
                            {
                                tempOldFlowA = ((AdjustableSplitter)mergerComponent.PipesConnected[1]).FlowOnOutputA;
                            }
                            else if (mergerComponent.PipesConnected[1].PipesConnected[2] == mergerComponent)
                            {
                                tempOldFlowA = ((AdjustableSplitter)mergerComponent.PipesConnected[1]).FlowOnOutputB;
                            }
                        }
                        else if (mergerComponent.PipesConnected[1] is Splitter)
                        {
                            if (mergerComponent.PipesConnected[1].PipesConnected[1] == mergerComponent)
                            {
                                tempOldFlowA = mergerComponent.PipesConnected[1].compFlow - mergerComponent.PipesConnected[1].compFlow / 2;
                            }
                            else if (mergerComponent.PipesConnected[1].PipesConnected[2] == mergerComponent)
                            {
                                tempOldFlowA = mergerComponent.PipesConnected[1].compFlow / 2;
                            }
                        }


                        //////////////////////////

                        if (mergerComponent.PipesConnected[2] is AdjustableSplitter)
                        {
                            if (mergerComponent.PipesConnected[2].PipesConnected[1] == mergerComponent)
                            {
                                tempOldFlowB = ((AdjustableSplitter)mergerComponent.PipesConnected[2]).FlowOnOutputA;
                            }
                            else if (mergerComponent.PipesConnected[2].PipesConnected[2] == mergerComponent)
                            {
                                tempOldFlowB = ((AdjustableSplitter)mergerComponent.PipesConnected[2]).FlowOnOutputB;
                            }
                        }
                        else if (mergerComponent.PipesConnected[2] is Splitter)
                        {
                            if (mergerComponent.PipesConnected[2].PipesConnected[1] == mergerComponent)
                            {
                                tempOldFlowB = mergerComponent.PipesConnected[2].compFlow - mergerComponent.PipesConnected[2].compFlow / 2;
                            }
                            else if (mergerComponent.PipesConnected[2].PipesConnected[2] == mergerComponent)
                            {
                                tempOldFlowB = mergerComponent.PipesConnected[2].compFlow / 2;
                            }
                        }

                        if (tempOldFlowA != 0 && tempOldFlowB != 0)
                        {
                            mergerComponent.SumOfFlows = tempOldFlowA + tempOldFlowB;
                            mergerComponent.compFlow = mergerComponent.SumOfFlows;
                        }
                        else if(tempOldFlowA != 0)
                        {
                            mergerComponent.SumOfFlows = tempOldFlowA + mergerComponent.PipesConnected[2].compFlow;
                            mergerComponent.compFlow = mergerComponent.SumOfFlows;
                        }
                        else if(tempOldFlowB != 0)
                        {
                            mergerComponent.SumOfFlows = mergerComponent.PipesConnected[1].compFlow + tempOldFlowB;
                            mergerComponent.compFlow = mergerComponent.SumOfFlows;
                        }
                        else
                        {
                            mergerComponent.SumOfFlows = mergerComponent.PipesConnected[1].compFlow + mergerComponent.PipesConnected[2].compFlow;
                            mergerComponent.compFlow = mergerComponent.SumOfFlows;
                        }
                        
                    

                }
                else if (mergerComponent.PipesConnected[1] != null)
                {
                    if (mergerComponent.PipesConnected[1] is Splitter)
                    {
                        if (mergerComponent.PipesConnected[1] is AdjustableSplitter)
                        {
                            if (mergerComponent.PipesConnected[1].PipesConnected[1] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = ((AdjustableSplitter)mergerComponent.PipesConnected[1]).FlowOnOutputA;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                            else if (mergerComponent.PipesConnected[1].PipesConnected[2] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = ((AdjustableSplitter)mergerComponent.PipesConnected[1]).FlowOnOutputB;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                        }
                        else if (mergerComponent.PipesConnected[1] is Splitter)
                        {
                            if (mergerComponent.PipesConnected[1].PipesConnected[1] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = mergerComponent.PipesConnected[1].compFlow - mergerComponent.PipesConnected[1].compFlow / 2;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                            else if (mergerComponent.PipesConnected[1].PipesConnected[2] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = mergerComponent.PipesConnected[1].compFlow / 2;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                        }
                    }
                    else
                    {
                        mergerComponent.SumOfFlows = mergerComponent.PipesConnected[1].compFlow;
                        mergerComponent.compFlow = mergerComponent.SumOfFlows;
                    }
                }
                else if (mergerComponent.PipesConnected[2] != null)
                {
                    if (mergerComponent.PipesConnected[2] is Splitter)
                    {
                        if (mergerComponent.PipesConnected[2] is AdjustableSplitter)
                        {
                            if (mergerComponent.PipesConnected[2].PipesConnected[1] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = ((AdjustableSplitter)mergerComponent.PipesConnected[2]).FlowOnOutputA;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                            else if (mergerComponent.PipesConnected[2].PipesConnected[2] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = ((AdjustableSplitter)mergerComponent.PipesConnected[2]).FlowOnOutputB;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                        }
                        else if (mergerComponent.PipesConnected[2] is Splitter)
                        {
                            if (mergerComponent.PipesConnected[2].PipesConnected[1] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = mergerComponent.PipesConnected[2].compFlow - mergerComponent.PipesConnected[2].compFlow / 2;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                            else if (mergerComponent.PipesConnected[2].PipesConnected[2] == mergerComponent)
                            {
                                mergerComponent.SumOfFlows = mergerComponent.PipesConnected[2].compFlow / 2;
                                mergerComponent.compFlow = mergerComponent.SumOfFlows;
                            }
                        }
                    }
                    else
                    {
                        mergerComponent.SumOfFlows = mergerComponent.PipesConnected[2].compFlow;
                        mergerComponent.compFlow = mergerComponent.SumOfFlows;
                    }
                }
                else
                {
                    mergerComponent.SumOfFlows = 0;
                    mergerComponent.compFlow = mergerComponent.SumOfFlows;
                }


                if (mergerComponent.PipesConnected[0] != null)
                {
                    mergerComponent.PipesConnected[0].compFlow = mergerComponent.SumOfFlows;
                    Recalc(mergerComponent.PipesConnected[0]);
                }
                return;
            }
            else if (c is AdjustableSplitter)
            {
                AdjustableSplitter adjustableSplitterComponent = (AdjustableSplitter)c;
                if (adjustableSplitterComponent.PipesConnected[0] != null)
                {
                    if (adjustableSplitterComponent.PipesConnected[0] is AdjustableSplitter)
                    {
                        if (adjustableSplitterComponent.PipesConnected[0].PipesConnected[1] == adjustableSplitterComponent)
                        {
                            adjustableSplitterComponent.InputLevel = ((AdjustableSplitter)adjustableSplitterComponent.PipesConnected[0]).FlowOnOutputA;
                            adjustableSplitterComponent.compFlow = adjustableSplitterComponent.InputLevel;
                        }
                        else if (adjustableSplitterComponent.PipesConnected[0].PipesConnected[2] == adjustableSplitterComponent)
                        {
                            adjustableSplitterComponent.InputLevel = ((AdjustableSplitter)adjustableSplitterComponent.PipesConnected[0]).FlowOnOutputB;
                            adjustableSplitterComponent.compFlow = adjustableSplitterComponent.InputLevel;
                        }
                    }
                    else if (adjustableSplitterComponent.PipesConnected[0] is Splitter)
                    {
                        adjustableSplitterComponent.InputLevel = adjustableSplitterComponent.PipesConnected[0].compFlow / 2;
                        adjustableSplitterComponent.compFlow = adjustableSplitterComponent.InputLevel;
                    }
                    else
                    {
                        adjustableSplitterComponent.InputLevel = adjustableSplitterComponent.PipesConnected[0].compFlow;
                        adjustableSplitterComponent.compFlow = adjustableSplitterComponent.InputLevel;
                    }
                    adjustableSplitterComponent.FlowOnOutputA = adjustableSplitterComponent.compFlow * adjustableSplitterComponent.Proportion / 100;
                    adjustableSplitterComponent.FlowOnOutputB = adjustableSplitterComponent.compFlow - adjustableSplitterComponent.FlowOnOutputA;
                }
                else if (adjustableSplitterComponent.PipesConnected[0] == null)
                {
                    adjustableSplitterComponent.InputLevel = 0;
                    adjustableSplitterComponent.compFlow = adjustableSplitterComponent.InputLevel;
                }

                if (adjustableSplitterComponent.PipesConnected[1] != null && adjustableSplitterComponent.PipesConnected[2] != null)
                {
                    if (adjustableSplitterComponent.InputLevel != 0)
                    {
                        adjustableSplitterComponent.PipesConnected[1].compFlow = adjustableSplitterComponent.InputLevel * adjustableSplitterComponent.Proportion / 100;
                        adjustableSplitterComponent.FlowOnOutputA = adjustableSplitterComponent.PipesConnected[1].compFlow;
                        adjustableSplitterComponent.PipesConnected[2].compFlow = adjustableSplitterComponent.InputLevel - adjustableSplitterComponent.PipesConnected[1].compFlow;
                        adjustableSplitterComponent.FlowOnOutputB = adjustableSplitterComponent.PipesConnected[2].compFlow;
                        Recalc(adjustableSplitterComponent.PipesConnected[1]);
                        Recalc(adjustableSplitterComponent.PipesConnected[2]);
                    }
                    else if (adjustableSplitterComponent.InputLevel == 0)
                    {
                        adjustableSplitterComponent.PipesConnected[1].compFlow = adjustableSplitterComponent.InputLevel;
                        adjustableSplitterComponent.FlowOnOutputA = adjustableSplitterComponent.PipesConnected[1].compFlow;
                        adjustableSplitterComponent.PipesConnected[2].compFlow = adjustableSplitterComponent.InputLevel;
                        adjustableSplitterComponent.FlowOnOutputB = adjustableSplitterComponent.PipesConnected[2].compFlow;
                        Recalc(adjustableSplitterComponent.PipesConnected[1]);
                        Recalc(adjustableSplitterComponent.PipesConnected[2]);
                    }
                }
                else if (adjustableSplitterComponent.PipesConnected[1] != null)
                {
                    adjustableSplitterComponent.PipesConnected[1].compFlow = adjustableSplitterComponent.InputLevel * adjustableSplitterComponent.Proportion / 100;
                    adjustableSplitterComponent.FlowOnOutputA = adjustableSplitterComponent.PipesConnected[1].compFlow;
                    Recalc(adjustableSplitterComponent.PipesConnected[1]);
                }
                else if (adjustableSplitterComponent.PipesConnected[2] != null)
                {
                    adjustableSplitterComponent.PipesConnected[2].compFlow = adjustableSplitterComponent.InputLevel - (adjustableSplitterComponent.InputLevel * adjustableSplitterComponent.Proportion / 100);
                    adjustableSplitterComponent.FlowOnOutputB = adjustableSplitterComponent.PipesConnected[2].compFlow;
                    Recalc(adjustableSplitterComponent.PipesConnected[2]);
                }
                return;
            }
            else if (c is Splitter)
            {
                Splitter splitterComponent = (Splitter)c;
                if (splitterComponent.PipesConnected[0] != null)
                {

                    if (splitterComponent.PipesConnected[0] is AdjustableSplitter)
                    {
                        if (splitterComponent.PipesConnected[0].PipesConnected[1] == splitterComponent)
                        {
                            splitterComponent.InputLevel = ((AdjustableSplitter)splitterComponent.PipesConnected[0]).FlowOnOutputA;
                            splitterComponent.compFlow = splitterComponent.InputLevel;
                        }
                        else if (splitterComponent.PipesConnected[0].PipesConnected[2] == splitterComponent)
                        {
                            splitterComponent.InputLevel = ((AdjustableSplitter)splitterComponent.PipesConnected[0]).FlowOnOutputB;
                            splitterComponent.compFlow = splitterComponent.InputLevel;
                        }
                    }
                    else if (splitterComponent.PipesConnected[0] is Splitter)
                    {
                        splitterComponent.InputLevel = splitterComponent.PipesConnected[0].compFlow / 2;
                        splitterComponent.compFlow = splitterComponent.InputLevel;
                    }
                    else
                    {
                        splitterComponent.InputLevel = splitterComponent.PipesConnected[0].compFlow;
                        splitterComponent.compFlow = splitterComponent.InputLevel;
                    }

                }
                else if (splitterComponent.PipesConnected[0] == null)
                {
                    splitterComponent.InputLevel = 0;
                    splitterComponent.compFlow = splitterComponent.InputLevel;
                }

                if (splitterComponent.PipesConnected[1] != null && splitterComponent.PipesConnected[2] != null)
                {
                    if (splitterComponent.InputLevel != 0)
                    {
                        splitterComponent.PipesConnected[1].compFlow = splitterComponent.InputLevel / 2;
                        splitterComponent.PipesConnected[2].compFlow = splitterComponent.InputLevel - splitterComponent.PipesConnected[1].compFlow;
                        Recalc(splitterComponent.PipesConnected[1]);
                        Recalc(splitterComponent.PipesConnected[2]);
                    }
                    else if (splitterComponent.InputLevel == 0)
                    {
                        splitterComponent.PipesConnected[1].compFlow = splitterComponent.InputLevel;
                        splitterComponent.PipesConnected[2].compFlow = splitterComponent.InputLevel;
                        Recalc(splitterComponent.PipesConnected[1]);
                        Recalc(splitterComponent.PipesConnected[2]);
                    }
                }
                else if (splitterComponent.PipesConnected[1] != null)
                {
                    splitterComponent.PipesConnected[1].compFlow = splitterComponent.InputLevel / 2;
                    Recalc(splitterComponent.PipesConnected[1]);
                }
                else if (splitterComponent.PipesConnected[2] != null)
                {
                    splitterComponent.PipesConnected[2].compFlow = splitterComponent.InputLevel / 2;
                    Recalc(splitterComponent.PipesConnected[2]);
                }
                return;
            }
            if (c is Pump)
            {
                Pump pumpComponent = (Pump)c;
                if (pumpComponent.PipesConnected[0] != null)
                {
                    pumpComponent.PipesConnected[0].compFlow = pumpComponent.CurrentFlow;
                    Recalc(pumpComponent.PipesConnected[0]);
                }
            }


        }

    }
}
