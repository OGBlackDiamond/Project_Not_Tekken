using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour, ISpell
{
    [SerializeField] private int damage;
    public string Command { get; set; }

    public Slash()
    {
        Command = "slash";
    }


    public void Cast()
    {
        Debug.Log("Slash for " + damage + " damage!");
    }
}
