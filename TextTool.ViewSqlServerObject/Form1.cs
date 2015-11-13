using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextTool.Common.WindowsForm;

namespace TextTool.ViewSqlServerObject
{
    public partial class Form1 : EnhancedForm
    {
        public Form1()
        {
            InitializeComponent();

            this.txtContent.SetHighlighting("SQL");
            EnhancedForm.RememberForm = this;

            var lstConnStrs = new ConfigMgr().GetAllConnStrs();
            lstConnStrs.ForEach((itm) => {
                this.cmbDB.Items.Add(itm);
            });
        }

        protected override List<Control> RememberControls
        {
            get
            {
                return new List<Control>() 
                {
                    this.txtContent,
                    this.cmbDB,
                    this.txtSPName
                };
            }
        }

        private void startAndStopButton1_OnStartButtonClick()
        {
            if (this.cmbDB.InvokeRequired)
            {
                this.cmbDB.InvokeAction(LoadDBObjectContent);
            }
            else 
            {
                LoadDBObjectContent();
            }            
        }

        private void LoadDBObjectContent()
        {
            if (this.cmbDB.SelectedItem == null)
            {
                MessageBox.Show("Please select a server.");

                return;
            }

            string connString = (this.cmbDB.SelectedItem as ConnectString).Value;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT text
                            FROM syscomments
                            WHERE id = (SELECT TOP 1 id FROM sysobjects WHERE name like @SPName)";
                    cmd.Parameters.Add(new SqlParameter("@SPName", string.Format("%{0}%", txtSPName.Text.Trim())) { DbType = DbType.String, Size = 256 });
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        this.txtContent.SetTextByInvoke(result.ToString());
                    }
                    else
                    {
                        this.txtContent.SetTextByInvoke("Not Found !");
                    }
                }
            }
        }
    }
}
