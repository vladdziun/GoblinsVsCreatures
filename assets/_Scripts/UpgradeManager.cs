﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HappyFunTimes;

public class UpgradeManager : MonoBehaviour
{
    public bool isKey;
    public bool isShovel;
    public bool isSpeedUp;
    public SpriteRenderer keySprite;
    public SpriteRenderer shovelSprite;
    public SpriteRenderer speedUpSprite;

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
        if (isSpeedUp && speedUpSprite.enabled == false)
        {
            speedUpSprite.enabled = true;
            StartCoroutine(SpeedUp());
        }
        if (!isKey)
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

    IEnumerator SpeedUp()
    {
        gameObject.GetComponent<BirdScript>().maxSpeed = 6;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<BirdScript>().maxSpeed = 4;
        speedUpSprite.enabled = false;
        isSpeedUp = false;
    }
}
