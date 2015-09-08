using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_Tree
{
    public partial class Form1 : Form
    {
        public static Node<BoardState> boardTree;
        private static Image cross;
        private static Image nought;
        private static List<PictureBox> pictureBoxs; 
        public Form1()
        {
            InitializeComponent();
            pictureBoxs = this.Controls.OfType<PictureBox>().ToList();
            cross = Image.FromFile("cross.png");
            nought = Image.FromFile("nought.png");
            boardTree = new Node<BoardState>(BoardState.getEmptyBord());
            populateNode(boardTree);
            CalculateBoardScore(boardTree);
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void cycleBoxes(Node<BoardState> node)
        {
            setImageBoxes(node.Data);
            Application.DoEvents();
            Thread.Sleep(50);

            foreach (var childNode in node.ChildrenList)
            {
                cycleBoxes(childNode);
            }
        }

        public void setImageBoxes(BoardState bState)
        {
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch(bState.currentBoard[i, j])
                    {
                        case eSquare.Cross:
                            pictureBoxs[(i*3) + j].Image = cross;
                            break;
                        case eSquare.Naught:
                            pictureBoxs[(i * 3) + j].Image = nought;
                            break;
                        case eSquare.Empty:
                            pictureBoxs[(i * 3) + j].Image = null;
                            break;
                    }
                        
                    
                }
            }
        }

        private void CalculateBoardScore(Node<BoardState> node )
        {
            node.Data.calculateBoardScore();
            foreach (var childNode in node.ChildrenList)
            {
                CalculateBoardScore(childNode);
            }
        }

        private void populateNode(Node<BoardState> currentNode)
        {
            // Takes the passed in node, and then gets every possible move from it.
            // Converts each of these moves into a new node and sets them to be it's children.
            // Then does the same for every child of the node
            List<Node<BoardState>> nextNodes = new List<Node<BoardState>>(9);
            
            foreach (var nextNode in currentNode.Data.getAllNextMoves())
            {
                Node<BoardState> newNode = new Node<BoardState>(nextNode);
                nextNodes.Add(newNode);
            }
            currentNode.ChildrenList = nextNodes;
            foreach (var node in currentNode.ChildrenList)
            {
                populateNode(node);
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            cycleBoxes(boardTree);
        }
    }
}
