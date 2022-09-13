using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : Singleton<ManagerGame>
{
    public Slider sliderEnemyUI;
    public Image[] lifesUI;
    public GameObject[] GameUI;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    public void Update()
    {
        DamagePlayerUI();
        DamageEnemyUI();
    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        GameUI[0].SetActive(true);
        //SoundManager.Instance.PlayNewSound("BackGroundGame");
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

                FinishGame();
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
        //StatesManager.Instance.uIController.CrossFireState(false);
        sliderEnemyUI.gameObject.SetActive(false);
        //EnemyBoss.Instance.IsActivate = false;
        Player.Instance.StateController();
        Player.Instance.Die();
        //Player.Instance.gameObject.SetActive(false);
        //ScenesManager.Instance.isLoad = true;
        //ScenesManager.Instance.LoadLevel("Introduccion_Mottis");
    }
}
