using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class dataBase : MonoBehaviour
{
 private string dbName = "URI=file:BorneArcade.db";
 gameSet gameSet;

 
 

void Start (){

    gameSet = GameObject.FindObjectOfType<gameSet>();
    CreateDB();

    

}

public void CreateDB(){     

    using (var connection = new SqliteConnection(dbName)){
        connection.Open();
        using (var command = connection.CreateCommand())
        {

            command.CommandText = "CREATE TABLE IF NOT EXISTS Player (idPlayer INT, name VARCHAR(20) ,speedPlayer FLOAT,speedRotationPlayer FLOAT,powerFire FLOAT,delayFire FLOAT);";
            command.ExecuteNonQuery();

            command.CommandText = "CREATE TABLE IF NOT EXISTS Game (idPartie INT,idPlayer1 INT,idPlayer2 INT,score1 INT,score2 INT);";
            command.ExecuteNonQuery();
        }


        connection.Close();



    }
}

public void AddPlayer(string playerName, float speedPlayer, float speedRotationPlayer, float powerFire, float delayFire)
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
            command.CommandText = "INSERT INTO Player (idPlayer, name, speedPlayer, speedRotationPlayer, powerFire, delayFire) VALUES (" + playerID + ", '" + playerName + "', " + speedPlayer + ", " + speedRotationPlayer + ", " + powerFire + ", " + delayFire  + ");";
            command.ExecuteNonQuery();
        }

        connection.Close();
    }
}

public void UpdatePlayer(int playerId, float newSpeedPlayer, float newSpeedRotationPlayer, float newPowerFire, float newDelayFire)
{
    using (var connection = new SqliteConnection(dbName))
    {
        connection.Open();

        using (var command = connection.CreateCommand())
        {
            command.CommandText = "UPDATE Player SET speedPlayer = @speedPlayer, speedRotationPlayer = @speedRotationPlayer, powerFire = @powerFire, delayFire = @delayFire WHERE idPlayer = @id";
            command.Parameters.AddWithValue("@speedPlayer", newSpeedPlayer);
            command.Parameters.AddWithValue("@speedRotationPlayer", newSpeedRotationPlayer);
            command.Parameters.AddWithValue("@powerFire", newPowerFire);
            command.Parameters.AddWithValue("@delayFire", newDelayFire);
            command.Parameters.AddWithValue("@id", playerId);

            command.ExecuteNonQuery();
        }

        connection.Close();
    }
}

public void FindPlayer(string playerName, bool isPlayer2)
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
                    if(!isPlayer2){
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer1 = reader.GetInt32(0);
                        gameSet.namePlayer1 = reader.GetString(1);
                        gameSet.speedPlayer1 = reader.GetFloat(2);
                        gameSet.speedRotationPlayer1 = reader.GetFloat(3);
                        gameSet.powerFire1 = reader.GetFloat(4);
                        gameSet.delayFire1 = reader.GetFloat(5);
                    }else {
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer2 = reader.GetInt32(0);
                        gameSet.namePlayer2 = reader.GetString(1);
                        gameSet.speedPlayer2 = reader.GetFloat(2);
                        gameSet.speedRotationPlayer2 = reader.GetFloat(3);
                        gameSet.powerFire2 = reader.GetFloat(4);
                        gameSet.delayFire2 = reader.GetFloat(5);
                    }
                    

                 

                    // Exemple : Afficher les valeurs dans la console
                }
                else
                {
                    // Le joueur n'existe pas encore, appeler la fonction AddPlayer pour l'ajouter à la base de données
                    AddPlayer(playerName, 0.1f, 0.2f, 0.2f, 0.2f);
                }
            }
        }

        connection.Close();
    }
}


}