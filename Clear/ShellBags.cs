using System;
using Microsoft.Win32;

namespace LogsDeleteApp.Clear
{
    internal class ShellBags : IClean
    {
        private DateTime dateTime = DateTime.Now.AddMinutes(2);
        private string PathToPrefetch = null;

        public override void Do()
        {
            CleanSelf();
        }

        private void CleanSelf()
        {
            var pth = "Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\";
            try
            {
                try
                {
                    Registry.CurrentUser.DeleteSubKeyTree(
                        pth);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
    }
}