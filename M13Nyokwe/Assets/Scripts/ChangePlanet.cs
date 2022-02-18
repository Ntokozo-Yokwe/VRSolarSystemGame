using UnityEngine;

/// <summary>
/// Iterates over a game object list 
/// </summary>
public class ChangePlanet : Iterator <GameObject>
{
    // This script takes the methods and fields from Iterator class, it uses a list of Materials

    public override void Change(int i)
    {
        list[index].SetActive(false);
        list[i].SetActive(true);

        index = i;
    }
}
