using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    // List of possible spells
    private List<ISpell> spellList;

    private void Start()
    {
        spellList = new List<ISpell>(GetComponents<ISpell>());
    }

    public void ExecuteCommand(string command)
    {
        foreach (ISpell spell in spellList)
        {
            if (spell.Command == command) spell.Cast();
        }
    }
}
