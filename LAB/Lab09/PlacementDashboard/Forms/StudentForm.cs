
using System;
using System.Drawing;
using System.Windows.Forms;
using PlacementDashboard.Data;
using PlacementDashboard.Helpers;

namespace PlacementDashboard.Forms
{
    public class StudentForm : Form
    {
        private readonly StudentRepository repo = new StudentRepository();

        private TextBox txtName, txtEnrollment, txtCGPA;
        private TextBox txtCompany, txtPackage, txtSearch;
        private ComboBox cmbDepartment, cmbStatus;
        private DataGridView dgvStudents;

        public StudentForm()
        {
            Text = "Student Placement Management";
            Size = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BuildInterface();
            LoadStudents();
        }

        private void BuildInterface()
        {
            Label title = new Label
            {
                Text = "STUDENT PLACEMENT MANAGEMENT",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(25, 15),
                Size = new Size(650, 40)
            };
            Controls.Add(title);

            // Field labels
            AddLabel("Student Name", 25, 65);
            AddLabel("Enrollment No.", 260, 65);
            AddLabel("CGPA (0-10)", 495, 65);

            AddLabel("Company Name", 25, 125);
            AddLabel("Package (LPA)", 260, 125);
            AddLabel("Department", 495, 125);
            AddLabel("Placement Status", 730, 125);

            // Input fields
            txtName = AddTextBox(25, 85, 200);
            txtEnrollment = AddTextBox(260, 85, 200);
            txtCGPA = AddTextBox(495, 85, 200);

            txtCompany = AddTextBox(25, 145, 200);
            txtPackage = AddTextBox(260, 145, 200);

            cmbDepartment = new ComboBox
            {
                Location = new Point(495, 145),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDown
            };

            cmbDepartment.Items.AddRange(new object[]
            {
                "Computer Engineering",
                "Information Technology",
                "Mechanical Engineering",
                "Civil Engineering",
                "Electrical Engineering"
            });

            Controls.Add(cmbDepartment);

            cmbStatus = new ComboBox
            {
                Location = new Point(730, 145),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbStatus.Items.AddRange(new object[]
            {
                "Placed",
                "Not Placed"
            });

            cmbStatus.SelectedIndex = 1;
            Controls.Add(cmbStatus);

            // CRUD buttons
            AddButton("Add", 25, 200, AddStudent);
            AddButton("Update", 125, 200, UpdateStudent);
            AddButton("Delete", 225, 200, DeleteStudent);
            AddButton("Clear", 325, 200, ClearFields);

            // Search controls
            AddLabel("Search by name, enrollment, department, company or status", 495, 185);

            txtSearch = AddTextBox(495, 205, 260);
            AddButton("Search", 770, 200, SearchStudents);
            AddButton("Refresh", 870, 200, LoadStudents);

            // Student records table
            dgvStudents = new DataGridView
            {
                Location = new Point(25, 255),
                Size = new Size(1030, 380),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                MultiSelect = false
            };

            dgvStudents.CellClick += DgvStudents_CellClick;
            Controls.Add(dgvStudents);
        }

        private void AddLabel(string text, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            });
        }

        private TextBox AddTextBox(int x, int y, int width)
        {
            TextBox box = new TextBox
            {
                Location = new Point(x, y),
                Width = width
            };

            Controls.Add(box);
            return box;
        }

        private void AddButton(
            string text, int x, int y, Action action)
        {
            Button button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(90, 32)
            };

            button.Click += (s, e) => action();
            Controls.Add(button);
        }

        private void LoadStudents()
        {
            try
            {
                dgvStudents.DataSource = repo.GetAllStudents();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private bool GetInput(
            out decimal cgpa, out decimal? package, out string status)
        {
            status = cmbStatus.Text;

            if (!ValidationHelper.ValidateStudent(
                txtName.Text.Trim(),
                txtEnrollment.Text.Trim(),
                txtCGPA.Text.Trim(),
                txtPackage.Text.Trim(),
                status,
                out cgpa,
                out package,
                out string error))
            {
                MessageBox.Show(error, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AddStudent()
        {
            try
            {
                if (!GetInput(out decimal cgpa, out decimal? package,
                    out string status))
                    return;

                repo.AddStudent(
                    txtName.Text.Trim(),
                    txtEnrollment.Text.Trim(),
                    cmbDepartment.Text.Trim(),
                    cgpa,
                    txtCompany.Text.Trim(),
                    package,
                    status);

                LoadStudents();
                ClearFields();
                MessageBox.Show("Student added successfully.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void UpdateStudent()
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            try
            {
                if (!GetInput(out decimal cgpa, out decimal? package,
                    out string status))
                    return;

                int id = Convert.ToInt32(
                    dgvStudents.CurrentRow.Cells["StudentID"].Value);

                repo.UpdateStudent(
                    id,
                    txtName.Text.Trim(),
                    txtEnrollment.Text.Trim(),
                    cmbDepartment.Text.Trim(),
                    cgpa,
                    txtCompany.Text.Trim(),
                    package,
                    status);

                LoadStudents();
                ClearFields();
                MessageBox.Show("Student updated successfully.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void DeleteStudent()
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Select a student first.");
                return;
            }

            if (MessageBox.Show(
                "Delete the selected student?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int id = Convert.ToInt32(
                    dgvStudents.CurrentRow.Cells["StudentID"].Value);

                repo.DeleteStudent(id);
                LoadStudents();
                ClearFields();
                MessageBox.Show("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void SearchStudents()
        {
            try
            {
                dgvStudents.DataSource =
                    repo.SearchStudents(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void DgvStudents_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

            txtName.Text = Convert.ToString(
                row.Cells["StudentName"].Value);

            txtEnrollment.Text = Convert.ToString(
                row.Cells["EnrollmentNo"].Value);

            cmbDepartment.Text = Convert.ToString(
                row.Cells["Department"].Value);

            txtCGPA.Text = Convert.ToString(
                row.Cells["CGPA"].Value);

            txtCompany.Text = Convert.ToString(
                row.Cells["CompanyName"].Value);

            txtPackage.Text = Convert.ToString(
                row.Cells["PackageLPA"].Value);

            cmbStatus.Text = Convert.ToString(
                row.Cells["PlacementStatus"].Value);
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtCGPA.Clear();
            txtCompany.Clear();
            txtPackage.Clear();
            txtSearch.Clear();

            cmbDepartment.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 1;

            dgvStudents.ClearSelection();
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Application Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
