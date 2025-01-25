using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float angle;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("works");
        StartCoroutine(DestroyBullet());
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        transform.position += direction.normalized * velocity * Time.deltaTime;
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

}