using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTable : ITable
{
    public abstract List<AbstractTable> BuildQueryResults(SqliteDataReader reader);
    public abstract string CreateTable();
    public abstract string DeleteRow(int id);
    public abstract string InsertRow(List<string> values);
    public abstract string UpdateRow(int id, List<string> values);
}
