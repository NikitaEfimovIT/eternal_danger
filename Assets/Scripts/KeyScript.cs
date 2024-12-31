using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    public GameObject keyPrefab;
    private KeyItem keyItem = new KeyItem(0.21231f, 1);
    public InventoryFacade _facade;
    
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        _facade = InventoryFacade.Instance;
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _facade.AddToInventory(keyItem);
            Debug.Log(collision.gameObject.name);
            Destroy(keyPrefab);
        }
    }
}
