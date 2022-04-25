using System;

namespace laboratory_4 {
    class Check {
        private bool CheckText(string text) {
            foreach (char c in text) {
                if (!Char.IsLetter(c)) {
                    return false;
                }
            }
            return true;
        }

        private bool CheckNum(string num, bool isNumber) {
            try {
                if (isNumber) {
                    int.Parse(num);
                } else {
                    decimal.Parse(num);
                }
                return true;
            } catch (FormatException) {
                return false;
            }
        }

        public bool CheckAll(string number, string name, string surname, string balance) {
            if (!CheckNum(number, true) || !CheckNum(balance, false) || !CheckText(name) || !CheckText(surname)) {
                return false;
            } else {
                return true;
            }
        }        
    }
}
