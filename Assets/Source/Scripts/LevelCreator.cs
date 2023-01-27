using System.Collections;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public LevelSettings levelSettings;

    private void Awake()
    {
        SaveExtension.Override();
        LoadLevel(levelSettings.levels[SaveExtension.player.level]);
        CreateCoins(levelSettings.levels[SaveExtension.player.level]);
    }


    private IEnumerator Analytics()
    {
        yield return new WaitForSeconds(0.01f);
        if (GAManager.Instance == null)
        {
            StartCoroutine(Analytics());
        }
        else
        {
            GAManager.Instance.LevelStart(SaveExtension.player.level);
        }
    }
    private void LoadLevel(Level level)
    {
        if (SaveExtension.player.level == levelSettings.levels.Length - 1)
        {
            SaveExtension.player.level = 0;
            SaveExtension.SavePlayerData();
        }

        StartCoroutine(Analytics());
        Instantiate(level.levelPrefab, Vector3.zero, Quaternion.identity);
    }

    private void CreateCoins(Level level)
    {
        for (int i = 0; i < level.coinCount; i++)
        {
            Vector3 coinPosition = new Vector3(0, 1, level.coinOffset * (i + 1) + 1f);
            Instantiate(level.coinPrefab, coinPosition, Quaternion.identity).SetCount(level.moneyPerOneCoin);
        }
    }
}
