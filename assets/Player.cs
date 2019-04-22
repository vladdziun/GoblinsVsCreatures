using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject gameManagerObject;
    public GameManager gameManager;
    public int team;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlayerTeam1" && col.gameObject.GetComponent<Player>().team == 1
            && gameObject.GetComponent<Player>().team == 0)
        {
            GameManager.goblins--;
            Destroy(col.gameObject);
            gameManager.UpdateCount();
        }
    }
}
