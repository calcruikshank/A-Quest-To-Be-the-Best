using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerData
{

    public int unitLevel;
    public double maxLife;
    
   
    public PlayerData(Unit playerStats)
    {
        unitLevel = playerStats.unitLevel;
        maxLife = playerStats.maxLife;
    }
}
