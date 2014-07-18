using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObject
{
    public class BO_Patient
    {
        private string _fName;
        private string _LName;
        private string _dOBirth;
        private string _gender;
        private string _email;
        private string _zip;
        private string _user;
        private string _pass;
        private int _patientID;
        private string _phone;
        private string _secQu;
        private string _answer;
        //private string _secQu;
        //private string _answer;
        //private string _healthIn;
        //private string _locPolicy;
        //private string _InName;

        public BO_Patient()
        {
        }
        public int PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }
        public string fName
        {
            get { return _fName; }
            set { _fName = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string LName
        {
            get { return _LName; }
            set { _LName = value; }
        }
        public string dOBirth
        {
            get { return _dOBirth; }
            set { _dOBirth = value; }
        }
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string UserID
        {
            get { return _user; }
            set { _user = value; }
        }

        public string SecQues
        {
            get { return _secQu; }
            set { _secQu = value; }
        }
        public string SecAns
        {
            get { return _answer; }
            set { _answer = value; }
        }

        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }







    }

}
