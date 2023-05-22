using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellManager : MonoBehaviour
{
    [SerializeField] private TMP_Text consoleText;
    // List of possible spells
    private List<ISpell> spellList;

    private void Start()
    {
        spellList = new List<ISpell>(GetComponents<ISpell>());
    }

    public void ExecuteCommand(string command)
    {
        var spellSections = command.Split(' ');

        foreach (ISpell spell in spellList)
        {
            if (spell.Command == spellSections[0])
            {
                spell.Cast();
                consoleText.text += "\n" + spell.Output;

                return;
            }
        }

        consoleText.text += "\n" + spellSections[0] + " is not a valid command";
    }
}
