using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class dataBase : MonoBehaviour
{
 private string dbName = "URI=file:BorneArcade.db";
 gameSet gameSet;

    int idPlayer=0;
    string namePlayer="";
    float speedPlayer=0f;
    float speedRotationPlayer=0f;
    float powerFire=0f;
    float delayFire=0f;
 
 

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

public void AddPlayer(string playerName, float speedPlayer, float speedRotationPlayer, float powerFire, float delayFire , bool isPlayer2)
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

             
                    if(!isPlayer2){
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer1 = playerID;
                       /* gameSet.namePlayer1 = namePlayer;
                        gameSet.speedPlayer1 = speedPlayer;
                        gameSet.speedRotationPlayer1 = speedRotationPlayer;
                        gameSet.powerFire1 = powerFire;*/
                    }else {
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer2 = playerID;
                        /*gameSet.namePlayer2 = namePlayer;
                        gameSet.speedPlayer2 = speedPlayer;
                        gameSet.speedRotationPlayer2 = speedRotationPlayer;
                        gameSet.powerFire2 = powerFire;*/
                        
                    }
                
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
                     idPlayer = reader.GetInt32(0);
                     namePlayer = reader.GetString(1);
                     speedPlayer = reader.GetFloat(2);
                     speedRotationPlayer = reader.GetFloat(3);
                     powerFire = reader.GetFloat(4);
                     delayFire = reader.GetFloat(5);




                    
                    

                 

                    // Exemple : Afficher les valeurs dans la console
                }
                else
                {
                    idPlayer = -1;
                    // Le joueur n'existe pas encore, appeler la fonction AddPlayer pour l'ajouter à la base de données
                    AddPlayer(playerName, 1f, 1f, 1f, 1f, isPlayer2);
                }

                if(idPlayer != -1){
                    if(!isPlayer2){
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer1 = idPlayer;
                        gameSet.namePlayer1 = namePlayer;
                        gameSet.speedPlayer1 = speedPlayer;
                        gameSet.speedRotationPlayer1 = speedRotationPlayer;
                        gameSet.powerFire1 = powerFire;
                        gameSet.delayFire1 = delayFire;
                    }else {
                        // Le joueur existe déjà, récupérer les valeurs des colonnes de la base de données
                        gameSet.idPlayer2 = idPlayer;
                        gameSet.namePlayer2 = namePlayer;
                        gameSet.speedPlayer2 = speedPlayer;
                        gameSet.speedRotationPlayer2 = speedRotationPlayer;
                        gameSet.powerFire2 = powerFire;
                        gameSet.delayFire2 = delayFire;
                        
                    }
                }
            }
        }

        connection.Close();
    }
}


}