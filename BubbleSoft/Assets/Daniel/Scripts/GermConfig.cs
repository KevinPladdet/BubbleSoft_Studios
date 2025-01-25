using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Germ", menuName = "Germ")]
public class GermConfig : ScriptableObject
{
    public float fireRate;
    public Sprite[] sprites;
}
