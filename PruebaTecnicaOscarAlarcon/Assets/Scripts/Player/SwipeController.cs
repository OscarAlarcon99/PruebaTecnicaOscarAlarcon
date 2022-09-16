using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private CharacterInput characterInput;

    [SerializeField]
    float minmumDistance = .2f;
    [SerializeField]
    float maximumTime = 1f;

    Vector3 startPosition;
    float startTime;
    Vector3 endPosition;
    float endTime;

    void Awake()
    {
        characterInput = SimpleSampleCharacterControl.Instance.characterPlayerInput;
    }

    void OnEnable()
    {
        characterInput.OnStartTouch += SwipeStart;
        characterInput.OnEndTouch += SwipeEnd;

    }
    void OnDisable()
    {
        characterInput.OnStartTouch -= SwipeStart;
        characterInput.OnEndTouch -= SwipeEnd;

    }

    void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }

    void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;

        DetectedSwipe();
    }
    
    void DetectedSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition)>= minmumDistance &&
            (endTime - startTime) <= maximumTime)
        {

        }
    }
}
