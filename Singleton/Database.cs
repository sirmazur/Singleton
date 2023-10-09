using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Singleton.Database;

namespace Singleton
{
    public class Database
    {

        private char[] tab = new char[100];
        private static Database database = new Database();
        public static IConnection GetConnection()
        {
            return Connection.getInstance();
        }

        public class Connection : IConnection
        {
            private static List<IConnection> Connections = new List<IConnection>();
            public static IConnection getInstance()
            {
    
                if(Connections.Count() < 3)
                {
                    Connections.Add(new Connection());
                    return Connections.Last();
                }
                else
                {
                    IConnection temp = Connections.Last();
                    Connections[2] = Connections[0];
                    Connections[0] = Connections[1];
                    Connections[1] = temp;
                    return Connections.Last();
                }

            }

            public char Get(int indeks)
            {

                return database.tab[indeks];

            }

            public void Set(int indeks, char c)
            {

                database.tab[indeks] = c;

            }

            public int Length()
            {

                return database.tab.Count();

            }

        }
    }
}
