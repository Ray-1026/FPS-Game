using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fire;
    public Transform BulletPoint;
    public GameObject Bullet;
    public AudioClip clip;

    private float cd = 0.5f;
    private float timer = 0;
    private AudioSource gunPlayer;
    // Start is called before the first frame update
    void Start()
    {
        gunPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cd && Input.GetMouseButton(0))
        {
            timer = 0;
            Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);
            Instantiate(Fire, FirePoint.position, FirePoint.localRotation);
            gunPlayer.PlayOneShot(clip);
        }
    }
}
