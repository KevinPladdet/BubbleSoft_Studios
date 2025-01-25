using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bubble", menuName = "Germ1%/Bubble")]
public class BubbleConfig : ScriptableObject
{
    public Sprite sprite;
    public ColorType type;
    public int health;
    public int damage;
    public float speedMultiplier;
}
