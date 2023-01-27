using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private GameObject finishUI;

    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnFinishEnterEvent += OnFinish;
        nextLevelButton.onClick.AddListener(NextLevel);
        SaveExtension.player.onMoneyChangeEvent += OnCoinCollect;
        moneyText.text = SaveExtension.player.Money.ToString();
    }

    private void OnFinish()
    {
        finishUI.SetActive(true);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCoinCollect()
    {
        moneyText.text = SaveExtension.player.Money.ToString();
    }

    private void OnDestroy()
    {
        player.OnFinishEnterEvent -= OnFinish;
        SaveExtension.player.onMoneyChangeEvent -= OnCoinCollect;
        nextLevelButton.onClick.RemoveListener(NextLevel);
    }
}
