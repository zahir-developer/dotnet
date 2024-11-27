using AbstractApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Abstract Demo");

        var dataAccess = new List<DataAccess>()
        {
            new SqlDataAccess(),
            new SqliteDataAccess()
        };

        foreach (var item in dataAccess)
        {
           
            item.LoadData("Select * from table");
            item.SaveData("Insert into table");

            Console.WriteLine();
        }

        //Abstract class doesn't allow as Instantiate directly.
        //DataAccess da = new DataAccess();
        

    }
}