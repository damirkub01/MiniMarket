using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingItemsPanel : MonoBehaviour
{
    public Dictionary<Item, int> itemsToBuy = new Dictionary<Item, int>();
    public Dictionary<Item, BIPItemPanel> BIPpanels = new Dictionary<Item, BIPItemPanel>();
    public GameObject panelPrefab;
    public RectTransform panelsTransform;
    public DropZone dropZone;
    private float y = 0;

    public void AddItem(Item item)
    {
        if(itemsToBuy.ContainsKey(item))
        {
            itemsToBuy[item] += 1;
            BIPpanels[item].UpdateCount(itemsToBuy[item]);
        }
        else
        {
            itemsToBuy.Add(item, 1);
            CreatePanel(item);
        }
    }

    public void RemoveItem(Item item)
    {
        int i;
        if(itemsToBuy.TryGetValue(item, out i))
        {
            if(i - 1 <= 0)
            {
                itemsToBuy.Remove(item);
                DelitePanel(item);
            }
            else
            {
                itemsToBuy[item] -= 1;
                BIPpanels[item].UpdateCount(i - 1);
            }
        }
    }

    public void ClearAll()
    {
        itemsToBuy.Clear();
        foreach (var item in BIPpanels)
        {
            Destroy(item.Value.gameObject);
        }
        panelsTransform.sizeDelta = new Vector2(panelsTransform.sizeDelta.x, 0);
    }

    public void BuyAll()
    {
        float cost = 0;
        List<Item> ToBuyItems = new List<Item>();
        foreach (var item in itemsToBuy)
        {
            cost += item.Value * item.Key.Cost;
            for(int i=0;i<item.Value;i++)
                ToBuyItems.Add(item.Key);
        }
        if(MoneyManager.DecreaseMoney(cost))
        {
            dropZone.DropByTime(ToBuyItems.ToArray(), 60);
            ClearAll();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    private void CreatePanel(Item item)
    {
        if(y==0)
            y = panelPrefab.GetComponent<RectTransform>().sizeDelta.y;
        BIPItemPanel bip = Instantiate(panelPrefab, panelsTransform).GetComponent<BIPItemPanel>();
        bip.Setup(this, item);
        BIPpanels.Add(item, bip);
        panelsTransform.sizeDelta += new Vector2(0, y);
    }

    private void DelitePanel(Item item)
    {
        panelsTransform.sizeDelta -= new Vector2(0, y);
        Destroy(BIPpanels[item].gameObject);
        BIPpanels.Remove(item);
    }
}
