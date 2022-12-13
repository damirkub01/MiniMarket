using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instant;
    public static float Money { get { return money; } set { Instant.SetMoney(value); } }
    private static float money = 100;
    private void Awake()
    {
        Instant = this;
    }

    public void SetMoney(float c)
    {
        money = c;
        UIManager.SetMoney(c);
    }

    public static bool DecreaseMoney(float m)
    {
        if(money - m < 0)
        {
            return false;
        }
        Money -= m;
        return true;
    }
}
