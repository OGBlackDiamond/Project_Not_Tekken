using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int MaxHealth { get; }
    int Health { get; }

    public void Damage(int damage) { }
}
