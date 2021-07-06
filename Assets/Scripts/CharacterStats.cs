using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentHealth {get; private set;}
    public int currentHappiness {get; private set;}
    public int currentReputation {get; private set;}
    
    public Stat maxHealth;
    public Stat maxHappiness;
    public Stat maxReputation;

    void Awake() 
    {
        /*
        currentHealth = maxHealth;
        currentHappiness = maxHappiness;
        currentReputation = maxReputation; 
        */
    }

    /*
    void SwitchItem (Item newItem, Item oldItem)
    {
        if (newItem != null)
        {
            maxHealth.AddModifier(newItem.maxHealthModifier);
        }

        if (oldItem != null)
        {
            maxHealth.RemoveModifier(oldItem.maxHealthModifier);
        }
    }
    */

}
