using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Simulator
{
    public partial class MainFrom : Form
    {
        Sort s;
        Robot r;
        Thread t;
        Func<Robot.IPointable, Robot.IPointable, bool> sortOrder;   // Currently selected sort order
        Func<Robot.IPointable, Robot.IPointable, bool> ascending;   // Function pointer for ascending sorting
        Func<Robot.IPointable, Robot.IPointable, bool> descending;  // Function pointer for descending sorting

        [Obsolete]
        public MainFrom()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        [Obsolete]
        private void CreateRobot()
        {
            string[] input = txtValues.Text.Split(','); // Get values from user

            r = new Robot(RobotContainer, input)        // Create new robot
            {
                delay = tbSpeed.Maximum - tbSpeed.Value,
                pauseMarker = false
            };

            s = new Sort(r);

            ascending = (Pointable1, Pointable2) => r.Compare(Pointable1.Value, Pointable2.Value) > 0;
            descending = (Pointable1, Pointable2) => r.Compare(Pointable1.Value, Pointable2.Value) < 0;

            sortOrder = ascending;  // defalut sort order is ascending
        }

        [Obsolete]
        private void ThreadAbort()
        {
            if (t != null)
            {
                try
                {
                    t.Abort();
                }
                catch (ThreadStateException)
                {
                    t.Resume();
                }

                t = null;
            }
        }

        private void GenerateRandomValues()
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sb.Append((int)(rand.NextDouble() * 100)).Append(',');
            }

            txtValues.Text = sb.Remove(sb.Length - 1, 1).ToString();
        }

        private void ToolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Team: moshi moshi\nCourse: MT2039\n", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RbtnAscending_CheckedChanged(object sender, EventArgs e)
        {
            sortOrder = (rbtnAscending.Checked == true) ? ascending : descending;
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            r.delay = tbSpeed.Maximum - tbSpeed.Value;
        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateRandomValues();
            CreateRobot();
        }

        [Obsolete]
        private void BtnRandom_Click(object sender, EventArgs e)
        {
            ThreadAbort();

            for (int i = RobotContainer.Controls.Count - 1; i >= 0; i--)
            {
                RobotContainer.Controls.RemoveAt(i);
            }

            RobotContainer.Refresh();
            GenerateRandomValues();
            CreateRobot();
        }

        [Obsolete]
        private void BtnSetValue_Click(object sender, EventArgs e)
        {
            ThreadAbort();

            for (int i = RobotContainer.Controls.Count - 1; i >= 0; i--)
            {
                RobotContainer.Controls.RemoveAt(i);
            }

            RobotContainer.Refresh();
            CreateRobot();
        }

        [Obsolete]
        private void BtnStart_Click(object sender, EventArgs e)
        {
            lblSort.Text = cboxAlgorithm.Text;

            ThreadAbort();
            r.Refresh();

            switch (cboxAlgorithm.Text)
            {
                case "Bubble Sort":
                    t = new Thread(delegate ()
                    {
                        s.BubbleSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Bubble Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                case "Insertion Sort":
                    t = new Thread(delegate ()
                    {
                        s.InsertionSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Insertion Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                case "Merge Sort":
                    t = new Thread(delegate ()
                    {
                        s.MergeSort(sortOrder, r.Elements, 0, r.Elements.Count - 1);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Merge Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                case "Selection Sort":
                    t = new Thread(delegate ()
                    {
                        s.SelectionSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Selection Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                case "Shell Sort":
                    t = new Thread(delegate ()
                    {
                        s.ShellSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Shell Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                case "Quick Sort":
                    t = new Thread(delegate ()
                    {
                        s.QuickSort(sortOrder, r.Elements, 0, r.Elements.Count - 1);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Quick Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    t.Start();
                    break;

                default:
                    MessageBox.Show("Select an algorithm to Start", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        [Obsolete]
        private void BtnPauseResume_Click(object sender, EventArgs e)
        {
            if (t != null && t.ThreadState != ThreadState.Stopped)
            {
                r.pauseMarker = false;

                if (t.ThreadState == ThreadState.Suspended)
                {
                    t.Resume();
                }
                else
                {
                    t.Suspend();
                }
            }
            else
            {
                MessageBox.Show("Play an algorithm to Pause/Resume", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        [Obsolete]
        private void BtnStep_Click(object sender, EventArgs e)
        {
            if (t != null && t.ThreadState != ThreadState.Stopped)
            {
                r.pauseMarker = true;

                if (t.ThreadState == ThreadState.Suspended)
                {
                    t.Resume();
                }
                else
                {
                    t.Suspend();
                }
            }
            else
            {
                MessageBox.Show("Play an algorithm to Step", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        [Obsolete]
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadAbort();
        }
    }
}
