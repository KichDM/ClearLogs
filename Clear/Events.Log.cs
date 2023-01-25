using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsDeleteApp.Clear
{
    class EventsLog : IClean
    {
        public override void Do()
        {
            try
            {
                var psi = new ProcessStartInfo();
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                psi.CreateNoWindow = true;
                psi.FileName = @"cmd";
                psi.Arguments = @"/c for /F ""tokens=*"" %1 in ('wevtutil.exe el') DO wevtutil.exe cl ""%1""";
                var prc = Process.Start(psi);
            }
            catch (Exception e)
            {

            }

        }
    }
}
