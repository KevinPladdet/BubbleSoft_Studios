using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : MonoBehaviour
{
    [SerializeField] private  Vector3 mouse_pos;
    [SerializeField] private float angle;
    [SerializeField] private Vector3 objectPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look_at = new Vector3();
        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        
        mouse_pos = Input.mousePosition;
        look_at.x = mouse_pos.x - objectPos.x;
        look_at.y = mouse_pos.y - objectPos.y;

        angle = Mathf.Atan2(look_at.y, look_at.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
