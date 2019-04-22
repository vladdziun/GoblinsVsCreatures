﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTeam1" && col.gameObject.GetComponent<Player>().team == 1)
        {
            GameManager.moneyBags--;
            gameManager.UpdateCount();
            Destroy(gameObject);
        }
    }
}
