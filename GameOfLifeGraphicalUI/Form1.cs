using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace GameOfLifeGraphicalUI
{
    public partial class Form1 : Form
    {
        Cell[,] Playground = new Cell[20, 20];
        Random rnd = new Random();
        Thread GameThread = null;
        private bool stopGameThread = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Cell pb = new Cell(false);
                    pb.Location = new Point(x * 20, y * 20);
                    pb.Size = new Size(20, 20);
                    pb.BackColor = Color.Gray;
                    pb.Click += pbClick;
                    Playground[x, y] = pb;
                    PlayGroundPanel.Controls.Add(pb);
                }
            }

            PlayGroundPanel.SendToBack();
        }

        private void pbClick(object sender, EventArgs e)
        {
            Cell thiscell = sender as Cell;
            thiscell.Lives = !thiscell.Lives;
            thiscell.BackColor = (thiscell.Lives) ? Color.Green : Color.Gray;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int anz = 0;
            if(int.TryParse(Anzahl.Text, out anz))
            {
                for (int i = 0; i < anz;)
                {
                    Cell c = Playground[rnd.Next(0, 20), rnd.Next(0, 20)];
                    if (c.Lives == false)
                    {
                        c.Lives = true;
                        i++;
                    }
                }
            }

            stopGameThread = false;
            GameThread = new Thread(newThread);
            GameThread.Start();

            Button thisbtn = sender as Button;
            thisbtn.Text = "Stop";
            thisbtn.Click -= Start_Click;
            thisbtn.Click += Stop_Click;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            stopGameThread = true;

            Button thisbtn = sender as Button;
            thisbtn.Text = "Start";
            thisbtn.Click += Start_Click;
            thisbtn.Click -= Stop_Click;
        }

        private void newThread()
        {
            while (!stopGameThread)
            {
                List<Cell> cells = Playground.Cast<Cell>().ToList();
                cells.ForEach(item => item.BackColor = (item.Lives) ? Color.Green : Color.Gray);

                Thread.Sleep((int)Stepsize.Value);

                calcnextturn();
            }
        }

        public bool calcnextturn()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int x = 0; x < Playground.GetLength(0); x++)
            {
                for (int y = 0; y < Playground.GetLength(1); y++)
                {
                    int livingneighbours = entitiesnear(x, y, true);
                    Cell thiscell = Playground[x, y];
                    if (thiscell.Lives)
                    {
                        switch (livingneighbours)
                        {
                            case 0:
                            case 1:
                                thiscell.livesnextround = false;
                                break;
                            case 2:
                            case 3:
                                thiscell.livesnextround = true;
                                break;
                            default:
                                thiscell.livesnextround = false;
                                break;
                        }
                    }
                    else
                    {
                        if (livingneighbours == 3)
                        {
                            thiscell.livesnextround = true;
                        }
                    }
                }
            }

            bool returnme = startnextturn();
            sw.Stop();
            label2.Invoke(new Action(() => label2.Text = "Milliseconds needed for calculation: " + sw.ElapsedMilliseconds));
            return returnme;
        }

        public bool startnextturn()
        {
            for (int x = 0; x < Playground.GetLength(0); x++)
            {
                for (int y = 0; y < Playground.GetLength(1); y++)
                {
                    if (Playground[x, y].livesnextround != null)
                    {
                        Playground[x, y].Lives = (bool)Playground[x, y].livesnextround;
                    }
                    Playground[x, y].livesnextround = null;
                }
            }

            return true;
        }

        /// <summary>
        /// this method returns the number of entities that are alive or dead near the entity specified
        /// </summary>
        /// <param name="x">X Coordinate of the entity</param>
        /// <param name="y">Y Coordinate of the entity</param>
        /// <param name="living">chekc for dead(false) or living(true) neighbours</param>
        /// <returns>number of entities that are dead or live</returns>
        private int entitiesnear(int x, int y, bool living)
        {
            int count = 0;

            List<Tuple<int, int>> possibilities = new List<Tuple<int, int>> { new Tuple<int, int>(-1, -1), new Tuple<int, int>(0, -1), new Tuple<int, int>(1, -1), new Tuple<int, int>(-1, 0), new Tuple<int, int>(1, 0), new Tuple<int, int>(-1, 1), new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 1) };   //getting all possible neighbourpoints

            foreach (Tuple<int, int> item in possibilities)     //iterating over all these points
            {
                if ((x + item.Item1 > 0 && x + item.Item1 < Playground.GetLength(1) && y + item.Item2 > 0 && y + item.Item2 < Playground.GetLength(0)) && Playground[x + item.Item1, y + item.Item2].Lives == living) //neighbour is living
                {
                    count++;
                }
            }

            return count;           //returning the number of living neighbours
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopGameThread = true;
        }
    }
}
