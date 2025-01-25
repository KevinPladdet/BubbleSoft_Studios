using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    [SerializeField] private Vector3 look_at;
    [SerializeField] private  Vector3 mouse_pos;
    [SerializeField] private float angle;
    [SerializeField] private Vector3 objectPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPos;

    private float elapsedTimeMs = 0f;
    private float lastTimeShooted = 0f;

    public float fireRate = 200f;

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
            buscript.direction = look_at;
            buscript.angle = angle;
        }

    }

    private void lookAtMouse()
    {
        look_at = new Vector3();
        objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mouse_pos = Input.mousePosition;
        look_at.x = mouse_pos.x - objectPos.x;
        look_at.y = mouse_pos.y - objectPos.y;

        angle = Mathf.Atan2(look_at.y, look_at.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
