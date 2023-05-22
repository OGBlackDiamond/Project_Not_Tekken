using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    string Command { get; }
    string Output { get; }

    public void Cast() { }
}
