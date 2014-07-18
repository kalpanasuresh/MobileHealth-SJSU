using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.BusinessLayer.BusinessObjects
{
    public class Doctor
    {
        private string _fName;
        private string _LName;
        private string _dOBirth;
        private string _gender;
        private string _email;
        private string _zip;
        private string _user;
        private string _pass;
        private int _docID;
        private string _phone;
        private string _secQu;
        private string _answer;
        private string _NatProvID;
        private string _PrmSpl;
        private string _LicType;
        private string _title;
        private string _officeAdr;
        private string _state;
        private string _city;
        

        public Doctor()
        {
        }
        public Doctor(int DocID, string firstName, string lastName)
        {
            this._docID = DocID;
            this._fName = firstName;
            this._LName = lastName;
           

        }
        public Doctor(int DocID, string firstName, string lastName, string phone, string uID, string email, string pass, string secQues, string secAns, string lictype, string natprovid, string spl, string offAd, string city, string state, string szip, string title, string dob)
        {
            this._docID = DocID;
            this._fName = firstName;
            this._LName = lastName;
            this._phone = phone;
            this._answer = secAns;
            this._city = city;
            this._dOBirth = dob;
            this._email = email;
            this.gender = gender;
            this._LicType = lictype;
            this._NatProvID = natprovid;
            this._officeAdr = offAd;
            this._pass = pass;
            this._PrmSpl = spl;
            this._secQu = secQues;
            this._state = state;
            this._title = title;
            this._zip = szip;
            this._user = uID;

        }
        public int DoctorID
        {
            get { return _docID; }
            set { _docID = value; }
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

        public string Password
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public string Primary_spl
        {
            get { return _PrmSpl; }
            set { _PrmSpl = value; }
        }
        public string National_PrvID
        {
            get { return _NatProvID; }
            set { _NatProvID = value; }
        }

        public string License_Type
        {
            get { return _LicType; }
            set { _LicType = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string DateOfBirth   
        {
            get { return _dOBirth; }
            set { _dOBirth = value; }
        }

      


        public string officeAdr
        {
            get { return _officeAdr; }
            set { _officeAdr = value; }
        }



    }

}
