using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : ACardContent
{
    [SerializeField] private int health;
    [SerializeField] private int damage;

    public int CurHealth { get; set; }
    public int CurDamage { get; set; }
}
