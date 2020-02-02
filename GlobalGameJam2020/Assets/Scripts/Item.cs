using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None, Bananas, Apples, Steak, Ham
}
public class Item : MonoBehaviour
{
    #region Data
    GameManager gm_instance;
    Rigidbody rb;
    public ItemType type;
    public bool itemUsed;
    private float destroyTimer = 0f;

    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gm_instance = GameManager.instance;
    }
    public void FreezeRigidbody(bool condition)
    {
        rb.isKinematic = condition;
        
    }
    public void ThrowObject(Vector3 force, float power)
    {
        rb.AddForce(force * power);
    }

    private void Update()
    {
        if (itemUsed)
        {
            destroyTimer += Time.deltaTime;
            if(destroyTimer >= gm_instance.itemTimeOut)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
