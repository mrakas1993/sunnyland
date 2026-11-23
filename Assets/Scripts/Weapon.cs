using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource plaudio;
    public AudioClip shootSound; //звук выстрела
    public Transform shootPos;
    public GameObject bullet;
    public float fireRate = 0.3f;
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Fire1")&& Time.time >= nextFireTime)
        {
            Instantiate(bullet,shootPos.transform.position,transform.rotation);
            nextFireTime = Time.time + fireRate;
            plaudio.PlayOneShot(shootSound);
        }
    }
}
