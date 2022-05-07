using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator
{
    class Sort
    {
        readonly Robot r;

        public Sort(Robot r) => this.r = r;

        readonly Color Blue = Color.FromArgb(116, 185, 255);
        readonly Color Green = Color.FromArgb(0, 184, 148);
        readonly Color Purple = Color.FromArgb(162, 155, 254);
        readonly Color Red = Color.FromArgb(255, 118, 117);
        readonly Color Yellow = Color.FromArgb(253, 203, 110);

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
        }

        public void MergeSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {

        }

        [Obsolete]
        public void QuickSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {
            if (lo <= hi)
            {
                int pi = Partition(sortOrder, A, lo, hi);

                QuickSort(sortOrder, A, lo, pi - 1);
                QuickSort(sortOrder, A, pi + 1, hi);
            }
        }

        [Obsolete]
        private int Partition(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {
            int storeIndex = lo + 1;

            if (lo != hi)
            {
                Robot.Element pivot = A[lo];
                r.ChangeBackColor(pivot.Value, Red, true);

                for (int i = lo + 1; i <= hi; i++)
                {
                    r.ChangeBackColor(A[i].Value, Purple);

                    if (sortOrder.Invoke(pivot, A[i]))
                    {
                        if (i != storeIndex) r.Swap(A[i].Value, A[storeIndex].Value);
                        r.ChangeBackColor(A[storeIndex].Value, Green);
                        storeIndex++;
                    }
                }

                if (storeIndex != lo + 1) r.Swap(A[storeIndex - 1].Value, pivot.Value);

                for (int i = lo; i <= hi; i++) r.ChangeBackColor(A[i].Value, Blue);
            }

            r.ChangeBackColor(A[storeIndex - 1].Value, Yellow, true);

            return storeIndex - 1;
        }
    }
}
