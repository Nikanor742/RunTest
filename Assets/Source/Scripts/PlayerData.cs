using System;

[Serializable]
public class PlayerData
{
    public event Action onMoneyChangeEvent;
    public int level = 0;

    public int money;
    public int Money
    {
        get { return money; }
        set 
        {
            money = value;
            onMoneyChangeEvent?.Invoke();
        }
    }
}
