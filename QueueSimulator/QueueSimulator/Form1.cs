using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QueueSimulator
{
    public partial class Form1 : Form
    {
        private List<GroupBox> queueGraphicBoxs;
        private List<Queue<QueueingPerson>> queues;
        private int remainingShoppers;
        private const int QUEUESIZE = 10;
        private int time;
        private int stageingQueueSize;
        Random rand = new Random();
        private Bitmap bm;
        private int processedCounter;
        public Form1()
        {
            InitializeComponent();
            time = 0;
            processedCounter = 0;
            stageingQueueSize = 0;
            queueGraphicBoxs = new List<GroupBox>(10);
            queueGraphicBoxs.Add(grpbxQueue1);
            queueGraphicBoxs.Add(grpbxQueue2);
            queueGraphicBoxs.Add(grpbxQueue3);
            queueGraphicBoxs.Add(grpbxQueue4);
            queueGraphicBoxs.Add(grpbxQueue5);
            queueGraphicBoxs.Add(grpbxQueue6);
            queueGraphicBoxs.Add(grpbxQueue7);
            queueGraphicBoxs.Add(grpbxQueue8);
            queueGraphicBoxs.Add(grpbxQueue9);
            queueGraphicBoxs.Add(grpbxQueue10);

            queues = new List<Queue<QueueingPerson>>(10);
            for (int i = 0; i < queues.Capacity; i++)
            {
                queues.Add(new Queue<QueueingPerson>(QUEUESIZE));
            }
            

            remainingShoppers = 1000;
        }

        private void drawToBox(int percentFull, int boxNumber)
        {
            
            Rectangle rectangle = queueGraphicBoxs[boxNumber].DisplayRectangle;
            rectangle.Width -= 5;
            if (bm == null)
                bm = new Bitmap(rectangle.Width,rectangle.Height);
            Graphics bufferGraphics = Graphics.FromImage(bm);
            rectangle.Height = (rectangle.Height/100)*percentFull;
            Graphics boxGraphics = queueGraphicBoxs[boxNumber].CreateGraphics();
            bufferGraphics.Clear(queueGraphicBoxs[boxNumber].BackColor);
            bufferGraphics.FillRectangle(Brushes.Brown, rectangle);
            boxGraphics.DrawImage(bm,3,15);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time > trackBar1.Value)
            {
                time = 0;

                switch (getCurrentStrat())
                {
                    case "Random":
                        addPersonToRandomQueue();
                        break;
                    case "Smallest Queue":
                        addPersonToSmallestQueue();
                        break;
                    case "Staging Queue":
                        addPersonToStagingQue();
                        break;

                }
            }
            dealWithStagingQueue();
            foreach (Queue<QueueingPerson> queue in queues)
            {
                if (queue.Size > 0)
                {
                    if (queue.Front().decCheckOutTime())
                    {
                        queue.Deque(); // Remove anyone from the queue who has finished checking out
                    }
                }
            }
            drawQueues();
            label1.Text = time.ToString();
            label3.Text = remainingShoppers.ToString();
            lblStagingQueue.Text = "StagingQue : " + stageingQueueSize;
        }

        private void dealWithStagingQueue()
        {
            while ((getEmptyQueueIndex() != -1) && (stageingQueueSize > 0))
            {
                queues[getEmptyQueueIndex()].Enqueue(new QueueingPerson(rand.Next(60 * Int32.Parse(txtMinCheckout.Text), 60 * Int32.Parse(txtMaxCheckout.Text))));
                stageingQueueSize--;
            }
        }

        private void addPersonToStagingQue()
        {
            stageingQueueSize++;
            remainingShoppers--;
        }

        private void addPersonToRandomQueue()
        {
            int quenum;
            do
            {
                quenum = rand.Next(queues.Count);
            } while (queues[quenum].IsFull());
            queues[quenum].Enqueue(new QueueingPerson(rand.Next(60 * 1, 60 * 10)));
            remainingShoppers--;
        }

        private void addPersonToSmallestQueue()
        {
            int smallest = 0;
            for (int i = 0; i < queues.Count; i++)
            {
                if (queues[i].Size < queues[smallest].Size)
                {
                    smallest = i;
                }
            }
            queues[smallest].Enqueue(new QueueingPerson(rand.Next(60*3,60*10)));
            remainingShoppers--;
        }

        private void drawQueues()
        {
            for (int i = 0; i < queues.Capacity; i++)
            {
                drawToBox(queues[i].Size*10, i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            button1.Text = timer1.Enabled ? "Pause Sim" : "Start Sim";
            txtMinCheckout.Enabled = !timer1.Enabled;
            txtMaxCheckout.Enabled = !timer1.Enabled;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Arrival freq every " + trackBar1.Value +" seconds";
        }

        private string getCurrentStrat()
        {
            var checkedButton = grpbxStrat.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            return checkedButton.Text;
        }

        /// <summary>
        /// Returns the index of the first empty queue, or -1 if they all have someone in them.
        /// </summary>
        /// <returns></returns>
        private int getEmptyQueueIndex()
        {
            int index = -1;
            for (int i = 0; i < queues.Count; i++)
            {
                if (queues[i].Size == 0)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
