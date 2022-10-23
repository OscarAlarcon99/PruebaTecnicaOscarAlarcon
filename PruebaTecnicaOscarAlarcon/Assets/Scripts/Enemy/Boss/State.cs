using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected EnemyBoss mainParent;

    public virtual void Enter(EnemyBoss enemyBoss)
    {
        mainParent = enemyBoss;
    }

    public virtual void Update()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void OntriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Salio exit");
            mainParent.Target = null;
            mainParent.ChangeState(new IdleState());
        }
    }

    public virtual void Exit()
    {

    }
}
