using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Simulator
{
    class Robot
    {
        public List<Element> Elements;      // List of elements to sort
        public List<Temp> Temps;            // List of temporary variables can be created during the sort

        readonly Panel container;

        public int delay = 1000;            // Sleep time
        public bool pauseMarker = false;    // Check if it's in a pause state

        public Robot(Panel container, string[] value)  // Constructor
        {
            int[] ints;

            try
            {
                ints = Array.ConvertAll(value, int.Parse);
            }
            catch (FormatException)
            {
                MessageBox.Show("Input integers separated by commas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ints.Min() < 0 || ints.Max() > 99)
            {
                MessageBox.Show("Sorry, values are restricted to between 0 and 99 inclusive", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Elements = new List<Element>();
            Temps = new List<Temp>();
            this.container = container;

            for (int i = 0; i < ints.Length; i++)
            {
                Element e = new Element(this, i, ints);
                Elements.Add(e);
            }
        }

        public void Refresh() // Refreshes the sorting panel
        {
            foreach (Temp t in Temps)
            {
                container.Controls.Remove(t.Value);
            }

            Temps = new List<Temp>(); ;
            container.Refresh();
        }

        private void PositionInside(Panel p, Label l, int elementCount)   // Set location of first element
        {
            int gap = 10;
            int length = l.Size.Width * elementCount + gap * (elementCount - 1);
            int offset = p.Size.Width / 2 - length / 2;
            int x = (((p.Location.X + offset / 2) < 0) ? 0 : (p.Location.X + offset / 2)) + gap;
            int y = p.Size.Height / 6;
            l.Location = new Point(x, y);
        }

        private void PositionNextTo(Label l1, Label l2, int offset = 1)     // Set location of next elements
        {
            int gap = 10;
            int x = l1.Location.X + l1.Size.Width + offset * gap;
            int y = l1.Location.Y;
            l2.Location = new Point(x, y);
        }

        public interface IPointable
        {
            Robot R { get; set; }
            Label Value { get; set; }
        }

        public class Element : IPointable
        {
            public Robot R { get; set; }
            public Label Value { get; set; }

            public Element(Robot r, int i, int[] arr)
            {
                R = r;

                Value = new Label
                {
                    BackColor = Color.FromArgb(116, 185, 255),
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Padding = new Padding(4),
                    Size = new Size(50, 40 + 3 * arr[i]),
                    Text = arr[i].ToString(),
                    TextAlign = ContentAlignment.TopCenter,
                };

                if (r.Elements.Count == 0)
                {
                    r.PositionInside(r.container, Value, arr.Length);
                }
                else
                {
                    r.PositionNextTo(r.Elements[r.Elements.Count - 1].Value, Value);
                }

                r.container.Controls.Add(Value);
            }
        }

        public class Temp : IPointable
        {
            public Robot R { get; set; }
            public Label Value { get; set; }

            public Temp(Robot r, string strkey, object objvalue)
            {
                R = r;

                Value = new Label()
                {
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Padding = new Padding(4),
                    Size = new Size(50, 50),
                    TextAlign = ContentAlignment.TopCenter,
                };

                if (r.Temps.Count == 0)
                {
                    Label seperator = new Label
                    {
                        Font = new Font("Arial", 12, FontStyle.Regular),
                        Padding = new Padding(4),
                        Size = new Size(50, 50),
                        Text = "|",
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    r.PositionNextTo(r.Elements[r.Elements.Count - 1].Value, seperator);

                    r.PositionNextTo(seperator, Value);

                    r.container.Invoke(new Action(delegate ()
                    {
                        r.container.Controls.Add(seperator);
                        r.container.Controls.Add(Value);
                    }));
                }
                else
                {
                    r.PositionNextTo(r.Temps[r.Temps.Count - 1].Value, Value);

                    r.container.Invoke(new Action(delegate ()
                    {
                        r.container.Controls.Add(Value);
                    }));
                }
            }

            public void Remove()
            {
                R.container.Invoke(new Action(delegate ()
                {
                    R.container.Controls.Remove(Value);
                    R.container.Controls.RemoveAt(R.container.Controls.Count - 1);
                }));
            }
        }

        public void RemoveTemp(Temp t)
        {
            container.Invoke(new Action(delegate ()
            {
                container.Controls.Remove(t.Value);
            }));

            Temps.Remove(t);
        }

        public List<Temp> CreateTempArray(int count)
        {
            List<Temp> temp = new List<Temp>();

            for (int i = 0; i < count; i++)
            {
                Temp t = new Temp(this, i.ToString(), "temp");
                temp.Add(t);
            }

            return temp;
        }

        [Obsolete]
        private void Suspend(int delay) // Suspends the animation during 'pausing' and 'steping'
        {
            if (pauseMarker == true)
            {
                Thread.CurrentThread.Suspend();
            }
            else
            {
                Thread.Sleep(delay);
            }
        }

        [Obsolete]
        public void ChangeBackColor(Label _label, Color _color, bool _delay = false)
        {
            _label.BackColor = _color;

            if (_delay)
            {
                Suspend(delay);
            }
        }

        [Obsolete]
        public void RefreshBackColor()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                ChangeBackColor(Elements[i].Value, Color.FromArgb(116, 185, 255));
            }
        }

        [Obsolete]
        public int Compare(Label l1, Label l2)
        {
            Graphics g = container.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);

            int x1 = l1.Location.X + l1.Size.Width / 2;
            int y1 = l1.Location.Y - 15;
            int x2 = l2.Location.X + l2.Size.Width / 2;
            int y2 = l2.Location.Y - 15;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x1, y1 - 15);
            Point point4 = new Point(x2, y2 - 15);

            g.DrawLine(p, point1, point3);
            g.DrawLine(p, point2, point4);
            g.DrawLine(p, point3, point4);

            int val1 = int.Parse(l1.Text);
            int val2 = int.Parse(l2.Text);

            string s = (val2 < val1) ? l2.Text + " is smaller" : ((val2 > val1) ? l2.Text + " is greater" : "equal");
            int lengthLabel = (s.Length == 13) ? 100 : ((s.Length == 12) ? 92 : 48);
            g.DrawString(s, new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.Black), new Point((x1 + x2 - lengthLabel) / 2, y1 - 45));

            Suspend(delay);

            g.Clear(Color.White);

            return int.Parse(l1.Text).CompareTo(int.Parse(l2.Text));
        }

        [Obsolete]
        public void Swap(Label l1, Label l2)
        {
            Graphics g = container.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);

            int x1 = l1.Location.X + l1.Size.Width / 2;
            int y1 = l1.Location.Y - 15;
            int x2 = l2.Location.X + l2.Size.Width / 2;
            int y2 = l2.Location.Y - 15;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x1, y1 - 15);
            Point point4 = new Point(x2, y2 - 15);

            g.DrawLine(p, point1, point3);
            g.DrawLine(p, point2, point4);
            g.DrawLine(p, point3, point4);

            Point point5 = new Point(x1 - 5, y1 - 5);
            Point point6 = new Point(x1 + 5, y1 - 5);
            Point point7 = new Point(x2 - 5, y2 - 5);
            Point point8 = new Point(x2 + 5, y2 - 5);

            g.DrawLine(p, point1, point5);
            g.DrawLine(p, point1, point6);
            g.DrawLine(p, point2, point7);
            g.DrawLine(p, point2, point8);

            g.DrawString("swap", new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.Black), new Point((x1 + x2 - 44) / 2, y1 - 45));

            Suspend(delay);

            Color ctemp = l1.BackColor;
            Size stemp = l1.Size;
            string ttemp = l1.Text;

            container.Invoke(new Action(delegate ()
            {
                l1.BackColor = l2.BackColor;
                l2.BackColor = ctemp;

                l1.Size = l2.Size;
                l2.Size = stemp;

                l1.Text = l2.Text;
                l2.Text = ttemp;

                container.Refresh();
            }));

            Suspend(delay);
        }

        [Obsolete]
        public void Move(Label lf, Label lt)
        {
            Graphics g = container.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);

            int x1 = lf.Location.X + lf.Size.Width / 2;
            int y1 = lf.Location.Y - 15;
            int x2 = lt.Location.X + lt.Size.Width / 2;
            int y2 = lt.Location.Y - 15;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x1, y1 - 15);
            Point point4 = new Point(x2, y2 - 15);

            g.DrawLine(p, point1, point3);
            g.DrawLine(p, point2, point4);
            g.DrawLine(p, point3, point4);

            Point point5 = new Point(x2 - 5, y2 - 5);
            Point point6 = new Point(x2 + 5, y2 - 5);

            g.DrawLine(p, point2, point5);
            g.DrawLine(p, point2, point6);

            g.DrawString("move", new Font("Arial", 12, FontStyle.Regular), new SolidBrush(Color.Black), new Point((x1 + x2 - 44) / 2, y1 - 45));

            Suspend(delay);

            Color ctemp = lf.BackColor;
            string ttemp = lf.Text;

            container.Invoke(new Action(delegate ()
            {
                lt.Size = lf.Size;

                lf.BackColor = lt.BackColor;
                lt.BackColor = ctemp;

                lf.Text = lt.Text;
                lt.Text = ttemp;

                container.Refresh();
            }));
        }
    }
}
