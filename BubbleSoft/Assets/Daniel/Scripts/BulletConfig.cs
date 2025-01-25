using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    Red,
    Yellow,
    Pink,
    Blue,
    Green
}

[CreateAssetMenu(fileName = "New Bullet", menuName = "Germ1%/Bullet")]
public class BulletConfig : ScriptableObject
{
    public Type type;
    public Sprite sprite;
}
