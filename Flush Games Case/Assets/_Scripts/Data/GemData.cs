using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Collectables/Gem", fileName = "New Gem Data")]
public class GemData : ScriptableObject
{
    public string GemName;
    public int GemInintialPrice;
    public Sprite GemIcon;
    public GameObject GemModel;
}
