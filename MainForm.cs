using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Simulator
{
    public partial class MainForm : Form
    {
        Sort s;
        Robot r;
        Thread _thread;

        Func<Robot.IPointable, Robot.IPointable, bool> sortOrder;   // Currently selected sort order
        Func<Robot.IPointable, Robot.IPointable, bool> ascending;   // Function pointer for ascending sorting
        Func<Robot.IPointable, Robot.IPointable, bool> descending;  // Function pointer for descending sorting
        
        bool isRunning;

        [Obsolete]
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        [Obsolete]
        private void CreateRobot()
        {
            string[] input = txtValue.Text.Split('\u002C'); // Get values from user

            r = new Robot(RobotContainer, input)        // Create new robot
            {
                delay = tbSpeed.Maximum - tbSpeed.Value,
                pauseMarker = false
            };

            s = new Sort(r);

            ascending = (Pointable1, Pointable2) => r.Compare(Pointable1.Value, Pointable2.Value) > 0;
            descending = (Pointable1, Pointable2) => r.Compare(Pointable1.Value, Pointable2.Value) < 0;

            sortOrder = ascending;  // default sort order is ascending
            isRunning = false;
        }

        [Obsolete]
        private void ThreadAbort()
        {
            if (_thread != null)
            {
                try
                {
                    _thread.Abort();
                }
                catch (ThreadStateException)
                {
                    _thread.Resume();
                }

                _thread = null;
            }
        }

        private void GenerateRandomValue()
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sb.Append(rnd.Next(99)).Append('\u002C');
            }

            txtValue.Text = sb.Remove(sb.Length - 1, 1).ToString();
        }

        private void LblAbout_Click(object sender, EventArgs e)
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
        private void BtnRandom_Click(object sender, EventArgs e)
        {
            ThreadAbort();

            RobotContainer.Controls.Clear();
            RobotContainer.Refresh();

            GenerateRandomValue();
            CreateRobot();
        }

        [Obsolete]
        private void BtnSetValue_Click(object sender, EventArgs e)
        {
            ThreadAbort();

            RobotContainer.Controls.Clear();
            RobotContainer.Refresh();

            CreateRobot();
        }

        [Obsolete]
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            isRunning = true;
            lblSort.Text = cboxAlgorithm.Text;

            ThreadAbort();
            r.Refresh();

            switch (cboxAlgorithm.Text)
            {
                case "Bubble Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.BubbleSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Bubble Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    _thread.Start();
                    break;

                case "Insertion Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.InsertionSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Insertion Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    _thread.Start();
                    break;

                case "Merge Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.CreatMerge(r.Elements.Count);
                        s.MergeSort(sortOrder, r.Elements, 0, r.Elements.Count - 1);
                        s.ClearMerge();
                        r.RefreshBackColor();
                    });
                    _thread.Start();
                    break;

                case "Selection Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.SelectionSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Selection Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    _thread.Start();
                    break;

                case "Shell Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.ShellSort(sortOrder);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Shell Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    _thread.Start();
                    break;

                case "Quick Sort":
                    _thread = new Thread(delegate ()
                    {
                        s.QuickSort(sortOrder, r.Elements, 0, r.Elements.Count - 1);
                        r.RefreshBackColor();
                        MessageBox.Show("Sorted!", "Quick Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                    _thread.Start();
                    break;

                default:
                    MessageBox.Show("Select an algorithm to Start", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    isRunning = false;
                    break;
            }
        }

        [Obsolete]
        private void BtnPauseResume_Click(object sender, EventArgs e)
        {
            if (_thread != null && _thread.ThreadState != ThreadState.Stopped)
            {
                r.pauseMarker = false;

                if (_thread.ThreadState == ThreadState.Suspended)
                {
                    _thread.Resume();
                }
                else
                {
                    _thread.Suspend();
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
            if (_thread != null && _thread.ThreadState != ThreadState.Stopped)
            {
                r.pauseMarker = true;

                if (_thread.ThreadState == ThreadState.Suspended)
                {
                    _thread.Resume();
                }
                else
                {
                    _thread.Suspend();
                }
            }
            else
            {
                MessageBox.Show("Play an algorithm to Step", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        [Obsolete]
        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateRandomValue();
            CreateRobot();
        }

        [Obsolete]
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ThreadAbort();
        }
    }
}
