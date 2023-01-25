using System;
using System.Diagnostics;
using System.IO;

namespace LogsDeleteApp.Clear
{
    internal class Prefetch : IClean
    {
        private DateTime dateTime = DateTime.Now.AddMinutes(2);
        private string PathToPrefetch;

        public override void Do()
        {
            CleanSelf();
        }

        private void CleanSelf()
        {
            var value = Process.GetCurrentProcess().ProcessName.ToUpper();
            var files = Directory.GetFiles(GetPathToPrefetch());
            foreach (var file in files)
                if (Path.GetFileName(file).Contains(value))
                {
                    File.Delete(file);
                    break;
                }
        }

        public static bool CleanApp(string exename)
        {
            try
            {
                var value = Path.GetFileName(exename).ToUpper();
                var files = Directory.GetFiles(Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\Prefetch");
                foreach (var file in files)
                {
                    string app = Path.GetFileName(file);
                    bool result = app.Contains(value);
                    if (result || app.Contains("Form"))
                    {
                        File.Delete(file);
                        if (result)
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {

            }


            return false;
        }

        private string GetPathToPrefetch()
        {
            if (PathToPrefetch != null)
                return PathToPrefetch;

            var path = Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\Prefetch";
            PathToPrefetch = path;

            return path;
        }
    }
}