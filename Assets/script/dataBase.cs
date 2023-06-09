using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;


/*
Ce script permet de créer une base de données SQLite et d'y insérer des données.
On y retrouve également toutes le fonctions par rapport au joueur ou à la partie
*/

public class DataBase : MonoBehaviour
{
    private string dbName = "URI=file:BorneArcade.db";
    GameSet gameSet;

    int idPlayer=0;
    string namePlayer="";
    float speedPlayer=0f;
    float speedRotationPlayer=0f;
    float powerFire=0f;
    float delayFire=0f;
    public bool heExist = true;
 
 

    void Start (){

        DontDestroyOnLoad(gameObject);
        gameSet = GameObject.FindObjectOfType<GameSet>();
        CreateDB();    

    }

    public void CreateDB(){     

        using (var connection = new SqliteConnection(dbName)){
            connection.Open();
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "CREATE TABLE IF NOT EXISTS Player (idPlayer INT, name VARCHAR(20) ,speedPlayer FLOAT,speedRotationPlayer FLOAT,powerFire FLOAT,delayFire FLOAT);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Game (idPartie INT,idPlayer1 INT,idPlayer2 INT,score1 INT,score2 INT, rank INT);";
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
                            gameSet.idPlayer1 = playerID;
                        
                        
                        }else {
                            gameSet.idPlayer2 = playerID;
                        
                            
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

    public string GetPlayerPseudo(int playerId)
    {
        string playerPseudo = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT name FROM Player WHERE idPlayer = " + playerId + ";";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        playerPseudo = reader.GetString(0);
                    }
                }
            }

