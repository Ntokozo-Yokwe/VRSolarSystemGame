using System.Collections.Generic;
using UnityEngine;

public abstract class Iterator <T> : MonoBehaviour
{
    [Tooltip("Item list that will be iterated over")]
    public List<T> list;

    /// <summary>
    /// The currently used item's index
    /// </summary>
    internal int index;

    public virtual void Change(int i)
    {
        
    }

    /// <summary>
    /// Moves to the next item in the list
    /// </summary>
    public void Next()
    {
        int i = index + 1;

        if (i >= list.Count)
        {
            i = 0;
        }

        Change(i);
    }


    /// <summary>
    /// Moves to the previous item in the list
    /// </summary>
    public void Previous()
    {
        int i = index - 1;

        if (i < 0 )
        {
            i = list.Count-1;
        }

        Change(i);
    }
}
