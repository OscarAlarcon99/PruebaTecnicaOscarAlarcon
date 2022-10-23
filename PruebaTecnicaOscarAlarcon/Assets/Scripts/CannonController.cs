using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;
    public LineRenderer line;
    public GameObject Cannonball;
    public Transform ShotPoint;

    public GameObject Explosion;
    public  Vector3 firstPosition;
    void Start()
    {
        firstPosition = transform.localEulerAngles;
    }

    private void Update()
    {
        if (true)
        {
            float HorizontalRotation = 0;
            float VericalRotation = SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput();
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
                new Vector3(0, HorizontalRotation * rotationSpeed, VericalRotation * rotationSpeed));
        }
    }

    public void Shooting()
    {
        if (Player.Instance.IsActive && Player.Instance.currentTimeSpawn > Player.Instance.timeToSpawn)
        {
    
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

            // Added explosion for added effect
            Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

            // Shake the screen for added effect
            Screenshake.ShakeAmount = 5;
            transform.localEulerAngles = firstPosition;
            Player.Instance.currentTimeSpawn = 0;
        }
    }


}
