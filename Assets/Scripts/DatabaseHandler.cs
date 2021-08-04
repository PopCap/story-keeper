using Mono.Data.Sqlite;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

/**
 * This class handles the generation of our tables, as well as our queries and commands.
 */
public class DatabaseHandler
{
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

    public DatabaseHandler()
    {
        databasePath = "Data Source=" + Application.persistentDataPath + "/StoryKeeper.sqlite";

        try
        {
            db = new SqliteConnection(databasePath);
            db.Open();
        } catch (System.Exception exc)
        {
            Debug.Log(exc);
        }
        
        command = db.CreateCommand();

        LoadSchemas();
        CreateTables();
        command.CommandText = schemas[(int)Table.CAMPAIGN].InsertRow(new List<string>() { "Terra", "Dylan" });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.SESSION].InsertRow(new List<string>() { "1" });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.SESSION_NOTE].InsertRow(new List<string>() { "1", "Test note." });
        command.ExecuteNonQuery();
        command.CommandText = schemas[(int)Table.TAG].InsertRow(new List<string>() { "1", "Tag Test" });
        command.ExecuteNonQuery();
        db.Close();
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