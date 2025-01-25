using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bullet", menuName = "Germ1%/Bullet")]
public class BulletConfig : ScriptableObject
{
    public ColorType type;
    public Sprite sprite;
}
