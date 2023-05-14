using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    string Command { get; }

    public virtual void Cast() { }
}
