namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IConnection> connections = new List<IConnection>();
            string output = String.Empty;
            for(int i=0; i< 6; i++) 
            {
                connections.Add(Database.GetConnection());
                Console.WriteLine(connections[i].GetHashCode());
            }

            for(int i=0; i< 6; i++)
            {
                connections[i].Set(i, (char)(i+65));
            }

            for(int i=0; i< 6; i++)
            {
                for(int j=0; j< 6; j++)
                output += connections[i].Get(j);
                Console.WriteLine(output);
                output=String.Empty;
            }
        }
    }
}
