﻿using UnityEngine;
using System.Collections.Generic;

public class Players : MonoBehaviour
{
    public PlayerController prefab;
    public List<PlayerController> activePlayers = new List<PlayerController>();
    public GameObject DeathUI;

    // Use this for initialization
    void Start()
    {
        //create inital playable character
        PlayerController p = (PlayerController)Instantiate(prefab,
                                             new Vector3(0f, 0f, 0f),
                                             Quaternion.identity);
        p.gameObject.transform.parent = gameObject.transform;

        activePlayers.Add(p);
    }

    public void AddPlayer(PlayerController p)
    {
        activePlayers.Add(p);
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        bool removedPlayers = false;
        for(int i = 0; i < activePlayers.Count; i++)
        {                
            Health health = activePlayers[i].gameObject.GetComponentInChildren<Health>();
            if(health.currentHealth == 0)
            {
                //DIE DIE DIE
                activePlayers[i].gameObject.GetComponent<PlayerController>().Kill();
                activePlayers.RemoveAt(i);
                i--;
                removedPlayers = true;
            }
        }

        if(activePlayers.Count == 0 && removedPlayers)
        {
            //End game
            FindObjectOfType<Timer>().running = false;
            DeathUI.SetActive(true);
        }
    }
}
