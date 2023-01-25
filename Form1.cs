namespace LogsDeleteApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Clear.Core.Start();
            Thread.Sleep(5000);
            MessageBox.Show("Logs Clear :D", "Press ok for finish", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Clear.Core.Start();
            Environment.Exit(0);
        }
    }
}