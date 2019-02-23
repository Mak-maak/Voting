using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace VoteToHead
{
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            MessageBox.Show("Successfully Logged Out!");
            this.Close();
            f1.Show();


        }

        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rdHg1.Checked == true)
            {
                if (MessageBox.Show("Are you sure?\nYou want to vote this Candidate?", "'" + rdHg1.Text + "'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveVotes(rdHg1.Text);
                }
            }

            if (rdHg2.Checked == true)
            {
                if (MessageBox.Show("Are you sure?\nYou want to vote this Candidate?", "'" + rdHg2.Text + "'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveVotes(rdHg2.Text);
                }
            }

            if (rdHg3.Checked == true)
            {
                if (MessageBox.Show("Are you sure?\nYou want to vote this Candidate?", "'"+rdHg3.Text+"'", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveVotes(rdHg3.Text);
                }
            }
        }


        // method to save votes
        private void SaveVotes(string name)
        {
            try
            {
                // connection settings
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\\Database\\VTDatabase.mdf';Integrated Security=True");
                SqlDataReader reader;
                DataSet ds = new DataSet();
                connection.Open();
                var cmd1 = new SqlCommand("Select Votes from Table where Name= '" + name + "'", connection);
                reader = cmd1.ExecuteReader();

                // make a list of integers to save votes
                List<int> currentVotes = new List<int>();

                // use a while loop to read data form database
                //while (reader.Read())
              // {
                    reader.Read();
                    currentVotes.Add(int.Parse(reader[0].ToString()));

                    // increment in votes
                    currentVotes = currentVotes.Select(x => x + 1).ToList();
                    foreach (var x in currentVotes) { MessageBox.Show("Votes: " + x); }
              // }
                connection.Close();

                // open connection again so that it won't be conflict
                connection.Open();
                for (int i = 0; i < currentVotes.Count; i++)
                {
                    string processQuery = "Update Table Set Votes = '" + currentVotes[i] + "' Where Name = '" + name + "'";
                    var command = new SqlCommand(processQuery, connection);
                    reader.Close();
                    reader = command.ExecuteReader();
                }
                connection.Close();
                MessageBox.Show("Thank you for the participation! You vote to '" + name + "'", "Message");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connection failed! Please try again\n" + ex.ToString());
                //connection.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /*
        private void MaxDate()
        {

            string qry = "select Name from Candidate where EventTime = (Select max(EventTime) from Candidate);";
            SqlConnection sqlcn = new SqlConnection(Properties.Settings.Default.msdbConnectionString);
            SqlCommand cmd = new SqlCommand(qry, sqlcn);
            /*
            sqlcn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                MessageBox.Show(name);
            }
            
            MessageBox.Show("Success!");
            
        }*/
    }
}

      