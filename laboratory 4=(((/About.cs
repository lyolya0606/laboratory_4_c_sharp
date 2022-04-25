using System;
using System.Windows.Forms;

namespace laboratory_4 {
    public partial class About : Form {
        public bool IsAgain { get; set; }

        public About(bool isAgain) {
            IsAgain = isAgain;
            InitializeComponent();
        }

        public void SavingChoice() {
            SavingCheckBox savingCheckBox = new SavingCheckBox();
            if (savingCheckBox.ReadCheckBox()) {
                checkBox.Checked = false;
            }
            else {
                checkBox.Checked = true;
            }
        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e) {
            IsAgain = !checkBox.Checked;

        }

        private void ClosingAbout(object sender, FormClosingEventArgs e) {
            SavingCheckBox savingCheckBox = new SavingCheckBox();
            savingCheckBox.ChangeMessageBox(IsAgain);
        }

    }
}
