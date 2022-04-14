using System.Text;

namespace Income
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[i].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[i].Cells[2].Value = textBox3.Text;

            inIn = Convert.ToInt32((textBox2.Text).ToString());
            inEx = Convert.ToInt32((textBox3.Text).ToString());

            sumin = inIn + sumin;
            sumex = inEx + sumex;

            textBox4.Text = sumin.ToString();
            textBox5.Text = sumex.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "expense(*.csv)|expense.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] expense = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            expense[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    expense[i] = dataGridView1.Rows[i-1].Cells[j].Value.ToString() + ",";

                                }
                            }
                            File.WriteAllLines(sfd.FileName, expense, Encoding.UTF8);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "expense(*.csv)|expense.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                this.dataGridView1.Text = readAllLine[0];
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string listRAW = readAllLine[i];
                    string[] listSplited = listRAW.Split(',');
                    IncomeandExpense list = new IncomeandExpense(listSplited[0], listSplited[1], listSplited[2]);
                }


            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "expense (*.csv) | expense.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != String.Empty)
                {
                    filepath = saveFileDialog.FileName;

                    int row = this.dataGridView1.Rows.Count;
                    for (int i = 0; i < row; i++)
                    {
                        int column = this.dataGridView1.Columns.Count;
                        for (int j = 0; j < column; j++)
                        {
                            this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    File.WriteAllText(filepath, this.textBox1.Text, Encoding.UTF8);

                }
            }
        }
        int sumin = 0, sumex = 0, inIn = 0, inEx = 0;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}