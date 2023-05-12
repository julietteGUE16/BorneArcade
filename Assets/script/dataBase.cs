using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class dataBase : MonoBehaviour
{
 private string dbName = "URI=file:Score.db";
 

void Start (){

    CreateDB();

    

}

public void CreateDB(){     

    using (var connection = new SqliteConnection(dbName)){
        connection.Open();
        using (var command = connection.CreateCommand())
        {

            command.CommandText = "CREATE TABLE IF NOT EXISTS Player (idPlayer INT, name VARCHAR(20) ,speedPlayer FLOAT,speedRotationPlayer FLOAT,powerFire FLOAT,delayFire FLOAT,speedFire FLOAT);";
            command.ExecuteNonQuery();

            command.CommandText = "CREATE TABLE IF NOT EXISTS Game (idPartie INT,idPlayer1 INT,idPlayer2 INT,score1 INT,score2 INT);";
            command.ExecuteNonQuery();
        }


        connection.Close();



    }
}

public void AddPlayer(string playerName, float speedPlayer, float speedRotationPlayer, float powerFire, float delayFire, float speedFire)
{
    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            // Récupérer la taille actuelle de la table "Player"
            command.CommandText = "SELECT COUNT(*) FROM Player;";
            int playerCount = Convert.ToInt32(command.ExecuteScalar());

            // Incrémenter l'ID du joueur en fonction de la taille de la table
            int playerID = playerCount + 1;

            // Insérer les données du joueur dans la table "Player"
            command.CommandText = "INSERT INTO Player (idPlayer, name, speedPlayer, speedRotationPlayer, powerFire, delayFire, speedFire) VALUES (" + playerID + ", '" + playerName + "', " + speedPlayer + ", " + speedRotationPlayer + ", " + powerFire + ", " + delayFire + ", " + speedFire + ");";
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

public void FindPlayer(string playerName)
{
    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            // Requête pour chercher le joueur par nom
            command.CommandText = "SELECT * FROM Player WHERE name = '" + playerName + "';";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                    int idPlayer = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    float speedPlayer = reader.GetFloat(2);
                    float speedRotationPlayer = reader.GetFloat(3);
                    float powerFire = reader.GetFloat(4);
                    float delayFire = reader.GetFloat(5);
                    float speedFire = reader.GetFloat(6);

                    // TODO: faire quelque chose des données

                    // Exemple : Afficher les valeurs dans la console
                    Debug.Log("Player Found - ID: " + idPlayer + ", Name: " + name + ", SpeedPlayer: " + speedPlayer + ", SpeedRotationPlayer: " + speedRotationPlayer + ", PowerFire: " + powerFire + ", DelayFire: " + delayFire + ", SpeedFire: " + speedFire);
                }
                else
                {
                    // Le joueur n'existe pas encore, appeler la fonction AddPlayer pour l'ajouter à la base de données
                    AddPlayer(playerName, 20f, 500f, 1f, 0.2f, 10f);
                }
            }
        }

        connection.Close();
    }
}


}