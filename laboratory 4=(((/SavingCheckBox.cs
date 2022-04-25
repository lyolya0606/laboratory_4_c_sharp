using System.IO;

namespace laboratory_4 {
    public class SavingCheckBox {
        public bool ReadCheckBox() {
            try {
                using (StreamReader file = new StreamReader("CheckBox.txt")) {
                    if (int.Parse(file.ReadLine()) == 1) {
                        return true;
                    }
                    file.Close();
                }
                return false;
            }
            catch (IOException) {
                using (FileStream file = new FileStream("CheckBox.txt", FileMode.Create)) {
                    StreamWriter fileWriter = new StreamWriter(file);
                    fileWriter.WriteLine(1);
                    fileWriter.Close();
                }
            }
            return true;
        }

        public void ChangeMessageBox(bool showAgain) {
            using (FileStream file = new FileStream("CheckBox.txt", FileMode.Open)) {
                StreamWriter fileWriter = new StreamWriter(file);

                if (showAgain) {
                    fileWriter.WriteLine(1);
                }
                else {
                    fileWriter.WriteLine(0);
                }
                fileWriter.Close();
            }

        }
    }
}

