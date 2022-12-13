using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsBase : MonoBehaviour
{
    public static ItemsBase Instant;
    public List<Item> items;
    private void Awake()
    {
        Instant = this;
    }

    public static Item[] GetItems()
    {
        return Instant.items.ToArray();
    }
}
