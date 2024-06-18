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
    private readonly string _connectionString;

    public MongoDbConnection(string connectionString)
    {
        _client = new MongoClient(connectionString);
        _connectionString = connectionString;
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
    public void AddDoctor(BsonDocument doctor)
    {
        if (_database == null)
        {
            MessageBox.Show("No database selected. Please select a database first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            var collection = _database.GetCollection<BsonDocument>("doctors"); // Replace 'test' with your actual collection name
            collection.InsertOne(doctor);
            MessageBox.Show("Doctor added successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to add doctor: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    public void AddPrescriptionsCollection()
    {
        if (_database == null)
        {
            MessageBox.Show("No database selected. Please select a database first.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            // Check if the collection already exists
            var filter = new BsonDocument("name", "Prescriptions");
            var collections = _database.ListCollections(new ListCollectionsOptions { Filter = filter });
            if (collections.Any())
            {
                MessageBox.Show("The 'Prescriptions' collection already exists.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Create the collection
            _database.CreateCollection("Prescriptions");
            MessageBox.Show("The 'Prescriptions' collection has been created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, insert an initial document into the collection
            var prescriptionsCollection = _database.GetCollection<BsonDocument>("Prescriptions");

        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while creating the 'Prescriptions' collection: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }



    }
    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        if (_database == null)
        {
            throw new InvalidOperationException("No database selected.");
        }
        return _database.GetCollection<T>(collectionName);
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
