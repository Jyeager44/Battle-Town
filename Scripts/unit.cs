using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int attack;
    public int defence;
    public int speed;
    public int maxHP;
    public int currHP;


    public bool TakeDamage(int attack, int defence)
    {

        if (currHP <= 0)
            return true;
        else
            return false;
    }
}
