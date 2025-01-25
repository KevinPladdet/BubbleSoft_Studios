using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Germ", menuName = "Germ1%/Germ")]
public class GermConfig : ScriptableObject
{
    public float fireRate;
    public BulletConfig[] bullets;
}
