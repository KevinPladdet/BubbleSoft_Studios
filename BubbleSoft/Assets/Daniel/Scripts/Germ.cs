using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    [SerializeField] private Vector3 lookAt;
    [SerializeField] private  Vector3 mousePos;
    [SerializeField] private float angle;
    [SerializeField] private Vector3 objectPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPos;

    private float elapsedTimeMs = 0f;
    private float lastTimeShooted = 0f;

    public float fireRate = 200f;

    public Color[] colors = new Color[] { Color.red, Color.yellow, Color.green };

    // Start is called before the first frame update
    void Start()
    {
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
            var bullet = Instantiate(bulletPrefab, shootingPos.position, Quaternion.identity);
            Bullet buscript = bullet.GetComponent<Bullet>();
            buscript.velocity = 10;
            buscript.direction = lookAt;
            buscript.angle = angle;
            buscript.color = colors[Random.Range(0, 3)];
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
