using UnityEngine;

public class CoinCollectSystem : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectFX;

    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnCoinEnterEvent += OnCoinEnter;
    }

    private void OnCoinEnter(Coin coin)
    {
        SaveExtension.player.Money += coin.Count;
        SaveExtension.SavePlayerData();
        Destroy(Instantiate(coinCollectFX, coin.transform.position, Quaternion.identity), 2f);
        Destroy(coin.gameObject);
    }

    private void OnDestroy()
    {
        player.OnCoinEnterEvent -= OnCoinEnter;
    }
}
