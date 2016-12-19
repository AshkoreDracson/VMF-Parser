using VMFParser;
using System;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            Map m = Map.Parse(ofd.FileName);
        }
    }
}