using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    private Vector3 lookAt;
    private  Vector3 mousePos;
    private float angle;
    private Vector3 objectPos;
    public GameObject bulletPrefab;
    [SerializeField] private Transform shootingPos;
    [SerializeField] private Animator anim;

    public GermConfig germ;

    private float elapsedTimeMs = 0f;
    private float lastTimeShooted = 0f;
    public bool canShoot = true;

    public float fireRate = 200f;


    [SerializeField] private SpriteRenderer ammoDisplay;
    [SerializeField] private BulletConfig nextBullet;

    // Start is called before the first frame update
    void Start()
    { 
        fireRate = germ.fireRate;

        nextBullet = germ.bullets[Random.Range(0, germ.bullets.Length)];
        ammoDisplay.sprite = nextBullet.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeMs += Time.deltaTime * 1000;
        lookAtMouse();

        //bool canShoot = (elapsedTimeMs - fireRate) > lastTimeShooted;

        if (Input.GetMouseButton(0) && canShoot)
        {
            anim.SetTrigger("Shoot");
            canShoot = false;
        }

    }

    public void ShootBullet()
    {
        lastTimeShooted = elapsedTimeMs;
        GameObject bullet = Instantiate(bulletPrefab, shootingPos.position, Quaternion.identity);
        Bullet buscript = bullet.GetComponent<Bullet>();
        buscript.velocity = 10;
        buscript.direction = lookAt;
        buscript.angle = angle;
        buscript.bulletConfig = nextBullet;


        nextBullet = germ.bullets[Random.Range(0, 3)];
        ammoDisplay.sprite = nextBullet.sprite;
    }

    private void lookAtMouse()
    {
        lookAt = new Vector3();
        objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos = Input.mousePosition;
        lookAt.x = mousePos.x - objectPos.x;
        lookAt.y = mousePos.y - objectPos.y;

        angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}