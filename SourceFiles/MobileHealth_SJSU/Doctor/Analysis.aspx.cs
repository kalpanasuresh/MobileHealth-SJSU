using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SemWeb.Query;
using System.IO;
using SemWeb;
using System.Xml;
using System.Collections.Generic;

public partial class Doctor_Analysis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Doctor");
            ListBox1.Visible = false;
            Button1.Visible = true;
            TextBox1.Visible = true;
            GridView1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Query query;
        XmlDocument xmldoc;
        DataTable dt = new DataTable();
        PrintQuerySink psink = new PrintQuerySink();

        dt.Columns.Add("Name");
        dt.Columns.Add("Disease");
        dt.Columns.Add("Symptom");
        dt.Columns.Add("Medication");



        DirectoryInfo dir = new DirectoryInfo(@"C:\PatientOWLFiles");
        FileInfo[] n3files = dir.GetFiles("*.n3");

        foreach (FileInfo f in n3files)
        {



            string datafile = f.FullName;
            string str = string.Empty;

            if (DropDownList1.SelectedIndex == 0)
            {
                str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
               "SELECT distinct ?dis ?symp ?medi  \n " +
               "from <" + f.FullName + ">\n " +
               " where \n" +
              "{\n" +
              " ?Disease table:disease ?dis.\n" +
              " ?dis table:symptoms ?sym. \n" +
              " ?dis table:medication ?med. \n" +
              "?dis table:disease-name ?dise.\n" +
               "?sym table:symp-name ?symp.\n" +
               "?med table:med-name ?medi.\n";
                str = str + "Filter regex(?dise, \"" + TextBox1.Text + "\" ,\"i\").\n";

            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
               "SELECT distinct ?dis ?symp  ?medi \n " +
               "from <" + f.FullName + ">\n " +
               " where \n" +
              "{\n" +
              " ?Disease table:disease ?dis.\n" +
              " ?dis table:symptoms ?sym. \n" +
              " ?dis table:medication ?med. \n" +
              "?dis table:disease-name ?dise.\n" +
               "?sym table:symp-name ?symp.\n" +
               "?med table:med-name ?medi.\n";
                str = str + "Filter regex(?symp, \"" + TextBox1.Text + "\" ,\"i\").\n";

            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
               "SELECT distinct ?dis ?symp ?medi  \n " +
               "from <" + f.FullName + ">\n " +
               " where \n" +
              "{\n" +
              " ?Disease table:disease ?dis.\n" +
              " ?dis table:symptoms ?sym. \n" +
              " ?dis table:medication ?med. \n" +
              "?dis table:disease-name ?dise.\n" +
               "?sym table:symp-name ?symp.\n" +
               "?med table:med-name ?medi.\n";
                str = str + "Filter regex(?medi, \"" + TextBox1.Text + "\" ,\"i\").\n";

            }

            str = str + "  }\n";

            TextWriter stringWriter = new StringWriter();
            stringWriter.Write(str);


            query = new SparqlEngine(str);
            MemoryStore data = new MemoryStore();
            data.Import(new N3Reader(datafile));

            // First, print results in SPARQL XML Results format...

            // Create a result sink where results are written to.
            XmlTextWriter writer = new XmlTextWriter("C:\\temp\\xmltest3.xml", null);


            QueryResultSink sink = new SparqlXmlQuerySink(writer);



            // Run the query.
            query.Run(data, sink);

            writer.Close();
            TextWriter stringWriter1 = new StringWriter();


            query.Run(data, stringWriter1);

            psink._pName = f.Name.Replace(".n3", "");
            query.Run(data, psink);
            //Response.Write(stringWriter1.ToString());

            //    FileStream fs = new FileStream("C:\\temp\\xmltest3.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //    xmldoc = new XmlDocument();
            //    xmldoc.Load(fs);
            //    XmlNodeList xmlnode = xmldoc.GetElementsByTagName("binding");


            //    for (int i = 0; i < xmlnode.Count; i++)
            //    {

            //        XmlAttributeCollection xmlattrc = xmlnode[i].Attributes;

            //        //XML Attribute Name and Value returned
            //        //Example: <Book id = "001">




            //        //First Child of the XML file - Catalog.xml - returned
            //        //Example: <Author>Mark</Author>
            //        i = i + 1;
            //        dt.Rows.Add(f.Name.Replace(".n3",""),xmlnode[i].NextSibling.InnerText.Replace("http://www.owl-ontologies.com/Ontology1183162121.owl#", ""), xmlnode[i-1].InnerText.Replace("http://www.owl-ontologies.com/Ontology1183162121.owl#", ""),xmlnode[i].InnerText.Replace("http://www.owl-ontologies.com/Ontology1183162121.owl#", ""));



            //    }


            //    fs.Close();
        }

        if (psink.list.Count > 0)
        {
            GridView1.DataSource = null;
            Result r = new Result();
            r.R = psink.list;
            GridView1.DataSource = psink.list;

            GridView1.DataBind();
            GridView1.Visible = true;
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = "No records found";
            lblMessage.Visible = true;
            dt = new DataTable();
        }
    }
    public class PrintQuerySink : QueryResultSink
    {
        public IList<Result> list = new List<Result>();
        public string _pName;

        public override bool Add(VariableBindings result)
        {
            //dt.Columns.Add("Disease");
            //dt.Columns.Add("Symptoms");
            string nam = string.Empty;
            string med = string.Empty;
            string symp = string.Empty;
            foreach (Variable var in result.Variables)
            {

                if (var.LocalName != null && result[var] != null)
                {

                    if (var.LocalName == "medi")
                        med = result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#", "").Replace(">", "");

                    if (var.LocalName == "symp")
                        symp = result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#", "").Replace(">", "");

                    if (var.LocalName == "dis")
                        nam = result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#", "").Replace(">", "");
                }
                Console.WriteLine();
            }
            list.Add(new Result(nam, symp, med, _pName));


            return true;
        }
    }
    [Serializable]
    public class Result
    {

        private string _name;
        private string _symp;
        private string _med;
        private string _patName;
        private IList<Result> r;
        public Result()
        {
        }

        public Result(string Name, string Symp, string Med, string PatientName)
        {
            this._name = Name.Replace("\"", "");
            this._symp = Symp.Replace("\"", "");
            this._med = Med.Replace("\"", "");
            this._patName = PatientName;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Symptom
        {
            get
            {
                return _symp;
            }
            set
            {
                _symp = value;
            }
        }
        public string PatientName
        {
            get
            {
                return _patName;
            }
            set
            {
                _patName = value;
            }
        }
        public string Med
        {
            get
            {
                return _med;
            }
            set
            {
                _med = value;
            }
        }
        public IList<Result> R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }

        public IList<Result> GetResult()
        {

            return R;
        }

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 3)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\PatientOWLFiles");
            FileInfo[] n3files = dir.GetFiles("*.n3");

            foreach (FileInfo f in n3files)
            {
                ListBox1.Items.Add(new ListItem(f.Name.Replace(".n3", ""), f.FullName));
            }
            if (ListBox1.Items.Count > 0)
            {
                ListBox1.Visible = true;
                Button1.Visible = false;
                TextBox1.Visible = false;
                GridView1.Visible = true;
            }
            else
            {
                ListBox1.Visible = false;
                Button1.Visible = true;
                TextBox1.Visible = true;
                GridView1.Visible = false;
            }
        }
        else
        {
            ListBox1.Visible = false;
            Button1.Visible = true;
            TextBox1.Visible = true;
            GridView1.Visible = false;
        }

    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Query query;
        XmlDocument xmldoc;
        DataTable dt = new DataTable();
        PrintQuerySink psink = new PrintQuerySink();

        string datafile = ListBox1.SelectedValue.ToString();
        string str = string.Empty;
        dt.Columns.Add("Name");
        dt.Columns.Add("Disease");
        dt.Columns.Add("Symptom");
        dt.Columns.Add("Medication");

        str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
    "SELECT distinct ?dis ?symp ?medi  \n " +
    "from <" + ListBox1.SelectedValue.ToString() + ">\n " +
    " where \n" +
   "{\n" +
   " ?Disease table:disease ?dis.\n" +
   " ?dis table:symptoms ?sym. \n" +
   " ?dis table:medication ?med. \n" +
   "?dis table:disease-name ?dise.\n" +
    "?sym table:symp-name ?symp.\n" +
    "?med table:med-name ?medi.\n }";
        query = new SparqlEngine(str);
        MemoryStore data = new MemoryStore();
        data.Import(new N3Reader(datafile));
        psink._pName = ListBox1.SelectedValue.ToString().Replace(".n3", "").Replace(@"C:\PatientOWLFiles\", "");
        query.Run(data, psink);


        if (psink.list.Count > 0)
        {
            GridView1.DataSource = null;
            Result r = new Result();
            r.R = psink.list;
            GridView1.DataSource = psink.list;
            GridView1.Visible = true;
            GridView1.DataBind();
            lblMessage.Visible = false;
        }
        else
        {
            lblMessage.Text = "No records found";
            GridView1.Visible = false;
            lblMessage.Visible = true;
            dt = new DataTable();
        }


    }
}