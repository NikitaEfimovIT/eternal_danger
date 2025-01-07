using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerScript player;
    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        health.maxValue = player.maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        health.value = player.playerHealth;
    }
}
