using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None, Bananas, Apples, Steak, Ham
}
public class Item : MonoBehaviour
{
    Rigidbody rb;
    public ItemType type;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FreezeRigidbody(bool condition)
    {
        rb.isKinematic = condition;
        
    }
    public void ThrowObject(Vector3 force, float power)
    {
        rb.AddForce(force * power);
    }
}
