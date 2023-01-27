using UnityEngine;

public class Coin : MonoBehaviour
{
    private int count;
    public int Count => count;

    public void SetCount(int count)
    {
        this.count = count;
    }
}
