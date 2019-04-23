using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject gameManagerObject;
    public GameManager gameManager;
    public int team;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isCreaturesWin)
        {
            if (gameObject.tag == "PlayerTeam0")
                animator.SetBool("isWinner", true);
        }
        else if (GameManager.isGoblinsWin)
        {
            if (gameObject.tag == "PlayerTeam1")
                animator.SetBool("isWinner", true);
        }


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
