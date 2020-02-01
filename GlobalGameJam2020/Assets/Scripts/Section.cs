using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    #region Data
    [SerializeField]
    private GameManager gm_instance;
    public ItemType sectionType;
    public int sectionScoreValue;
    #endregion

    private void Start()
    {
        gm_instance = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>())
        {
            if(other.GetComponent<Item>().type == sectionType)
            {
                if(gm_instance)
                    gm_instance.AddScore(sectionScoreValue);

                other.GetComponent<Item>().FreezeRigidbody(true);
            }
        }
    }
}
