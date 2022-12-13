using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instant;
    public TMP_Text moneyText;

    private void Awake()
    {
        Instant = this;
    }

    public static void SetMoney(float c)
    {
        Instant.moneyText.text = c + " $";
    }
}
