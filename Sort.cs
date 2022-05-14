using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator
{
    class Sort
    {
        readonly Robot r;

        public Sort(Robot r) => this.r = r;
        public List<Robot.Temp> SortMerge;
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
            int size = r.Elements.Count;
            Robot.Temp temp = new Robot.Temp(r, null, null);

            r.ChangeBackColor(r.Elements[0].Value, Yellow, true);

            for (int i = 1; i < size; i++)
            {
                r.ChangeBackColor(r.Elements[i].Value, Red);
                r.Move(r.Elements[i].Value, temp.Value);

                int j = i - 1;

                while (j >= 0)
                {
                    r.ChangeBackColor(r.Elements[j].Value, Green);

                    if (sortOrder.Invoke(r.Elements[j], temp))
                    {
                        r.Move(r.Elements[j].Value, r.Elements[j + 1].Value);

                        if (j > 0) r.ChangeBackColor(r.Elements[j + 1].Value, Yellow);

                        j -= 1;
                    }
                    else break;
                }

                r.Move(temp.Value, r.Elements[j + 1].Value);

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
        public void ShellSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder)
        {
            int size = r.Elements.Count;

            if (size == 1) InsertionSort(sortOrder);

            for (int k = size / 2; k > 0; k /= 2)
            {
                for (int segment = 0; segment < k; segment++)
                {
                    for (int i = segment; i < size; i += k) r.ChangeBackColor(r.Elements[i].Value, Purple, i + k >= size);

                    if (k == 1)
                    {
                        InsertionSort(sortOrder);
                    }
                    else
                    {
                        SortSegment(sortOrder, segment, k);
                        for (int i = segment; i < size; i += k) r.ChangeBackColor(r.Elements[i].Value, Blue);
                    }
                }
            }
        }

        [Obsolete]
        private void SortSegment(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, int segment, int k)
        {
            int size = r.Elements.Count;
            Robot.Temp temp = new Robot.Temp(r, null, null);

            for (int curr = segment + k; curr < size; curr += k)
            {
                r.ChangeBackColor(r.Elements[curr].Value, Red);
                r.Move(r.Elements[curr].Value, temp.Value);

                int step = curr - k;

                while (step >= 0)
                {
                    if (sortOrder.Invoke(r.Elements[step], temp))
                    {
                        r.Move(r.Elements[step].Value, r.Elements[step + k].Value);
                        step -= k;
                    }
                    else break;
                }

                r.Move(temp.Value, r.Elements[step + k].Value);
                r.ChangeBackColor(r.Elements[step + k].Value, Purple, true);
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

        [Obsolete]
        public void MergeSort(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int hi)
        {
            if (lo < hi)
            {
                int m = (lo + hi) / 2;

                MergeSort(sortOrder, A, lo, m);
                MergeSort(sortOrder, A, m + 1, hi);

                Merge(sortOrder, A, lo, m, hi);
            }
        }
        [Obsolete]
        public void CreatMerge(int count)
        {
            SortMerge = r.Temps;
            int X_Red, X_Green;
            int j = 0;

            for (int i = 0; i < count; i++)
            {
                SortMerge.Add(new Robot.Temp(r, null, null));
            }

            for (int i = 0; i < r.Elements.Count; i++, j++)
            {
                X_Red = 255 - 20 * j;
                X_Green = 100 + 10 * j;
                if (X_Red < 0 || X_Green > 255)
                {
                    j = 0;
                    X_Red = 255;
                    X_Green = 100;
                }
                r.ChangeBackColor(r.Elements[i].Value, Color.FromArgb(X_Red, X_Green, 40));
            }
        }
        [Obsolete]
        public void ClearMerge()
        {
            for (int i = 1; i < SortMerge.Count; i++)
            {
                SortMerge[i].RemoveMerge();
            }
            SortMerge[0].Remove();
            SortMerge.Clear();
        }
        [Obsolete]
        private void Merge(Func<Robot.IPointable, Robot.IPointable, bool> sortOrder, List<Robot.Element> A, int lo, int m, int hi)
        {
            int i = lo, j = m + 1, k = 0;

            Color tmp = r.Elements[lo].Value.BackColor;
            while (i <= m && j <= hi)
            {
                if (sortOrder.Invoke(A[i], A[j]))
                {
                    r.ChangeBackColor(A[j].Value, Red);
                    r.Move(r.Elements[j].Value, SortMerge[k].Value);
                    ++j;
                }
                else
                {
                    r.ChangeBackColor(r.Elements[i].Value, Red);
                    r.Move(r.Elements[i].Value, SortMerge[k].Value);
                    ++i;
                }
                ++k;
            }
            while (i <= m)
            {
                r.ChangeBackColor(r.Elements[i].Value, Red);
                r.Move(r.Elements[i].Value, SortMerge[k].Value);
                ++i;
                ++k;
            }

            while (j <= hi)
            {
                r.ChangeBackColor(r.Elements[j].Value, Red);
                r.Move(r.Elements[j].Value, SortMerge[k].Value);
                ++j;
                ++k;
            }
            while (k > 0)
            {
                --k;
                r.Move(SortMerge[k].Value, r.Elements[lo + k].Value);
                r.ChangeBackColor(r.Elements[lo + k].Value, tmp);
            }
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
                    r.ChangeBackColor(A[i].Value, Green);

                    if (sortOrder.Invoke(pivot, A[i]))
                    {
                        if (i != storeIndex) r.Swap(A[i].Value, A[storeIndex].Value);
                        r.ChangeBackColor(A[storeIndex].Value, Purple);
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
