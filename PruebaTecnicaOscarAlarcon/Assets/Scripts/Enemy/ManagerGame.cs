using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject panelWinner;
    public GameObject panelLosse;
    public TMP_Text puntuacion;
    public TimeLineRutine timeLine;
    bool startGame;
    void Start()
    {
        StartCoroutine(StartGame());
        SoundManager.Instance.PlayNewSound("BackGroundGame");
    }

    public void Update()
    {
        Game();

        if (startGame)
        {
            DamagePlayerUI();
            DamageEnemyUI();
        }
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
        TimeSpan time = TimeSpan.FromSeconds(timer.currentTime);
    }

    IEnumerator StartGame()
    {
        timeLine.Play(0);
        yield return new WaitUntil(() => !timeLine.StatePlayable(0));
        yield return new WaitForSeconds(2f);
        timeLine.Play(0);
        yield return new WaitUntil(() => !timeLine.StatePlayable(0));
        SimpleSampleCharacterControl.Instance.cinemachineCamera.freeAim.gameObject.SetActive(true);
        gameUI[0].SetActive(true);
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
        gameUI[0].SetActive(false);
        timer.timerActive = false;
        EnemyBoss.Instance.IsActive = false;
        Player.Instance.IsActive = false;

        if (Player.Instance.isActive)
        {
            StartCoroutine(Winner());
        }
        else
        {
            StartCoroutine(failed());
        }
    }

    IEnumerator Winner()
    {
        panelWinner.SetActive(true);
        yield return new WaitForSeconds(10f);
        ScenesManager.Instance.isLoad = true;
        ScenesManager.Instance.LoadLevel("MainMenu");
    }

    IEnumerator failed()
    {
        panelLosse.SetActive(true);

        yield return new WaitForSeconds(10f);
        ScenesManager.Instance.isLoad = true;
        ScenesManager.Instance.LoadLevel("MainMenu");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StartMatch());
        }
    }

    IEnumerator StartMatch()
    {
        gameUI[0].SetActive(false);
        Player.Instance.IsActive = false;
        timeLine.Play(1);
        yield return new WaitUntil(() => !timeLine.StatePlayable(1)); 
        startGame = true;
        timer.StartTimer();
        ScenesManager.Instance.EditTouchSystem(true);
        Player.Instance.IsActive = true;
        EnemyBoss.Instance.IsActive = true;
        InvokeRepeating("Spawn", 3, 20);
        Destroy(gameObject.GetComponent<BoxCollider>());
    }

}
