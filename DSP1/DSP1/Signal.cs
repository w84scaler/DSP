using System;
using System.Collections.Generic;

using OxyPlot;

namespace DSP1
{
    class Signal
    {
        public List<DataPoint> Points { get; set; }

        public Signal(int N, double A, double f, double fi)
        {
            Points = new List<DataPoint>();
            for (int n = 0; n < N; n++)
            {
                Points.Add(new DataPoint(n, A * Math.Sin(2 * Math.PI * f * n / N + fi)));
            }
        }

        public Signal(int N, double A, double[] fs, double[] fis)
        {
            Points = new List<DataPoint>();
            for (int n = 0; n < N; n++)
            {
                int length = fs.Length;
                double F = 0;
                for (int i = 0; i < length; i++)
                {
                    F += A * Math.Sin(2 * Math.PI * fs[i] * n / N + fis[i]);
                }
                Points.Add(new DataPoint(n, F));
            }
        }

        public Signal(int N, double A, double f, double fi, double rate, bool asc)
        {
            double LinearModificate(double parametr, int n)
            {
                int sign = asc ? 1 : -1;
                return parametr + sign * rate * parametr * n / N;
            }

            Points = new List<DataPoint>();
            for (int n = 0; n < N; n++)
            {
                Points.Add(new DataPoint(n, LinearModificate(A, n) * Math.Sin(2 * Math.PI * LinearModificate(f, n) * n / N + LinearModificate(fi, n))));
            } 
        }
    }
}
