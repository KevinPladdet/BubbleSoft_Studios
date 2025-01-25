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

    public GermConfig germ;

    private float elapsedTimeMs = 0f;
    private float lastTimeShooted = 0f;

    public float fireRate = 200f;


    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        sprites = germ.sprites;
        fireRate = germ.fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeMs += Time.deltaTime * 1000;
        lookAtMouse();

        bool canShoot = (elapsedTimeMs - fireRate) > lastTimeShooted;

        if (Input.GetMouseButton(0) && canShoot)
        {
            lastTimeShooted = elapsedTimeMs;
            GameObject bullet = Instantiate(bulletPrefab, shootingPos.position, Quaternion.identity);
            Bullet buscript = bullet.GetComponent<Bullet>();
            buscript.velocity = 10;
            buscript.direction = lookAt;
            buscript.angle = angle;
            buscript.sprite = sprites[Random.Range(0, sprites.Length)];
            //buscript.color = colors[Random.Range(0, 3)];
        }

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
