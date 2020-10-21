using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwoLab.Model;
using TwoLab.View;

namespace TwoLab
{
    public partial class Form1 : Form
    {
        private BindingSource _BindingSourse;
        public Form1()
        {

            InitializeComponent();
            _BindingSourse = new BindingSource();
            _BindingSourse.DataSource = StorageFabrica.fabricas;
            dataGridView1.DataSource = _BindingSourse;
            dataGridView1.AutoResizeColumns();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            buttonAdd.Click += AddFactor_Click;
            buttonSort.Click += Sort_Click;
            buttonMerge.Click += Merge_Click;
            buttonAddPerson.Click += AddPerson_Click;
            buttonDeletePerson.Click += DeletePerson_Click;
            
        }

        private void DeletePerson_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Fabrica factorcell = row.DataBoundItem as Fabrica;
                if (factorcell != null)
                {

                    factorcell.RemoveWorking(Convert.ToInt32(textBoxNumber.Text));
                    _BindingSourse.ResetBindings(true);
                }

            }
        }

        private void AddPerson_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Fabrica factorcell = row.DataBoundItem as Fabrica;
                if (factorcell != null)
                {

                    factorcell.AddWorking(Convert.ToInt32(textBoxNumber.Text));
                    _BindingSourse.ResetBindings(true);
                }

            }
        }

        private void AddDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                Fabrica factorcell = row.DataBoundItem as Fabrica;
                if (factorcell != null)
                {
                    
                }

            }
        }

        private void Merge_Click(object sender, EventArgs e)
        {
            Fabrica factorcell = new Fabrica();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                factorcell = row.DataBoundItem as Fabrica;
                if (factorcell != null)
                {

                }

            }
            Fabrica factorcell1 = new Fabrica();
            foreach (DataGridViewRow row1 in this.dataGridView1.SelectedRows)
            {
                factorcell1 = row1.DataBoundItem as Fabrica;
                if (factorcell1 != null)
                {
                    Fabrica resultfact = factorcell + factorcell1;
                    StorageFabrica.AddNewObjectStorage(resultfact);
                    _BindingSourse.DataSource = StorageFabrica.fabricas;
                    _BindingSourse.ResetBindings(true);
                }

            }
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            Array.Sort<Fabrica>(StorageFabrica.fabricas);
            _BindingSourse.ResetBindings(true);
        }

        private void AddFactor_Click(object sender, EventArgs e)
        {
            var dialog = new AddFabrica();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                 StorageFabrica.AddNewObjectStorage(dialog.fabrica);
                _BindingSourse.DataSource = StorageFabrica.fabricas;
                _BindingSourse.ResetBindings(true);

            }
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
