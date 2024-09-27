using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[System.Serializable]
public class Stats : MonoBehaviour
{
    [Tooltip("Current Health")]
    public int health = 0;
    [Tooltip("Max Health")]
    public int maxHealth = 0;
    [Tooltip("Total score based on stopwatch, gold, and enemy kills")]
    public int score = 0;
    [Tooltip("Amount of gold ")]
    public int gold = 0;
    [Tooltip("")]
    public int numKeys = 0;
    [Tooltip("Amount of health potions")]
    public int numHealthPotion = 0;
    [Tooltip("Amount of health potions")]
    public int numSpeedPotion = 0;
}
