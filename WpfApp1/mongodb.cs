using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

public class MongoDbConnection
{
    private readonly IMongoClient _client;
    private IMongoDatabase _database;

    public MongoDbConnection(string connectionString)
    {
        _client = new MongoClient(connectionString);

        try
        {
            // Connect to the default database (optional)
            _database = _client.GetDatabase("test");
            Console.WriteLine("Connected to MongoDB successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to MongoDB: {ex.Message}");
            _database = null; // Ensure _database is null on connection failure
            throw; // Rethrow the exception to indicate a failure to connect
        }
    }

    public void ShowDatabases()
    {
        try
        {
            var databases = _client.ListDatabaseNames().ToList();
            if (databases.Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Databases in MongoDB:");
                foreach (var db in databases)
                {
                    sb.AppendLine(db);
                }
                MessageBox.Show(sb.ToString(), "Databases", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No databases found.", "Databases", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to retrieve databases: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public void UseDatabase(string databaseName)
    {
        try
        {
            _database = _client.GetDatabase(databaseName);
            MessageBox.Show($"Switched to database: {databaseName}", "Database Switch", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to switch to database '{databaseName}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public void ChangeUsername(string currentUsername, string newUsername, string collectionName)
    {
        if (_database == null)
        {
            MessageBox.Show("No database selected. Please select a database first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        var collection = _database.GetCollection<BsonDocument>(collectionName);

        try
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Username", currentUsername);
            var update = Builders<BsonDocument>.Update.Set("Username", newUsername);

            var result = collection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("Username updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update username. User not found or new username is the same as the current one.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
