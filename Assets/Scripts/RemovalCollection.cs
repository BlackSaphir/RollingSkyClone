using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RemovalCollection<T> : List<T> {

    private List<T> pendingRemovals;

    public RemovalCollection()
    {
        pendingRemovals = new List<T>();
    }

    public void AddPendingRemoval(T item)
    {
        pendingRemovals.Add(item);
    }

    public void DeletePendingRemoval()
    {
        for (int i = 0; i < pendingRemovals.Count; i++)
        {
            Remove(pendingRemovals[i]);
        }
        pendingRemovals.Clear();
    }

	
}
