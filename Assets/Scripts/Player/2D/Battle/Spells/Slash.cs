using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour, ISpell
{
    [SerializeField] private int damage;
    public string Command { get; set; }
    public string Output { get; set; }

    public Slash()
    {
        Command = "slash";
    }

    public void Cast() 
    {
        Output = "Slash for " + damage + " damage!";
    }
}
