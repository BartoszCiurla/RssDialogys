using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RssDialogys.WinFormsUI.RssEngine;
using RssDialogys.Domain.Entities;

namespace RssDialogys.WinFormsUI
{
    public partial class RaportsForm : Form
    {
        public RaportsForm()
        {
            InitializeComponent();
        }
        public RaportsForm(List<Item> reportData)
        {
            //zle reozwiązania , brak czasu na rozwijanie tego miejsca.
            InitializeComponent();
            raportsDGV.DataSource = reportData;
           
        }

        private void raportsDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //bardzo spowalnia dzialanie aplikacji ...
            foreach (DataGridViewRow row in raportsDGV.Rows)
            {
                DateTime rowtype = Convert.ToDateTime(row.Cells["PublishDate"].Value);

                if (rowtype < DateTime.Now.AddDays(-30))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }

                else if (rowtype < DateTime.Now.AddDays(-7))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }

                else if (rowtype < DateTime.Now.AddDays(-1))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (rowtype < DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Lime;
                }
            }          
        }
      
    }
}
