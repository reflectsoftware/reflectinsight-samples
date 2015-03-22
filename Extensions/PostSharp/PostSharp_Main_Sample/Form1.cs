using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using PostSharp_Common_Sample;

namespace PostSharp_Main_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TraceServiceInterface.Interface1("test1", 32,
                new byte[] { 1, 2, 4 },
                new List<string>() { "r1", "c1", "g1" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TraceServiceInterface.Interface1("error", 32,
                    new byte[] { 1, 2, 4 },
                    new List<string>() { "r1", "c1", "g1" });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TracerFieldPostSharp obj = new TracerFieldPostSharp();
            obj.Name = Guid.NewGuid().ToString();
            obj.Address = Guid.NewGuid().ToString();
            obj.Age = Guid.NewGuid().ToString();
        }
    }
}
