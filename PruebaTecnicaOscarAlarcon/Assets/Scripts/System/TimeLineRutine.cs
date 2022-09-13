using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineRutine : MonoBehaviour
{
    /// <summary>
    /// Lista que almacena Playables 
    /// </summary>
    [SerializeField]
    List<PlayableDirector> playableDirectors = new List<PlayableDirector>();
    /// <summary>
    /// variable que almacena valor del ultimo playing de  playable
    /// </summary>
    public int lastIndex;

    /// <summary>
    /// Funcion que recibe objeto principal donde se almacenan todas los playables 
    /// </summary>
    public void SetCinematics(GameObject Container)
    {
        playableDirectors.Clear();

        foreach (PlayableDirector playable in Container.GetComponentsInChildren<PlayableDirector>())
        {
            playableDirectors.Add(playable);
        }
    }
    /// <summary>
    /// Funcion que verifica retorna el estado de playing de determinado playable
    /// </summary>
    public bool StatePlayable(int index)
    {
        if (playableDirectors[index].state == PlayState.Playing 
            && playableDirectors[index].state != PlayState.Paused )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Funcion que inicia playing de determinado playable
    /// </summary>
    public void Play(int index)
    {
        lastIndex = index;
        playableDirectors[lastIndex].Play();
        Debug.Log(playableDirectors[lastIndex].name);
    }
    /// <summary>
    /// Funcion que pausa playing de determinado playable
    /// </summary>
    public void Pause(int index)
    {
        playableDirectors[index].Pause();
    }
    /// <summary>
    /// Funcion que despausa playing de determinado playable
    /// </summary>
    public void Resume(int index)
    {
        playableDirectors[index].Resume();
    }
}

