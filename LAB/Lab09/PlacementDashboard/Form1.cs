
using System;
using System.Drawing;
using System.Windows.Forms;
using PlacementDashboard.Data;
using PlacementDashboard.Forms;

namespace PlacementDashboard
{
    public partial class Form1 : Form
    {
        private readonly StudentRepository repo = new StudentRepository();

        private Label lblTotal;
        private Label lblPlaced;
        private Label lblNotPlaced;
        private Label lblPercentage;

        public Form1()
        {
            InitializeComponent();

            Text = "Placement Dashboard";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;

            BuildDashboard();
            LoadDashboard();
        }

        private void BuildDashboard()
        {
            Label title = new Label
            {
                Text = "COLLEGE PLACEMENT DASHBOARD",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Location = new Point(25, 20),
                Size = new Size(700, 45)
            };
            Controls.Add(title);

            lblTotal = AddStat("Total Students: 0", 30, 100);
            lblPlaced = AddStat("Placed Students: 0", 265, 100);
            lblNotPlaced = AddStat("Not Placed: 0", 500, 100);
            lblPercentage = AddStat("Placement Rate: 0%", 735, 100);

            Button btnStudents = new Button
            {
                Text = "Manage Students",
                Location = new Point(30, 210),
                Size = new Size(180, 45)
            };
            btnStudents.Click += (s, e) =>
            {
                using (StudentForm form = new StudentForm())
                    form.ShowDialog();

                LoadDashboard();
            };
            Controls.Add(btnStudents);

            Button btnRefresh = new Button
            {
                Text = "Refresh Dashboard",
                Location = new Point(230, 210),
                Size = new Size(180, 45)
            };
            btnRefresh.Click += (s, e) => LoadDashboard();
            Controls.Add(btnRefresh);

            Button btnReport = new Button
            {
                Text = "View Placement Report",
                Location = new Point(430, 210),
                Size = new Size(200, 45)
            };
            btnReport.Click += (s, e) =>
            {
                using (ReportForm form = new ReportForm())
                    form.ShowDialog();
            };
            Controls.Add(btnReport);
        }

        private Label AddStat(string text, int x, int y)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(220, 65),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            Controls.Add(label);
            return label;
        }

        private void LoadDashboard()
        {
            try
            {
                var data = repo.GetStatistics();
                int total = Convert.ToInt32(data.Rows[0]["Total"]);
                int placed = Convert.ToInt32(data.Rows[0]["Placed"]);
                int notPlaced = Convert.ToInt32(data.Rows[0]["NotPlaced"]);

                double rate = total == 0 ? 0 : placed * 100.0 / total;

                lblTotal.Text = "Total Students: " + total;
                lblPlaced.Text = "Placed Students: " + placed;
                lblNotPlaced.Text = "Not Placed: " + notPlaced;
                lblPercentage.Text = "Placement Rate: " + rate.ToString("0.00") + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard data.\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
