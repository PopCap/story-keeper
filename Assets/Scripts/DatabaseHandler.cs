using Mono.Data.Sqlite;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

/**
 * This class handles the generation of our tables, as well as our queries and commands.
 * Singleton and thread safe.
 */
public sealed class DatabaseHandler
{
    private static DatabaseHandler instance = null;
    private static readonly object padlock = new object();

    private List<ITable> schemas;
    private SqliteConnection db;
    private SqliteCommand command;
    private string databasePath;

    /**
     * Make sure order of Table enum fields same as order of Concrete ITable Implementations
     * added to the schemas list.
     */
    enum Table
    {
        CAMPAIGN,
        SESSION,
        SESSION_NOTE,
        TAG
    }

    private DatabaseHandler() {}

    public static DatabaseHandler Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new DatabaseHandler();
                    instance.InitializeDatabase();
                    Debug.Log("Database Handler instanced and Initialized");
                }
                return instance;
            }
        }
    }

    private void InitializeDatabase()
    {
        // ex. C:\Users\<user>\AppData\LocalLow\DefaultCompany\Story Keeper\StoryKeeper.sqlite
        databasePath = "Data Source=" + Application.persistentDataPath + "/StoryKeeper.sqlite";

        try
        {
            db = new SqliteConnection(databasePath);
            db.Open();
        }
        catch (System.Exception exc)
        {
            Debug.Log(exc);
        }

        command = db.CreateCommand();

        LoadSchemas();
        CreateTables();
    }

    public void CloseDatabase()
    {
        db.Close();
    }

    public int ExecuteNonQuery(string commandText)
    {
        if (string.IsNullOrEmpty(commandText))
        {
            Debug.Log("Command text is null or empty");
            return -1;
        }

        command.CommandText = commandText;
        return command.ExecuteNonQuery();
    }

    public List<AbstractTable> ExecuteQuery(AbstractTable schema, string queryText)
    {
        if (schema == null)
        {
            Debug.Log("Null schema passed for query type");
            return null;
        }

        if (string.IsNullOrEmpty(queryText))
        {
            Debug.Log("Query text is null or empty");
            return null;
        }

        command.CommandText = queryText;
        SqliteDataReader reader = command.ExecuteReader();
        List<AbstractTable> queryResults = schema.BuildQueryResults(reader);
        Debug.Log("Returning query results of: " + queryText);
        foreach (AbstractTable result in queryResults)
        {
            Debug.Log(result.ToString());
        }
        return queryResults;
    }

    private void CreateTables()
    {
        foreach (ITable schema in schemas)
        {
            command.CommandText = schema.CreateTable();
            command.ExecuteNonQuery();
        }
    }

    private void LoadSchemas()
    {
        schemas = new List<ITable>();
        schemas.Add(new Campaign());
        schemas.Add(new Session());
        schemas.Add(new SessionNote());
        schemas.Add(new Tag());
    }
}