using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    #region Data
    GameManager gm_instance;
    public int maxNumItems;
    bool isFull;
    List<Item> itemList;
    Queue<ItemType> itemQueue;
    public Transform item;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gm_instance = GameManager.instance;

        itemQueue = new Queue<ItemType>();
        itemList = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm_instance.start)
        {
            if (!isFull)
            {
                SpawnNewItem();
            }
        }
    }

    private void SpawnNewItem()
    {
        if(itemList.Count == maxNumItems)
        {
            isFull = true;
            return;
        }
        else
        {
            ItemType type = RandomizeNewItem();

            switch (type)
            {
                case ItemType.Steak:
                {

                    break;
                }
            }
        }
    }

    private ItemType RandomizeNewItem()
    {
        ItemType newType = (ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(ItemType)).Length);

        return newType;
    }
}
