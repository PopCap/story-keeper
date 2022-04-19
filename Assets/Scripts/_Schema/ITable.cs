using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITable
{
    string CreateTable();

    /**
     * Should add helper function to delete children foreign
     * relations to clean the database of unused information.
     */
    string DeleteRow(int id);

    string InsertRow(List<string> values);

    /**
     * Pass all entries of row (even those that haven't changed)
     * excluding certain timestamp related values so that generic
     * implementation can be used for all schema.
     * I understand this probably isn't the most efficient but it
     * should be fine.
     */
    string UpdateRow(int id, List<string> values);
}
