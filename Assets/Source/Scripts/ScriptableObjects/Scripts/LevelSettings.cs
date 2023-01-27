using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/LevelSettingsObject", order = 1)]
public class LevelSettings : ScriptableObject
{
    public Level[] levels;
}

[Serializable]
public class Level
{
    public GameObject levelPrefab;
    public Coin coinPrefab;
    public int coinCount;
    public int moneyPerOneCoin;
    public float coinOffset;
}
