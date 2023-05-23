using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, IEnemy
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }

    public void Damage(int damage)
    {
        Health -= damage;
    }
}
