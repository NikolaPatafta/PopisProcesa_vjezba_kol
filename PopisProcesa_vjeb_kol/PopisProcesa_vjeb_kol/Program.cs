using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace PopisProcesa_vjeb_kol
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] broj = new int[50];

            Process[] popisProcesa = Process.GetProcesses();

            foreach (Process proces in popisProcesa)
            {
                Console.WriteLine("Naziv: {0}", proces.ProcessName);
                Console.WriteLine("Velicina {0}", proces.WorkingSet64);
                Console.WriteLine(".................................");

            }

            long a = popisProcesa[0].WorkingSet64;
            for (int i = 0; i < popisProcesa.Length; i++)
            {
                for (int j = i + 1; j < popisProcesa.Length; j++)
                {
                    if (popisProcesa[i].WorkingSet64 > popisProcesa[j].WorkingSet64)
                    {
                        var pridrzi = popisProcesa[i];
                        popisProcesa[i] = popisProcesa[j];
                        popisProcesa[j] = pridrzi;

                    }
                }
            }
            Console.WriteLine("Popis Procesa koji trsoe najvise memorije");
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                var p = popisProcesa[i];
                Console.WriteLine("{0, 15:0.000} MB - {1}", p.WorkingSet64 / (double)(1024 * 1024), p.ProcessName, p.MainWindowTitle);
            }
        }
    }
}
