using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public GameObject tower;

    public int towerHP = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towerHP <= 0)
        {
            tower.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        towerHP -= damage;
        if (towerHP <= 0)
        {
            tower.SetActive(false);
        }
    }
}
