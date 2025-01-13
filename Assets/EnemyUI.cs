using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyBot enemy;

    public Slider enemyHealth;
    void Start()
    {
        enemyHealth.maxValue = enemy.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.value = enemy.currentHealth;
    }
}
