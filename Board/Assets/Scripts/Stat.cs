using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private double baseValue = 0;

    private List<double> modifiers = new List<double>();

    public double GetValue()
    {
        double finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier (double modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(double modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
    
}
