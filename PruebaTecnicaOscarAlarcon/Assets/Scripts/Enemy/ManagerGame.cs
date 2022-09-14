using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : Singleton<ManagerGame>
{
    public Text valueAmmo;
    public Slider sliderEnemyUI;
    public Image[] lifesUI;
    public GameObject[] gameUI;
    public GameObject[] Items;
    public GameObject[] pointSpawn;
    public Timer timer;
    public int indexItems;
    GameObject currentSpawnPoint;



    void Start()
    {
        StartCoroutine(StartGame());
        InvokeRepeating("Spawn", 7, 20);
    }

    public void Update()
    {
        DamagePlayerUI();
        DamageEnemyUI();
        Game();
    }

    public void Spawn()
    {
        int Ramdom = UnityEngine.Random.Range(0, pointSpawn.Length);
        
        if (currentSpawnPoint != pointSpawn[Ramdom])
        {
            currentSpawnPoint = pointSpawn[Ramdom];

            Instantiate(Items[indexItems], currentSpawnPoint.transform.position, Quaternion.identity);
            indexItems++;
        }

    }


    public void Game()
    {
        valueAmmo.text = Player.Instance.Ammo.ToString();
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        timer.StartTimer();
        gameUI[0].SetActive(true);
        Player.Instance.IsActive = true;
        EnemyBoss.Instance.IsActive = true;
        SoundManager.Instance.PlayNewSound("BackGroundGame");
    }

    public void DamageEnemyUI()
    {
        if (EnemyBoss.Instance.healt.health > 0)
        {
            sliderEnemyUI.gameObject.SetActive(true);
            sliderEnemyUI.value = EnemyBoss.Instance.healt.health;
        }
        else
        {
            sliderEnemyUI.gameObject.SetActive(false);
        }
    }

    public void DamagePlayerUI()
    {
        switch (Player.Instance.lifes)
        {
            case 0:
                lifesUI[0].gameObject.SetActive(false);
                lifesUI[1].gameObject.SetActive(false);
                lifesUI[2].gameObject.SetActive(false);
                break;

            case 1:
                lifesUI[0].gameObject.SetActive(true);
                lifesUI[1].gameObject.SetActive(false);
                lifesUI[2].gameObject.SetActive(false);
                break;

            case 2:
                lifesUI[0].gameObject.SetActive(true);
                lifesUI[1].gameObject.SetActive(true);
                lifesUI[2].gameObject.SetActive(false);
                break;

            case 3:
                lifesUI[0].gameObject.SetActive(true);
                lifesUI[1].gameObject.SetActive(true);
                lifesUI[2].gameObject.SetActive(true);
                break;
        }
    }

    public void FinishGame()
    {
        timer.timerActive = false;
        sliderEnemyUI.gameObject.SetActive(false);
        EnemyBoss.Instance.IsActive = false;
        Player.Instance.IsActive = false;

        //Player.Instance.gameObject.SetActive(false);
        ScenesManager.Instance.isLoad = true;
        ScenesManager.Instance.LoadLevel("MainMenu");
    }
}
