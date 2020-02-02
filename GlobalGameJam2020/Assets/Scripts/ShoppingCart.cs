using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCart : MonoBehaviour
{
    #region Data
    public Transform itemSpawn;
    GameManager gm_instance;
    public int maxNumItems = 1;
    int numPrefabs;
    bool isFull = false;
    public List<Transform> prefabList;
    Queue<ItemType> itemQueue;
    public Transform item;

    float distanceFromCart = 1; // if item is too far from the cart, reset position;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        gm_instance = GameManager.instance;

        itemQueue = new Queue<ItemType>();
        numPrefabs = prefabList.Count;
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

        //Error checking

        if(item != null)
        {
            float distance = (item.position - itemSpawn.position).magnitude;
            if(distance >= distanceFromCart)
            {
                item.position = itemSpawn.position;
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    private void SpawnNewItem()
    {
        if(item != null)
        {
            isFull = true;
            return;
        }
        else
        {
            int num = RandomizeNewItem();
            Transform clone = null;
            switch (num)
            {
                case 1:
                {
                    clone = Instantiate(prefabList[0].transform, itemSpawn.position, prefabList[0].transform.rotation);
                    clone.parent = this.transform;
                    break;
                }
                case 2:
                {
                    clone = Instantiate(prefabList[1].transform, itemSpawn.position, prefabList[0].transform.rotation);
                    clone.parent = this.transform;
                    break;
                }
            }
            if(clone == null)
            {
                Debug.Log("Randomizer did not find prefab that matched");
            }
            else
            {
                
                item = clone; 
                item.GetComponent<Item>().shoppingCartItem = true;
            }
        }
    }

    private int RandomizeNewItem()
    {
        Debug.Log("Number of prefabs is" + numPrefabs);
        int randomNum = UnityEngine.Random.Range(0, numPrefabs + 1);

        return randomNum;
    }
    public void RemoveShoppingCartItem()
    {
        isFull = false;
        item = null;
    }
}
