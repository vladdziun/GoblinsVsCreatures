using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HappyFunTimes;

public class UpgradeManager : MonoBehaviour
{
    public bool isKey;
    public bool isShovel;
    public SpriteRenderer keySprite;
    public SpriteRenderer shovelSprite;

    private HFTGamepad m_gamepad;
    private HFTInput m_hftInput;

    void Start()
    {
        m_gamepad = GetComponent<HFTGamepad>();
        m_hftInput = GetComponent<HFTInput>();
    }

    void Update()
    {
        if (isKey)
            keySprite.enabled = true;
        if (isShovel && shovelSprite.enabled ==false)
        {
            shovelSprite.enabled = true;
            StartCoroutine(Shovel());
        }
        if(!isKey)
            keySprite.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Door" && gameObject.GetComponent<Player>().team == 1)
        {
            if (m_hftInput.GetButtonDown("fire1") || Input.GetKeyDown("space"))
            {
                Debug.Log("Trying open the door");
                if(isKey)
                {
                    col.gameObject.GetComponent<DoorScript>().OpenDoor();
                    isKey = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestWall" && isShovel)
        {
            Destroy(col.gameObject);
        }
    }

    IEnumerator Shovel()
    {
        yield return new WaitForSeconds(5);
        shovelSprite.enabled = false;
        isShovel = false;
    }
}
