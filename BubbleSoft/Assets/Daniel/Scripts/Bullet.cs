using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float angle;
    public float velocity;
    public BulletConfig bulletConfig;
    public ColorType type;

    [SerializeField] private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = bulletConfig.sprite;
        type = bulletConfig.type;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.x < 0 || position.x > 1 || position.y < 0 || position.y > 1)
        {
            Destroy(this.gameObject);
        }
        transform.position += direction.normalized * velocity * Time.deltaTime;
        
    }

}