using System;
using System.Collections.Generic;
using System.Text;

namespace DoFactory.BusinessLayer.BusinessObjects
{
    public class Appointment
    {
        private int _patientID;
        private int _doctorID;       
        private int _apptID;
        private DateTime _date;       
        private string _AM_0800;
       private string _AM_0830;
        private string _AM_0900;
        private string _AM_0930;
        private string _AM_1000;
        private string _AM_1030;
        private string _AM_1100;
        private string _AM_1130;
        private string _PM_1200;
        private string _PM_1230;
        private string _PM_0100;
        private string _PM_0130;
        private string _PM_0200;
        private string _PM_0230;
        private string _PM_0300;
        private string _PM_0330;
        private string   _PM_0400;
        private string _PM_0430;
        private string _PM_0500;
        public Appointment(int PatID, int DocID,DateTime sDate, string s8, string s830, string s9, string s930,string s10, string s1030, string s11, string s1130, string s12, string s1230, string s1, string s130, string s2, string s230,string s3, string s330, string s4, string s430, string s5 )
        {
            this._patientID = PatID;
            this._doctorID = DocID;
            this._date = sDate;
            this._AM_0800 = s8;
            this._AM_0830 = s830;
            this._AM_0900 = s9;
            this._AM_0930 = s930;
            this._AM_1000 = s10;
            this._AM_1030 = s1030;
            this._AM_1100 = s11;
            this._AM_1130 = s1130;
            this._PM_1200 = s12;
            this._PM_1230 = s1230;
            this._PM_0100 = s1;
            this._PM_0130 = s130;
            this._PM_0200 = s2;
            this._PM_0230 = s230;
            this._PM_0300 = s3;
            this._PM_0330 = s330;
            this._PM_0400 = s4;
            this._PM_0430 = s430;
            this._PM_0500 = s5;
        }
        public Appointment()
        {
        }
        public int PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }
        }
        public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }
        public DateTime cDate
        {
            get { return _date; }
            set { _date = value; }
        }
        public string AM8
        {
            get { return _AM_0800; }
            set { _AM_0800 = value; }
        }
        public string AM830
        {
            get { return _AM_0830; }
            set { _AM_0830 = value; }
        }
        public string AM9
        {
            get { return _AM_0900; }
            set { _AM_0900 = value; }

        }
        public string AM930
        {
            get { return _AM_0930; }
            set { _AM_0930 = value; }
        }
        public string AM10
        {
            get { return _AM_1000; }
            set { _AM_1000 = value; }
        }
        public string AM1030
        {
            get { return _AM_1030; }
            set { _AM_1030 = value; }
        }
        public string AM11
        {
            get { return _AM_1100; }
            set {_AM_1100 = value; }
        }
        public string AM1130
        {
            get { return _AM_1130; }
            set { _AM_1130 = value; }
        }
        public string PM12
        {
            get { return _PM_1200; }
            set { _PM_1200 = value; }
        }
        public string PM1230
        {
            get { return _PM_1230; }
            set { _PM_1230 = value; }
        }
        public string PM0100
        {
            get { return _PM_0100; }
            set { _PM_0100 = value; }
        }
        public string PM0130
        {
            get { return _PM_0130; }
            set { _PM_0130 = value; }
        }
        public string PM0200
        {
            get { return _PM_0200; }
            set { _PM_0200 = value; }
        }
        public string PM0230
        {
            get { return _PM_0230; }
            set { _PM_0230 = value; }
        }
        public string PM0300
        {
            get { return _PM_0300; }
            set { _PM_0300 = value; }
        }
        public string PM0330
        {
            get { return _PM_0330; }
            set { _PM_0330 = value; }
        }
        public string PM0400
        {
            get { return _PM_0400; }
            set { _PM_0400 = value; }
        }
        public string PM0430
        {
            get { return _PM_0430; }
            set { _PM_0430 = value; }
        }
        public string PM0500
        {
            get { return _PM_0500; }
            set { _PM_0500 = value; }
        }

    }
}
