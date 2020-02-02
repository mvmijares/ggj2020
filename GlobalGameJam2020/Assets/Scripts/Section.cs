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

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<Item>())
        {
            Item component = other.transform.GetComponent<Item>();
            if (!component.itemUsed)
            {
                if (component.type == sectionType)
                {
                    component.itemUsed = true;

                    if (gm_instance)
                        gm_instance.AddScore(sectionScoreValue);

                }
            }
        }
    }
}
