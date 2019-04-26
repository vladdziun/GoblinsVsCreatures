using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static int moneyBags = 0;
    public static int goblins = 0;
    public int maxGoblins;
    public static int creatures = 0;
    public Text bagsCount;
    public Text goblinsCount;
    public Text startGoblinsCount;
    public Text startCreaturesCount;
    public Text winText;
    public static bool isGameStarted = false;
    public static bool isGoblinsWin;
    public static bool isCreaturesWin;
    public GameObject startGameCanvas;
    public GameObject mainGameCanvas;

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
        if (isGameStarted)
            Camera.main.GetComponent<AudioSource>().enabled = true;

        if(moneyBags <= 0 && isGameStarted)
        {
            isGameStarted = false;
            winText.text = "GOBLINS WIN!";
            isGoblinsWin = true;
        }
        if(goblins <= 0 && isGameStarted)
        {
            isGameStarted = false;
            winText.text = "CREATURES WIN!";
            isCreaturesWin = true;

        }
        if (!isGameStarted)
            maxGoblins = GameObject.FindGameObjectsWithTag("PlayerTeam1").Length;
        if (isGameStarted)
        {
            int newMaxGoblins = GameObject.FindGameObjectsWithTag("PlayerTeam1").Length;
            if (maxGoblins != newMaxGoblins)
            {
                goblins = goblins - (maxGoblins - newMaxGoblins);
                maxGoblins = newMaxGoblins;
                UpdateCount();
            }
        }


        //TODO: 2 lines below should be removed from update
        //goblins = GameObject.FindGameObjectsWithTag("PlayerTeam1").Length;
        //goblinsCount.text = "Goblins Left: " + goblins;
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
        creatures = GameObject.FindGameObjectsWithTag("PlayerTeam0").Length;
        startGoblinsCount.text = "Goblins Connected: " + goblins;
        startCreaturesCount.text = "Creatures Connected: " + creatures;

    }

    public void StartGame()
    {
        Debug.Log("Game started!");
        isGameStarted = true;
        startGameCanvas.GetComponent<Canvas>().enabled = false;
        mainGameCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void TestDb()
    {
        Debug.Log("Test DB!");
    }
    public void DecreaseGoblins()
    {
        goblins--;
    }
}
