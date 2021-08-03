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

        CreateTables();
        db.Close();
    }

    private void CreateTables()
    {
        LoadSchemas();
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