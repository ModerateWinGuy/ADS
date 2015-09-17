using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConcurrentPriorityQueue;

namespace StockSalesSimulator
{
    public partial class Form1 : Form
    {
        private StockSimulator ss;
        public Form1()
        {
            InitializeComponent();
            ss = new StockSimulator();
        }

        private void btnAddBuy_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txtbxBuyOrder.Text);
            txtbxBuyOrder.Text = "";
            ss.BuyQueue.Enqueue(value, value);
            WriteQueueItems();
        }

        private void btnAddSell_Click(object sender, EventArgs e)
        {
            int value = int.Parse(txtbxSellOrder.Text);
            txtbxSellOrder.Text = "";
            ss.SellQueue.Enqueue(value, value);
            WriteQueueItems();
        }

        private void checkForSales()
        {
            var tempBuyQueue = new ConcurrentPriorityQueue<int, int>();

            while (ss.BuyQueue.Count > 0)
            {
                var buyer = ss.BuyQueue.Dequeue();
                var tempSellQueue = new ConcurrentPriorityQueue<int, int>();
                bool buyerFound = false;
                while (ss.SellQueue.Count > 0 && buyerFound == false)
                {
                    var seller = ss.SellQueue.Dequeue();
                    if (seller <= buyer)
                    {
                        // Sold
                        buyerFound = true;
                        break;
                    }
                    else
                    {
                        tempSellQueue.Enqueue(seller, seller);
                    }

                    
                }
                if (!buyerFound)
                {
                    tempBuyQueue.Enqueue(buyer, buyer);
                }
                
                ss.SellQueue = tempSellQueue;
            }
            ss.BuyQueue = tempBuyQueue;
            
        }

        private void WriteQueueItems()
        {
            List<int> toList = ss.SellQueue.ToList();
            lstboxSellOrders.Items.Clear();
            foreach (var queueItem in toList)
            {
                lstboxSellOrders.Items.Add(queueItem);
            }

            toList = ss.BuyQueue.ToList();
            lstbxBuyOrders.Items.Clear();
            foreach (var queueItem in toList)
            {
                lstbxBuyOrders.Items.Add(queueItem);
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            checkForSales();
            WriteQueueItems();
        }
    }

    public class StockSimulator
    {
        public ConcurrentPriorityQueue<int, int> BuyQueue;
        public ConcurrentPriorityQueue<int, int> SellQueue;

        public StockSimulator()
        {
            BuyQueue = new ConcurrentPriorityQueue<int, int>();
            SellQueue = new ConcurrentPriorityQueue<int, int>();
        }
    }
}
