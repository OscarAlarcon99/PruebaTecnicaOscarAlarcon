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

    public float HorizontalRotation;
    public float VerticalRotation;

    private void Update()
    {
        VerticalRotation = SimpleSampleCharacterControl.Instance.characterPlayerInput.GetVerticalCameraInput();
        transform.rotation = Quaternion.Euler(SimpleSampleCharacterControl.Instance.shooting.transform.rotation.eulerAngles +
        new Vector3(0, SimpleSampleCharacterControl.Instance.shooting.HorizontalRotation * SimpleSampleCharacterControl.Instance.shooting.rotationSpeed, SimpleSampleCharacterControl.Instance.shooting.VerticalRotation * SimpleSampleCharacterControl.Instance.shooting.rotationSpeed));

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
