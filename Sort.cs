using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Simulator
{
    class Sort
    {
        readonly Robot r;

        public Sort(Robot r)
        {
            this.r = r;
        }

        readonly Color Red = Color.FromArgb(237, 76, 103);
        readonly Color Blue = Color.FromArgb(116, 185, 255);
        readonly Color Green = Color.FromArgb(0, 184, 148);
        readonly Color Yellow = Color.FromArgb(255, 211, 42);

        // This is a implementation that explains how a sorting algorithm works.
        // It is not the optimized algorithm implementation.

        [Obsolete]
        public void BubbleSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder)
        {
            int i, j;
            int size = r.Elements.Count;

            for (i = 1; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[0].Value, Green);

                for (j = 0; j < size - i; j++)
                {
                    r.ChangeBackColor(r.Elements[j + 1].Value, Green);

                    if (sortOrder.Invoke(r.Elements[j], r.Elements[j + 1]))
                    {
                        r.Swap(r.Elements[j].Value, r.Elements[j + 1].Value);
                    }

                    r.ChangeBackColor(r.Elements[j].Value, Blue);
                }

                r.ChangeBackColor(r.Elements[j].Value, Yellow, true);
            }

            for (i = 0; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[i].Value, Blue);
            }

            MessageBox.Show("Sorted!", "Bubble Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [Obsolete]
        public void InsertionSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder)
        {
            int i, j;
            int size = r.Elements.Count;
            Robot.Temp temp = new Robot.Temp(r, null, null);

            r.ChangeBackColor(r.Elements[0].Value, Yellow, true);

            for (i = 1; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[i].Value, Red);
                r.Move(r.Elements[i].Value, temp.Value);

                j = i - 1;

                while (j >= 0)
                {
                    r.ChangeBackColor(r.Elements[j].Value, Green);

                    if (sortOrder.Invoke(r.Elements[j], temp))
                    {
                        r.Move(r.Elements[j].Value, r.Elements[j + 1].Value, false);

                        if (j > 0)
                        {
                            r.ChangeBackColor(r.Elements[j + 1].Value, Yellow);
                        }

                        j -= 1;
                    }
                    else break;
                }

                r.Move(temp.Value, r.Elements[j + 1].Value, false);

                if (j + 1 == 0)
                {
                    r.ChangeBackColor(r.Elements[0].Value, Yellow);
                    r.ChangeBackColor(r.Elements[1].Value, Yellow, true);
                }
                else
                {
                    r.ChangeBackColor(r.Elements[j].Value, Yellow);
                    r.ChangeBackColor(r.Elements[j + 1].Value, Yellow, true);
                }
            }

            temp.Remove();

            for (i = 0; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[i].Value, Blue);
            }

            MessageBox.Show("Sorted!", "Insertion Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [Obsolete]
        public void SelectionSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder)
        {
            int i, j;
            int size = r.Elements.Count;

            for (i = 0; i < size - 1; i++)
            {
                int min = i;

                r.ChangeBackColor(r.Elements[min].Value, Red, true);

                for (j = i + 1; j < size; j++)
                {
                    r.ChangeBackColor(r.Elements[j].Value, Green);

                    if (sortOrder.Invoke(r.Elements[min], r.Elements[j]))
                    {
                        r.ChangeBackColor(r.Elements[min].Value, Blue);
                        r.ChangeBackColor(r.Elements[j].Value, Red, true);

                        min = j;
                    }
                    else
                    {
                        r.ChangeBackColor(r.Elements[j].Value, Blue);
                    }
                }

                if (min != i)
                {
                    r.ChangeBackColor(r.Elements[i].Value, Red);
                    r.Swap(r.Elements[i].Value, r.Elements[min].Value);
                    r.ChangeBackColor(r.Elements[min].Value, Blue);
                }

                r.ChangeBackColor(r.Elements[i].Value, Yellow, true);
            }

            for (i = 0; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[i].Value, Blue);
            }

            MessageBox.Show("Sorted!", "Selection Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MergeSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {

        }

        [Obsolete]
        public void QuickSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {
            if (lo >= hi) return;

            int p = Partition(sortOrder, A, lo, hi);

            QuickSort(sortOrder, A, lo, p);
            QuickSort(sortOrder, A, p + 1, hi);
        }

        [Obsolete]
        private int Partition(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {
            // Use Hoare Partition
            int pivot = (hi + lo) / 2;
            int i = lo - 1;
            int j = hi + 1;

            while (true)
            {
                do { i++; } while (sortOrder(A[pivot], A[i]));
                do { j--; } while (sortOrder(A[j], A[pivot]));
                if (i >= j) return j;
                r.Swap(A[i].Value, A[j].Value);
            }
        }
    }
}
