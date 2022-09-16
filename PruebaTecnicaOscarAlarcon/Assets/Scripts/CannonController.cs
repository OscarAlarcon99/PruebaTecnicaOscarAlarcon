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
    [SerializeField] float HorizontalRotation;
    [SerializeField] float VerticalRotation;
    public Vector3 firstPosition;
    [SerializeField] float angleYMin;
    [SerializeField] float angleYMax;

    private void Update()
    {
        if (SimpleSampleCharacterControl.Instance.aimUse)
        {
            //VerticalRotation = Mathf.Clamp(SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput(), angleYMin, angleYMax);
            VerticalRotation = SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput();
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
           new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));
        }
    }

    public void Shooting()
    {
        if (Player.Instance.Ammo > 0 && Player.Instance.IsActive && Player.Instance.currentTimeSpawn > Player.Instance.timeToSpawn)
        {
            Player.Instance.Ammo--;

            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

            // Added explosion for added effect
            Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

            // Shake the screen for added effect
            Screenshake.ShakeAmount = 5;
            Player.Instance.currentTimeSpawn = 0;
        }
    }
}
