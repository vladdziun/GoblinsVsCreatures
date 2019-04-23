using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeStart : MonoBehaviour
{
    public GameObject end;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTeam1" || col.gameObject.tag == "PlayerTeam0")
        {
            if(end.transform.position.x > transform.position.x)
                col.transform.position = end.transform.position + new Vector3(1, -0.3f, 0);
            else
                col.transform.position = end.transform.position + new Vector3(-1, -0.3f, 0);
        }
    }
}
