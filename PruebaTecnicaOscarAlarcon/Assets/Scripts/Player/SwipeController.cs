using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour
{
    [SerializeField]
    private CharacterInput characterInput;

    [SerializeField]
    float minmumDistance = .2f;
    [SerializeField]
    float maximumTime = 1f;
    Vector3 startPosition;
    Vector3 endPosition;

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

    public void SwipeStart(Vector2 position)
    {
        startPosition = position;
        SimpleSampleCharacterControl.Instance.characterPlayerInput.fingerPositionImage.gameObject.SetActive(true);
    }

    public void SwipeEnd(Vector2 position)
    {
        endPosition = position;
        SimpleSampleCharacterControl.Instance.characterPlayerInput.fingerPositionImage.gameObject.SetActive(false);
    }
 
}
