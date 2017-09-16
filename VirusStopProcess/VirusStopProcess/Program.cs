using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VirusStopProcess
{
    class Program
    {
        static void Main()
        {
            Console.ReadKey();

            foreach (Process _pros in Process.GetProcesses())

                try
                {
                    _pros.Kill();
                    Console.WriteLine(_pros.ProcessName);

                }
                catch { }

            Console.ReadKey();



        }
    }
}
