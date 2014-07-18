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
using System.Xml;
using System.IO;
using SemWeb;

public partial class Patient_Consult : System.Web.UI.Page
{
    private XmlDocument xmldoc;
    DataTable dt = new DataTable();
    ArrayList a = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Master.DataFromPageLabelControl("Patient");
        }

    }
    protected void myWizard_NextButtonClick(object sender, System.Web.UI.WebControls.WizardNavigationEventArgs e)
    {
        Query query;
        string queryfile = @"C:\Query.txt";
        string datafile = @"C:\KLM11.n3";
        string str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
        "SELECT distinct ?name ?symp   \n " +
        "FROM <C:/KLM11.owl> \n " +
        " where \n" +
       "{\n" +
       " ?Disease table:disease ?name.\n" +
        " ?Disease table:symptoms ?symp.\n" +
        " ?Disease table:classification ?class.\n" +
      " ?class table:class-name \"" + RadioButtonList1.SelectedItem.Text + "\" }\n";

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


        dt.Columns.Add("Disease");
        dt.Columns.Add("Symptoms");
        query.Run(data, stringWriter1);
        //Response.Write(stringWriter1.ToString());

        FileStream fs = new FileStream("C:\\temp\\xmltest3.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        xmldoc = new XmlDocument();
        xmldoc.Load(fs);
        XmlNodeList xmlnode = xmldoc.GetElementsByTagName("binding");
        Console.WriteLine("Here is the list of catalogs\n\n");

        for (int i = 0; i < xmlnode.Count; i++)
        {

            XmlAttributeCollection xmlattrc = xmlnode[i].Attributes;

            //XML Attribute Name and Value returned
            //Example: <Book id = "001">




            //First Child of the XML file - Catalog.xml - returned
            //Example: <Author>Mark</Author>

            dt.Rows.Add(xmlnode[i].NextSibling.InnerText.Replace("http://www.owl-ontologies.com/Ontology1183162121.owl#", ""), xmlnode[i].InnerText.Replace("http://www.owl-ontologies.com/Ontology1183162121.owl#", ""));
            i = i + 1;

        }


        fs.Close();

        str = string.Empty;
        str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
      "SELECT distinct  ?symp   \n " +
      "FROM <C:/KLM11.owl> \n " +
      " where \n" +
     "{\n" +
     " ?Disease table:disease ?name.\n" +
      " ?Disease table:symptoms ?symp.\n" +
      " ?Disease table:classification ?class.\n" +
    " ?class table:class-name \"" + RadioButtonList1.SelectedItem.Text + "\" }\n";

        // Response.Write("Catalog Finished");
        query = new SparqlEngine(str);
        data = new MemoryStore();
        data.Import(new N3Reader(datafile));
        PrintQuerySink psink = new PrintQuerySink();
        query.Run(data, psink);


        Question.Text = "Do you have " + psink.al[0].ToString() + "?";
        a = new ArrayList();
        Session["array"] = dt;
        processQuestions();
        Session["item"] = 0;
        Session["a"] = a;
        Session["arraylist"] = psink.al;
        GridView1.DataSource = null;


        //foreach (string s in psink.array)
        //{
        //    CheckBoxList1.Items.Add(new ListItem(s));
        //}
        //CheckBoxList1.
    }

    public void processQuestions()
    {



    }



    public class PrintQuerySink : QueryResultSink
    {
        public ArrayList al = new ArrayList();


        public override bool Add(VariableBindings result)
        {
            //dt.Columns.Add("Disease");
            //dt.Columns.Add("Symptoms");

            foreach (Variable var in result.Variables)
            {
                if (var.LocalName != null && result[var] != null)
                {

                    //if (var.LocalName == "name")

                    al.Add(result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#", "").Replace(">", ""));

                    //if(var.LocalName=="symp")
                    //    row[1]=(result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#","")).Replace(">","");
                    //         dt.Rows.Add((result[var].ToString().Replace("<http://www.owl-ontologies.com/Ontology1183162121.owl#","")).Replace(">",""));
                }
                Console.WriteLine();
            }


            return true;
        }
    }



    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        WizardStepType t = new WizardStepType();
        string result = string.Empty;
        //if (Convert.ToInt32(Session["item"]) <((DataTable)Session["array"]).Rows.Count)
        //{
        //    Question.Text = "Do you have " +((DataTable)Session["array"]).Rows[Convert.ToInt32(Session["item"])][1].ToString()+"?";
        //    Session["item"] = Convert.ToInt32(Session["item"])+1;
        //    RadioButtonList2.Items.Clear();
        //    RadioButtonList2.Items.Add(new ListItem("Yes"));
        //    RadioButtonList2.Items.Add(new ListItem("No"));
        //}
        if (Session["array"] != null)
        {
            if (RadioButtonList2.SelectedItem.Text == "Yes")
            {
                ((ArrayList)Session["a"]).Add("'" + ((ArrayList)Session["arraylist"])[Convert.ToInt32(Session["item"])].ToString() + "'");
                string expr = string.Empty;
                foreach (string items in ((ArrayList)Session["a"]))
                {
                    expr = expr + items + ",";

                }
                //if(expr!=string.Empty)
                // expr="Symptoms in ("+expr.Remove(expr.Length - 1)+") and";

                expr = "Symptoms in( '" + ((ArrayList)Session["arraylist"])[Convert.ToInt32(Session["item"])].ToString() + "') and";
                DataView dv;
                if (GridView1.Rows.Count > 0)
                {
                    string expr1 = string.Empty;

                    foreach (GridViewRow r in GridView1.Rows)
                    {
                        expr1 = expr1 + "'" + r.Cells[0].Text + "',";

                    }
                    expr1 = expr + " Disease in (" + expr1.Remove(expr1.Length - 1) + ")";
                    dv = new DataView(((DataTable)Session["array"]), expr1, "", DataViewRowState.CurrentRows);
                }
                else
                {
                    expr = expr.Remove(expr.Length - 3);
                    dv = new DataView(((DataTable)Session["array"]), expr, "", DataViewRowState.CurrentRows);
                }



                DataTable dt2 = dv.ToTable();

                // foreach (DataRowView drv in dv)

                //{

                //    value = (int)drv["column1"];

                //   }


                //  DataRow[] foundrows = ((DataTable)Session["array"]).Select("Symptoms like '" + ((DataTable)Session["array"]).Rows[Convert.ToInt32(Session["item"])][1].ToString() + "'");


                if (dt2.Rows.Count > 0)
                {
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
                    //   GridView1.Columns[1].Visible = false;
                    if (GridView1.Rows.Count == 1)
                    {
                        t = myWizard.WizardSteps[2].StepType;
                        if (t == WizardStepType.Complete)
                        {
                            lblName.Text = GridView1.Rows[0].Cells[0].Text;

                            Query query;
                            string queryfile = @"C:\Query.txt";
                            string datafile = @"C:\KLM11.n3";
                            string str = "PREFIX table:<http://www.owl-ontologies.com/Ontology1183162121.owl#> \n " +
                            "SELECT distinct ?med  \n " +
                            "FROM <C:/KLM11.N3> \n " +
                            " where \n" +
                           "{\n" +
                           " ?Disease table:disease ?name.\n" +
                            " ?Disease table:symptoms ?symp.\n" +
                            " ?Disease table:classification ?class.\n" +
                          " ?class table:class-name \"" + RadioButtonList1.SelectedItem.Text + "\". \n" +
                          "?name table:disease-name ?nam.\n" +
                          " Filter regex(?nam, \"" + GridView1.Rows[0].Cells[0].Text + "\",\"i\"). \n " +
                          "?name table:medication ?med.\n }";

                            TextWriter stringWriter = new StringWriter();
                            stringWriter.Write(str);


                            query = new SparqlEngine(str);
                            MemoryStore data = new MemoryStore();
                            data.Import(new N3Reader(datafile));

                            PrintQuerySink psink = new PrintQuerySink();
                            query.Run(data, psink);
                            foreach (string s in psink.al)
                                result = result + s + ",";
                            if (result != string.Empty)
                                result = result.Remove(result.Length - 1);

                            //ListBox1.DataSource = psink.al;
                            //ListBox1.DataBind();

                        }


                    }
                    // GridView1.Columns[1].Visible = false;
                }


            }

            if (t != WizardStepType.Complete)
            {

                if (Convert.ToInt32(Session["item"]) < ((ArrayList)Session["arraylist"]).Count - 1)
                {

                    Session["item"] = Convert.ToInt32(Session["item"]) + 1;
                    RadioButtonList2.Items[0].Selected = false;
                    RadioButtonList2.Items[1].Selected = false;
                    Question.Text = "Do you have " + ((ArrayList)Session["arraylist"])[Convert.ToInt32(Session["item"])].ToString() + "?";




                }
            }
            else
            {


                Response.Redirect("~/Patient/DiagResult.aspx?dis='" + GridView1.Rows[0].Cells[0].Text + "' &med='" + result + "'");

            }
        }
    }
}
