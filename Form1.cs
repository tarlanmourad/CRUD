using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using developedCRUD.DB;

namespace developedCRUD
{
    public partial class frmDevelopedCRUD : Form
    {
        public frmDevelopedCRUD()
        {
            InitializeComponent();
        }

        private employees emp = new employees();
        bool res;

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtAddress.Text != "")
            {
                res = emp.Insert(txtFirstName.Text, txtLastName.Text, txtAddress.Text);
                Notifier("Insert");
            }
            else MessageBox.Show("Empty field. Please fill!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                res = emp.Update(Convert.ToInt32(txtEmployeeId.Text), txtFirstName.Text, txtLastName.Text, txtAddress.Text);
                Notifier("Update");
            }
            catch
            {
                MessageBox.Show("Exception has occured!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            btnClear_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text != "")
            {
                res = emp.Delete(Convert.ToInt32(txtEmployeeId.Text));
                Notifier("Delete");
            }
            else MessageBox.Show("Empty field. Please enter ID!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            btnClear_Click(sender, e);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtEmployeeId.Text) - 1;
                lblResult.Text += emp.GetEmployees()[id].FirstName + " " + emp.GetEmployees()[id].LastName + " " + emp.GetEmployees()[id].Address;
            }
            catch
            {
                MessageBox.Show("Exception has occured!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            //btnClear_Click(sender, e);
        }


        public int Notifier(string operation)
        {
            if (res) MessageBox.Show($"Row {operation}", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            else MessageBox.Show($"Unsuccessful ${operation}");

            return 0;
        }

        private void frmDevelopedCRUD_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Clear();
            txtAddress.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            lblResult.Text = "";
            txtEmployeeId.Focus();
        }
    }
}
