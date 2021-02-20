//using system;
//using system.collections.generic;
//using system.configuration;
//using system.data;
//using system.linq;
//using system.threading.tasks;
//using dapper;
//using microsoft.data.sqlite;
//using quicktype;

//namespace webapplication1
//{
    //public class SQliteDbAccess
    //{
    //    public static persondeatil loadperson()
    //    {
    //        using (idbconnection cnn = new sqliteconnection(loadconnectionstring()))
    //        {
    //            var output = cnn.query("select * from persondetail", dynamicparameters());
    //            //return output.toarray();

    //        }
    //    }

    //    private static object dynamicparameters()
    //    {
    //        throw new notimplementedexception();
    //    }

    //    public static void saveperson(persondeatil person)
    //    {
    //        using (idbconnection cnn = new sqliteconnection(loadconnectionstring()))
    //        {

    //        }
    //    }


    //    private static string loadconnectionstring(string id = "default")
    //    {
    //        return configurationmanager.connectionstrings[id].connectionstring;
    //    }

    //}

