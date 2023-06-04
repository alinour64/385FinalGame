using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public SpriteRenderer sr;
    public CharacterController2D player;
    public GameObject mountPoint;
    public Bullet bulletPrefab;
    public Wall wallPrefab;
    public int weaponIndex; // 1 = slingshot, 2 = air cannon, 3 = sniper
    public Sprite[] launchers;
    private AudioSource source;
    public float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }
    public void Shoot()
    {
        if (weaponIndex == 0)
        {
            if (timer >= .15)
            {
                Bullet bullet = Instantiate(bulletPrefab, mountPoint.transform.position, mountPoint.transform.rotation);
                if (player.facingRight) bullet.Shoot(transform.right);
                else bullet.Shoot(transform.right * -1);
                source.Play();
                timer = 0;
            }
            
        }
        else if (weaponIndex == 1)
        {
            if (timer >= 1.25f)
            {
                Wall wall = Instantiate(wallPrefab, mountPoint.transform.position, mountPoint.transform.rotation);
                if (player.facingRight) wall.Shoot(transform.right);
                else wall.Shoot(transform.right * -1);
                source.Play();
                timer = 0;
            }
        }
        else if (weaponIndex == 2)
        {
            if (timer >= .7f)
            {
                Bullet bullet1 = Instantiate(bulletPrefab, mountPoint.transform.position, mountPoint.transform.rotation);
                Bullet bullet2 = Instantiate(bulletPrefab, mountPoint.transform.position, mountPoint.transform.rotation);
                Bullet bullet3 = Instantiate(bulletPrefab, mountPoint.transform.position, mountPoint.transform.rotation);
                if (player.facingRight)
                {
                    bullet1.transform.Rotate(0f, 0f, 15f, Space.Self);
                    bullet3.transform.Rotate(0f, 0f, -15f, Space.Self);
                    bullet1.Shoot(bullet1.transform.right);
                    bullet2.Shoot(bullet2.transform.right);
                    bullet3.Shoot(bullet3.transform.right);
                } 
                else 
                {
                    bullet1.transform.Rotate(0f, 0f, -15f, Space.Self);
                    bullet3.transform.Rotate(0f, 0f, 15f, Space.Self);
                    bullet1.Shoot(bullet1.transform.right * -1);
                    bullet2.Shoot(bullet2.transform.right * -1);
                    bullet3.Shoot(bullet3.transform.right * -1);
                }
                source.Play();
                timer = 0;
            }
        }
            
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    public void nextGun()
    {
        timer = 1.5f;
        weaponIndex = (weaponIndex + 1) % launchers.Length;
        sr.sprite = launchers[weaponIndex];
    }
}