            connection.Close();
        }

        return playerPseudo;
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
                        heExist  = false;
                        
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
                            gameSet.idPlayer2 = idPlayer;
                            gameSet.namePlayer2 = namePlayer;
                            gameSet.speedPlayer2 = speedPlayer;
                            gameSet.speedRotationPlayer2 = speedRotationPlayer;
                            gameSet.powerFire2 = powerFire;
                            gameSet.delayFire2 = delayFire;
                        }
                    } else {
                        if(!isPlayer2){
                            gameSet.idPlayer1 = -1;
                            gameSet.namePlayer1 = "";
                            gameSet.speedPlayer1 = 1f;
                            gameSet.speedRotationPlayer1 = 1f;
                            gameSet.powerFire1 = 1f;
                            gameSet.delayFire1 = 1f;
                        }else {
                            gameSet.idPlayer2 = -1;
                            gameSet.namePlayer2 = "";
                            gameSet.speedPlayer2 = 1f;
                            gameSet.speedRotationPlayer2 = 1f;
                            gameSet.powerFire2 = 1f;
                            gameSet.delayFire2 = 1f;
                        }
                    }
                }
            }

            connection.Close();
        }
    }

    public void AddGame(int idPlayer1, int idPlayer2, int score1, int score2, int rank)
    {

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            gameSet.idPartie = GetGameCount() + 1;

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Game (idPartie, idPlayer1, idPlayer2, score1, score2, rank) VALUES (@idPartie, @idPlayer1, @idPlayer2, @score1, @score2, @rank);";
                command.Parameters.AddWithValue("@idPartie", GetGameCount() + 1);
                command.Parameters.AddWithValue("@idPlayer1", idPlayer1);
                command.Parameters.AddWithValue("@idPlayer2", idPlayer2);
                command.Parameters.AddWithValue("@score1", score1);
                command.Parameters.AddWithValue("@score2", score2);
                command.Parameters.AddWithValue("@rank", rank);
                command.ExecuteNonQuery();
            }

            

            connection.Close();
        }
    }

    public string GetPlayerName(int playerId)
    {
        string playerName = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                
                command.CommandText = "SELECT name FROM Player WHERE idPlayer = " + playerId + ";";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        playerName = reader.GetString(0);
                    }
                }
            }

            connection.Close();
        }

        return playerName;
    }

    public List<int> GetTopGames(int count)
    {
        List<int> topGames = new List<int>();

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Requête pour récupérer les meilleurs jeux triés par ordre décroissant de rank avec une limite spécifiée
                command.CommandText = "SELECT idPartie FROM Game ORDER BY rank ASC LIMIT @count;";
                command.Parameters.AddWithValue("@count", count);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int gameId = reader.GetInt32(0);
                        topGames.Add(gameId);
                    }
                }
            }

            connection.Close();
        }

        return topGames;
    }

    public GameInfo GetGameInfo(int gameId)
    {
        GameInfo gameInfo = null;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT idPartie, idPlayer1, idPlayer2, score1, score2, rank FROM Game WHERE idPartie = @gameId;";
                command.Parameters.AddWithValue("@gameId", gameId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idPartie = reader.GetInt32(0);
                        int idPlayer1 = reader.GetInt32(1);
                        int idPlayer2 = reader.GetInt32(2);
                        int score1 = reader.GetInt32(3);
                        int score2 = reader.GetInt32(4);
                        int rank = reader.GetInt32(5);

                        // Créer un objet GameInfo avec les informations de la partie, y compris le classement (rank)
                        gameInfo = new GameInfo(idPartie, idPlayer1, idPlayer2, score1, score2, rank);
                    }
                    else
                    {
                    
                    }
                }
            }

            connection.Close();
        }

        return gameInfo;
    }

    public int GetGameCount()
    {
        int gameCount = 0;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Game;";
                gameCount = Convert.ToInt32(command.ExecuteScalar());
            }

            connection.Close();
        }

        return gameCount;
    }
    public void UpdateGameRankInDatabase(int newRank, int idPartie)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            // Récupérer la liste des identifiants des parties ayant un rang supérieur ou égal à newRank
            List<int> gameIds = GetGameIdsWithRankGreaterThan(newRank, idPartie);

            // Mettre à jour les parties avec un classement supérieur ou égal au nouveau classement
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Game SET rank = rank + 1 WHERE idPartie = @gameId;";
                command.Parameters.AddWithValue("@gameId", 0);
                foreach (int gameId in gameIds)
                {
                    
                    command.Parameters["@gameId"].Value = gameId;
                    command.ExecuteNonQuery();
                }
            }

            connection.Close();
        }
    }

    public List<int> GetGameIdsWithRankGreaterThan(int rank, int idPartie)
    {
        List<int> gameIds = new List<int>();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT idPartie FROM Game WHERE rank >= @rank AND idPartie != @idPartie;";
                command.Parameters.AddWithValue("@rank", rank);
                command.Parameters.AddWithValue("@idPartie", idPartie);
                using (var reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        int gameId = reader.GetInt32(0);
                        gameIds.Add(gameId);
                    }
                }
            }

            connection.Close();
        }

        return gameIds;
    }

    public int CalculateGameRank(int score1, int score2)
    {
        int rank = 1;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            // Sélectionner le meilleur score entre score1 et score2
            int bestScore = Math.Max(score1, score2);

        

        

        
                using (var command = connection.CreateCommand())
                {
                    // Compter le nombre de parties avec un meilleur score
                    command.CommandText = "SELECT COUNT(*) FROM Game WHERE (CASE WHEN score1 >= score2 THEN score1 ELSE score2 END) > @bestScore;";
                    command.Parameters.AddWithValue("@bestScore", bestScore);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                
                    rank += count;
                    
                
            }

            connection.Close();
        }

        return rank;
    }

    public void DeleteAllGames()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            // Supprimer toutes les entrées de la table "Game"
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM Game;";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

}

public class GameInfo
{
    public int idPartie;
    public int idPlayer1;
    public int idPlayer2;
    public int score1;
    public int score2;
    public int rank;

    public GameInfo(int idPartie, int idPlayer1, int idPlayer2, int score1, int score2, int rank)
    {
        this.idPartie = idPartie;
        this.idPlayer1 = idPlayer1;
        this.idPlayer2 = idPlayer2;
        this.score1 = score1;
        this.score2 = score2;
        this.rank = rank;
    }
}