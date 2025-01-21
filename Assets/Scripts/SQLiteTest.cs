using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class SQLiteTest : MonoBehaviour
{
    void Start()
    {
        string dbPath = "URI=file:" + Application.persistentDataPath + "/test.db";

        using (IDbConnection dbConnection = new SqliteConnection(dbPath))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string query = "CREATE TABLE IF NOT EXISTS TestTable (id INTEGER PRIMARY KEY, name TEXT)";
                dbCommand.CommandText = query;
                dbCommand.ExecuteNonQuery();
                Debug.Log("Table créée avec succès !");
            }
        }
    }
}
