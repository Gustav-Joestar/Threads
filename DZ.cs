using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using Writer;

public class DZ
{
    private static double f1(double x)
    {
        return (double)Math.Exp(x * Math.Cos(Math.PI / 4)) * Math.Cos(x * Math.Sin(Math.PI / 4));
    }

    private static double f1(double x, int n)
    {
        int Fact(int m)
        {
            if (m == 1)
                return 1;
            return m * Fact(m - 1);
        }
        return (double)Math.Cos(n * Math.PI)*Math.Pow(x, n) / Fact(n);
    }

    //private void button1_Click(object sender, EventArgs e)
    //{
    static public void Main()
    {
        Writers fileManager = new Writers("E:\\Informatic\\Sem 3\\YaP\\HomeWork\\DZ3\\DZ3.txt");
        fileManager.writeLineInFile("".PadRight(23) + "threads".PadRight(23) + "function".PadRight(23));
        const int n = 25;
        double gr1 = 0.1;
        Task[] th1 = new Task[n];
        double[] res1 = new double[n];
        while (gr1 <= 1)
        {
            for (int i = 0; i<n; i++)
            {
                int a = i;
                th1[a] = new Task(() =>
                {
                    res1[a] = f1(gr1, a+1);
                });

                th1[a].Start();
            }

            for (int j = 0; j<n; j++)
            {
                th1[j].Wait();
            }

            fileManager.writeLineInFile(gr1.ToString().PadRight(23) + res1.Sum().ToString().PadRight(23) + f1(gr1).ToString().PadRight(23), true);

            gr1 += 0.0375;
        }
        //    Parallel.Invoke(() =>
        //    {
        //        double res1 = 0;
        //        while(gr1 <= 1)
        //        {
        //            for(int i = 0; i<n; i++)
        //            {
        //                res1 = f2(gr1, i) + res1;
        //            }
        //            gr1 = gr1 + 0.1;
        //        }
        //        richTextBox1.Text = res1 + "\n";
        //    },
        //    () =>
        //    {
        //        double res2 = 0;
        //        while(gr1 <=1)
        //        {
        //            res2 = f1(gr1) + res2;
        //            gr1 = gr1 + 0.1;
        //        }
        //        richTextBox2.Text = res2 + "\n";
        //    });
    }
}