using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None, Steak, Ham, Lobster, Squid, Grapes, Bananas, Apple, Corn, Tomato, Carrot, Pepper
}
public class Item : MonoBehaviour
{
    #region Data
    GameManager gm_instance;
    Rigidbody rb;
    public ItemType type;
    public bool itemUsed;
    public bool shoppingCartItem = false;
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
        Physics.IgnoreCollision(this.GetComponent<Collider>(), gm_instance.GetShoppingCart().item.GetComponent<Collider>());
        rb.AddForce(force * power);
    }

    private void Update()
    {
        if (itemUsed)
        {
            GetComponent<BoxCollider>().isTrigger = true;
            destroyTimer += Time.deltaTime;
            if(destroyTimer >= gm_instance.itemTimeOut)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

}
