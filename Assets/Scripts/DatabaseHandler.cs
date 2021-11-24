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
        // ex. C:\Users\<user>\AppData\LocalLow\DefaultCompany\Story Keeper
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

        DoTheThings();
    }

    public void DoTheThings()
    {
        /*        command.CommandText = schemas[(int)Table.CAMPAIGN].InsertRow(new List<string>() { "Terra", "Dylan" });
                command.ExecuteNonQuery();
                command.CommandText = schemas[(int)Table.SESSION].InsertRow(new List<string>() { "1" });
                command.ExecuteNonQuery();
                command.CommandText = schemas[(int)Table.SESSION_NOTE].InsertRow(new List<string>() { "1", "Test note." });
                command.ExecuteNonQuery();
                command.CommandText = schemas[(int)Table.TAG].InsertRow(new List<string>() { "1", "Tag Test" });
                command.ExecuteNonQuery();*/
        command.CommandText = schemas[(int)Table.CAMPAIGN].UpdateRow(1, new List<string>() { "Terra", "New DM" });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.CAMPAIGN].InsertRow(new List<string>() { "Blabla", "Bob" });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.CAMPAIGN].InsertRow(new List<string>() { "DontDelete", "Terry" });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.CAMPAIGN].DeleteRow(2);
        command.ExecuteNonQuery();
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