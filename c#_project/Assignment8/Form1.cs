using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment8 {
    public partial class assignment8Form : Form {
        public assignment8Form() {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e) {
            //Clears the list box to receive new input
            outputListBox.Items.Clear();

            //Tries to initialize the employee name, stopping the method if none is provided
            if (checkName(employeeTextBox, "employee") == false) {
                return;
            }
            string employeeName = employeeTextBox.Text;

            //Tries to initialize the supervisor name, stopping the method if none is provided
            if (checkName(supervisorTextBox, "supervisor") == false) {
                return;
            }
            string supervisorName = supervisorTextBox.Text;

            //Tries to initialize the reporting period, stopping the method if no valid entry is provided
            int reportingPeriod = 0;
            try {
                reportingPeriod = Convert.ToInt32(periodTextBox.Text);
            } catch (FormatException) {
                MessageBox.Show("The report period is invalid.");
                periodTextBox.Focus();
                return;
            } if (reportingPeriod < 1 || reportingPeriod > 52) {
                MessageBox.Show("Please enter a report period between 1 and 52.");
                periodTextBox.Focus();
                return;
            }

            //Tries to initialize the client name, stopping the method if none is provided
            if (checkName(clientTextBox, "client") == false) {
                return;
            }
            string clientName = clientTextBox.Text;

            //Tries to initialize the contract name, stopping the method if none is provided
            if (checkName(contractTextBox, "contract") == false) {
                return;
            }
            string contract = contractTextBox.Text;

            //Tries to initialize the project name, stopping the method if none is provided
            if (checkName(projectTextBox, "project") == false) {
                return;
            }
            string project = projectTextBox.Text;

            //Initializes variables for each weekday, stopping the method if any errors arise
            if (testForErrors(sundayCheckBox, sundayTextBox, "Sunday") == false) {
                return;
            } int sundayHours = setHours(sundayCheckBox, sundayTextBox);
            if (testForErrors(mondayCheckBox, mondayTextBox, "Monday") == false) {
                return;
            } int mondayHours = setHours(mondayCheckBox, mondayTextBox);
            if (testForErrors(tuesdayCheckBox, tuesdayTextBox, "Tuesday") == false) {
                return;
            } int tuesdayHours = setHours(tuesdayCheckBox, tuesdayTextBox);
            if (testForErrors(wednesdayCheckBox, wednesdayTextBox, "Wednesday") == false) {
                return;
            } int wednesdayHours = setHours(wednesdayCheckBox, wednesdayTextBox);
            if (testForErrors(thursdayCheckBox, thursdayTextBox, "Thursday") == false) {
                return;
            } int thursdayHours = setHours(thursdayCheckBox, thursdayTextBox);
            if (testForErrors(fridayCheckBox, fridayTextBox, "Friday") == false) {
                return;
            } int fridayHours = setHours(fridayCheckBox, fridayTextBox);
            if (testForErrors(saturdayCheckBox, saturdayTextBox, "Saturday") == false) {
                return;
            } int saturdayHours = setHours(saturdayCheckBox, saturdayTextBox);

            //Calculates the result
            CheckBox[] checkBoxes = { sundayCheckBox, mondayCheckBox, tuesdayCheckBox, wednesdayCheckBox, thursdayCheckBox, fridayCheckBox, saturdayCheckBox };
            int totalHours = sundayHours + mondayHours + tuesdayHours + wednesdayHours + thursdayHours + fridayHours + saturdayHours;
            int regularHours = 0;
            int overtimeHours = 0;
            int vacationDays = 0;

            double regularSalary = 15.00;
            double overtimeSalary = regularSalary * 1.5;

            double regularPay = 0.00;
            double overtimePay = 0.00;
            double totalPay = 0.00;

            for(int i = 0; i < checkBoxes.Length; i++) {
                if(checkBoxes[i].Checked == true) {
                    vacationDays += 1;
                }
            }

            if(totalHours > 40) {
                regularHours = 40;
                overtimeHours = totalHours - 40;
                overtimePay = overtimeSalary * (overtimeHours);
            } else {
                regularHours = totalHours;
            }
            regularPay = regularSalary * regularHours;

            totalPay = regularPay + overtimePay;

            //Outputs the result, often formatted as fixed-point (F) or currency (C) depending on what they intend to represent
            outputListBox.Items.Add("Employee name: " + employeeName);
            outputListBox.Items.Add("Supervisor name: " + supervisorName);
            outputListBox.Items.Add("Reporting period: Week " + reportingPeriod);
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Client name: " + clientName);
            outputListBox.Items.Add("Contract: " + contract);
            outputListBox.Items.Add("Project: " + project);
            outputListBox.Items.Add("");
            outputListBox.Items.Add("-------------------------");
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Total Hours Worked: " + totalHours.ToString("F"));
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Regular Hours Worked: " + regularHours.ToString("F"));
            outputListBox.Items.Add("Rate per Regular Work Hour: " + regularSalary.ToString("C"));
            outputListBox.Items.Add("Regular Hourly Pay: " + regularPay.ToString("C"));
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Overtime Hours Worked: " + overtimeHours.ToString("F"));
            outputListBox.Items.Add("Rate per Overtime Work Hour: " + overtimeSalary.ToString("C"));
            outputListBox.Items.Add("Overtime Hourly Pay: " + overtimePay.ToString("C"));
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Gross Pay: " + totalPay.ToString("C"));
            outputListBox.Items.Add("");
            outputListBox.Items.Add("Weekend/Holiday/Vacation days claimed: " + vacationDays);
        }

        //Handles when each checkbox is toggled
        private void sundayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(sundayCheckBox, sundayTextBox);
        }
        private void mondayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(mondayCheckBox, mondayTextBox);
        }
        private void tuesdayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(tuesdayCheckBox, tuesdayTextBox);
        }
        private void wednesdayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(wednesdayCheckBox, wednesdayTextBox);
        }
        private void thursdayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(thursdayCheckBox, thursdayTextBox);
        }
        private void fridayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(fridayCheckBox, fridayTextBox);
        }
        private void saturdayCheckBox_CheckedChanged(object sender, EventArgs e) {
            toggleTextBoxEnabled(saturdayCheckBox, saturdayTextBox);
        }

        //Toggles textbox availability
        private void toggleTextBoxEnabled(CheckBox check, TextBox text) {
            if (check.Checked) {
                text.Enabled = false;
            } else {
                text.Enabled = true;
            }
        }

        private bool testForErrors(CheckBox check, TextBox text, String dayOfWeek) {
            //Checks each checkbox to see if it is checked, then checks if the number entered in the textbox is invalid
            if (check.Checked == false) {
                int hours = 0;
                try {
                    hours = Convert.ToInt32(text.Text);
                } catch (FormatException) {
                    MessageBox.Show("This input for " + dayOfWeek + " is invalid.");
                    text.Focus();
                    return false; //If the value is blank or improperly formatted
                } if (hours < 0 || hours > 24) {
                    MessageBox.Show("Please enter a number between 0 and 24 when recording hours for " + dayOfWeek + ".");
                    text.Focus();
                    return false; //If the value sits somewhere outside the acceptable range
                }
            }
            return true; //If no errors arise
        }

        //Inspects a checkbox to see if it is checked, returning the contents of its accompanying text file if it is checked and returning 0 otherwise
        private int setHours(CheckBox check, TextBox text) {
            if (check.Checked == false) {
                return Convert.ToInt32(text.Text);
            } return 0;
        }

        //Searches for any blank textboxes, returning an error message if any are present
        private bool checkName(TextBox text, string type) {
            if (text.Text == "") {
                MessageBox.Show("No " + type + " name has been entered.");
                text.Focus();
                return false;
            } else {
                return true;
            }
        }
    }
}
