﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerV4 : MonoBehaviour
{
    public CactusSpawnerV4 Spawner;
    public PlayerControllerV4 Player;
    public Text CurrentTime;
    public Text BestTime;
    public GameObject UIButtons;

    private float bestTimeValue;
    private float time = 0;
    private bool hasGameEnded = false;

    private void Start()
    {
        bestTimeValue = PlayerPrefs.GetFloat("BestTime", 0);
        BestTime.text = bestTimeValue.ToString();
    }

    private void Update()
    {
        if (hasGameEnded)
        {
            return;
        }
        time += Time.deltaTime;
        CurrentTime.text = time.ToString();
        if (time > bestTimeValue)
        {
            bestTimeValue = time;
            BestTime.text = bestTimeValue.ToString();
        }
    }

    public void OnPlayerHit()
    {
        CactusObstacleV4.Speed = 0;
        Spawner.ShouldSpawn = false;
        hasGameEnded = true;
        if (time > PlayerPrefs.GetFloat("BestTime", 0))
        {
            PlayerPrefs.SetFloat("BestTime", time);
            BestTime.text = time.ToString();
        }
        UIButtons.SetActive(true);
    }
}
