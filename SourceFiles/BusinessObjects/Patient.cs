using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.BusinessLayer.BusinessObjects
{
    public class Patient
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
        private string _healthIn;
        private string _locPolicy;
        private string _address;
           private string _city;
           private string _state;
        private string _provider;

        public Patient()
        {
        }
        public Patient(int patientID, string firstName, string lastName, string phone)
        {
            this._patientID = patientID;
            this._fName = firstName;
            this._LName = lastName;
            this._phone = phone;
        }
          public Patient(int patientID, string firstName, string lastName,string dob,string gen,string email,string zip,string user,string pass, string phone,string secques, string secQAns,string InsName, string LocPolicy, string addr, string provider, string state,string city)
        {
            this._patientID = patientID;
             this._fName=firstName;
        this._LName=lastName;
        this._dOBirth=dob;
        this._gender=gen;
        this._email=email;
        this._zip=zip;
        this._user=user;
        this._pass=pass;
        this._phone=phone;
        this._secQu=secques;
        this._answer=secQAns;
        this._healthIn=InsName;
        this._locPolicy=LocPolicy;
        this._address=addr;
           this._city=city;
           this._state=state;
           this._provider = provider;
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
        public string Email
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
        public string InsurName
        {
            get
            {
                return _healthIn;
            }
            set
            {
                _healthIn = value;
            }

        }
        public string LocationOfPolicy
        {
            get
            {
                return _locPolicy;
            }
            set
            {
                _locPolicy = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
        public string Provider
        {
            get
            {
                return _provider;
            }
            set
            {
                _provider = value;
            }
        }



    }

}
