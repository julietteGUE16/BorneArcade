using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class dataBase : MonoBehaviour
{
 private string dbName = "URI=file:Score.db";

void Start (){

    CreateDB();

    //AddScore("Melaine",30);

    //AddScore("Nathan",60);

    //AddScore("Juliette",1);

   

    //todo 
    //DisplayScore();

}

public void CreateDB(){     

    using (var connection = new SqliteConnection(dbName)){
        connection.Open();
        using (var command = connection.CreateCommand())
        {

            command.CommandText = "CREATE TABLE IF NOT EXISTS score (name VARCHAR(20), total INT);";
            command.ExecuteNonQuery();
        }

        connection.Close();



    }
}

public void AddScore(string name, int score){
    using (var connection = new SqliteConnection(dbName))
    {

        connection.Open();

        using (var command = connection.CreateCommand()){

            command.CommandText = "INSERT INTO score (name, total) VALUES ('" +  name + "', '" + score + "');";
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
}

public void DisplayScore (){
    using (var connection = new SqliteConnection(dbName)){
        connection.Open();

        using (var command = connection.CreateCommand()){
            command.CommandText = "SELECT * FROM score;";


            using (IDataReader reader = command.ExecuteReader()){

                while (reader.Read())

                Debug.Log("Name: " + reader["name"] + "\tScore: "+ reader["total"]);

                reader.Close();
            }


        }
        connection.Close();



    }


}


}