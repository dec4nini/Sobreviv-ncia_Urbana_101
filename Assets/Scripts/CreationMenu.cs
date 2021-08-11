using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationMenu : MonoBehaviour
{
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();

    public void RandomizeChar()
    {
        foreach (OutfitChanger changer in outfitChangers)
        {
            changer.Randomize();
        }
    }
}
