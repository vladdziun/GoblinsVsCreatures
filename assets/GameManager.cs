using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static int moneyBags = 0;
    public static int goblins = 0;
    public Text bagsCount;
    public Text goblinsCount;
    public static bool isGameStarted = false;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        GetGoblinsBags();
        bagsCount.text = "Bags Left: " + moneyBags;
        goblinsCount.text = "Goblins Left: " + goblins;
    }

    // Update is called once per frame
    void Update()
    {
        if(moneyBags <= 0)
        {

        }
        if(goblins <= 0 )
        {

        }
    }

    public void UpdateCount()
    {
        Debug.Log("Goblins left:" + goblins);
        bagsCount.text = "Bags Left: " + moneyBags;
        goblinsCount.text = "Goblins Left: " + goblins;
    }

    public void GetGoblinsBags()
    {
        moneyBags = GameObject.FindGameObjectsWithTag("Bag").Length;
        goblins = GameObject.FindGameObjectsWithTag("PlayerTeam1").Length;
    }
}
