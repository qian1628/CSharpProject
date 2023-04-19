// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Dynamic;
using System.Text.RegularExpressions;


while (true)
{

    int a = 1;//Decide test type
    VerifyBreakpoint(); //First function of Main
    VerifyEE();//Second function of Main
    VerifyRecursion(10);
    VerifyVisualize();

    var values = await DownloadWebAsync(100);
    Main_orig(values);

    if (a == 10)
    {
        Foo().Wait();//Verify exception
    }
    VerifyException();

    Console.WriteLine("Hello, World!");
}

static async Task<float[]> DownloadWebAsync(int arrayLength)
{
    var values = await WaitArrayData(arrayLength);

    await Task.Delay(2000);

    return values;//BeforeEnteringFirstAsyncCall
}

static async Task<float[]> WaitArrayData(int arrayLength)
{
    var task1 = Task.Factory.StartNew(() =>
    {
        float[] values = Enumerable.Range(0, arrayLength).Select(i => (float)i / 10).ToArray();
        return values;
    });

    return await task1;
}

static int Main_orig(float[] values)
{
    int valuesLength = values.Length;

    return valuesLength;
}

static void VerifyBreakpoint()
{//First line of VerifyBreakpoint
    int iGlobal = 0;
    for (int i = 0; i < 50; i++)//The beginning of the for loop
    {
        iGlobal++; //Variable increment 
        i++;
    }
}//The end of VerifyBreakpoint

static async Task Foo()
{
    await GenException();
}

static async Task<string> GenException()
{
    await Task.Delay(1000);
    return string.Format("{1}", "abc");
}

static void VerifyVisualize()
{
    string ht = "<html><body>hello world!</body><html>";
    string xml2 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<configuration>\r\n    <startup> \r\n        <supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.6.1\" />\r\n    </startup>\r\n</configuration>";
    string json = "{​​​​​​​\r\n    \"name\":\"中国\",\r\n    \"province\":[\r\n    {​​​​​​​\r\n       \"名字\":\"黑龙江\",\r\n        \"城市\":{​​​​​​​\r\n            \"城市\":[\"海冰\",\"长春\"]\r\n        }​​​​​​​\r\n     }​​​​​​​,\r\n      {​​​​​​​\r\n        \"名字\": \"广东\",\r\n        \"城市\": {​​​​​​​\r\n          \"城市\": [ \"广州\", \"深圳\", \"厦门\" ]\r\n        }​​​​​​​\r\n      }​​​​​​​,\r\n    {​​​​​​​\r\n        \"名字\":\"陕西\",\r\n      \"城市\": {​​​​​​​\r\n        \"城市\": [ \"西安\", \"延安\" ]\r\n      }​​​​​​​\r\n    }​​​​​​​,\r\n    {​​​​​​​\r\n        \"名字\":\"甘肃\",\r\n      \"城市\": {​​​​​​​\r\n        \"城市\": [ \"兰州\" ]\r\n      }​​​​​​​\r\n    }​​​​​​​\r\n]\r\n}​​​​​​​\r\n";

    string js = "{\n  \"dsiif_ecnt\" : {\n    \"crc_err\" : 0,\n    \"overrun_err\" : 0,\n    \"size_err\" : 0,\n    \"bus_err\" : 0,}\n }"; //correct json
    string js1 = "{\n  \"dsiif_ecnt\" : {\n    \"crc_err\" : 0,\n    \"overrun_err\" : 0,\n    \"size_err\" : 0,\n    \"bus_err\" : "; //wrong json

    var dt = new DataSet("my data set");
    dt.Tables.Add("my table");
    dt.Tables[0].Columns.Add("column0", System.Type.GetType("System.String"));
    DataColumn dc = new DataColumn("column1", System.Type.GetType("System.Boolean"));
    dt.Tables[0].Columns.Add("column2", System.Type.GetType("System.Int32"));
    dt.Tables[0].Columns.Add("column3", System.Type.GetType("System.Guid"));
    dt.Tables[0].Columns.Add(dc);
    Guid guid = new Guid("00000000-0000-0000-0000-000000000000");
    for (int i = 0; i < 5000; i++)
    {
        DataRow dr = dt.Tables[0].NewRow();
        dr["column0"] = "AX_" + i;
        dr["column1"] = true;
        dr["column2"] = i;
        dr["column3"] = guid;
        dt.Tables[0].Rows.Add(dr);
    }

    dt.Tables.Add("my table2");
    dt.Tables[1].Columns.Add("column0", System.Type.GetType("System.String"));
    dc = new DataColumn("column1", System.Type.GetType("System.Boolean"));
    dt.Tables[1].Columns.Add("column2", System.Type.GetType("System.Int32"));
    dt.Tables[1].Columns.Add("column3", System.Type.GetType("System.Guid"));
    dt.Tables[1].Columns.Add(dc);
    //Guid guid2 = new Guid("00000000-0000-0000-0000-000000000000");
    for (int i = 0; i < 5000; i++)
    {
        DataRow dr = dt.Tables[1].NewRow();
        dr["column0"] = "AX_" + i;
        dr["column1"] = true;
        dr["column2"] = i;
        dr["column3"] = guid;
        dt.Tables[1].Rows.Add(dr);
    }

    DataTable dt1 = new DataTable("Table_AX");
    dt1.Columns.Add("column0", System.Type.GetType("System.String"));
    DataColumn dc1 = new DataColumn("column1", System.Type.GetType("System.Boolean"));
    dt1.Columns.Add("column2", System.Type.GetType("System.Int32"));
    dt1.Columns.Add("column3", System.Type.GetType("System.Guid"));
    dt1.Columns.Add(dc1);
    Guid guid1 = new Guid("00000000-0000-0000-0000-000000000000");
    for (int i = 0; i < 50; i++)
    {
        DataRow dr = dt1.NewRow();
        dr["column0"] = "AX_" + i;
        dr["column1"] = true;
        dr["column2"] = i;
        dr["column3"] = guid;
        dt1.Rows.Add(dr);
    }
    DataRow dr1 = dt1.NewRow();
    dt1.Rows.Add(dr1);
    int a = 10;
}


static int VerifyEE()
{
    List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
    IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);
    foreach (string fruit in query)
    {
        Console.WriteLine(fruit);
    }

    float[] values = Enumerable.Range(0, 10).Select(i => (float)i / 10).ToArray();

    object[] pList = new object[] { 1, "one", 2, "two", 3, "three" };
    var query1 = pList.OfType<string>();
    dynamic expObj = new ExpandoObject();
    expObj.FirstName = "Daffy";
    expObj.LastName = "Duck";

    string inLocal = "Change";

    Dictionary<string, string> mygroup = new Dictionary<string, string>() { { "Hannah","Zhang"},{ "Alex","Yao"},{ "Alisa","Zhang"}
                ,{ "Nelson","Yan"},{ "Richard","Zeng"},{ "Clarie","Kang"},{ "Qian","Wang"},{ "Serena","Wang"},{ "Maggie","Zhang"},{ "Cherry","Wu"}
                ,{ "Lynn","Zhang"},{ "Grace","Dong"} };

    int inAutos = 10;

    return 0;//Last line of VerifyEE
}
static int VerifyRecursion(int m)
{
    if (m <= 1)
        return 1;
    return m * VerifyRecursion(m - 1);     //break inside function fib
}

static void VerifyException()
{
    try
    {
        throw new InvalidOperationException();
    }
    catch (Exception ex)
    {
    }

}
