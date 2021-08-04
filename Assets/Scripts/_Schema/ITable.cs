using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITable
{
    // should be implemented as static
    string CreateTable();
    string InsertRow(List<string> values);
}
