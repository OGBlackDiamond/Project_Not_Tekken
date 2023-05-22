using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
}
