using UnityEngine;

public class FinishSystem : MonoBehaviour
{
    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnFinishEnterEvent += OnFinishEnter;
    }

    private void OnFinishEnter()
    {
        GAManager.Instance.LevelWin(SaveExtension.player.level);
        SaveExtension.player.level++;
        SaveExtension.SavePlayerData();
    }

    private void OnDestroy()
    {
        player.OnFinishEnterEvent -= OnFinishEnter;
    }
}
