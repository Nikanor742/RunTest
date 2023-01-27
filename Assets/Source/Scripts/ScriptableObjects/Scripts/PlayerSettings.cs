using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettingsObject", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float playerSpeed;
    public float leftBorder;
    public float rightBorder;
}
