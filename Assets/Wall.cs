using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public int doorId = 1;
    
    private bool needToOpen = false;
    
    private bool needToClose = false;
    
    public GameObject door;
    
    public InventoryFacade _facade;

    public float openX = 2.4f;

    public float speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        _facade = InventoryFacade.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(this.door.transform.position.x >= openX)
            this.needToOpen = false;
        
        if(this.door.transform.position.x == 0)
            this.needToClose = false;
        
        if (needToOpen && this.door.transform.position.x < this.openX)
        {
            this.door.transform.position = Vector3.MoveTowards(this.door.transform.position, 
                new Vector3(this.openX, this.door.transform.position.y, this.door.transform.position.z), this.speed*Time.deltaTime);
        }
        

        if (needToClose && this.door.transform.position.x > 0f && !this.needToOpen)
        {
            this.door.transform.position = Vector3.MoveTowards(this.door.transform.position, 
                new Vector3(0f, this.door.transform.position.y, this.door.transform.position.z), this.speed*Time.deltaTime);

        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "Player")
        {
            KeyItem keyItem = this._facade.CheckForItemInInventory(this.doorId);
            // _facade.AddToInventory(keyItem);
            Debug.Log(keyItem);
            if(keyItem != null)
                this.needToOpen = true;
            // Destroy(keyPrefab);
        }
        
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("Exit");
            this.needToClose = true;
        }
    }
}
