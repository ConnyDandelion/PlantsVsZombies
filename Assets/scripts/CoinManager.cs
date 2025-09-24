using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField]

    private UnityEvent<int> onCoinsChanged;

    private int NumberOfCoins = 0;

    public void SetNumberOfCoins(int amount)
    {
        NumberOfCoins = amount;

        onCoinsChanged.Invoke(NumberOfCoins);



    }
    
}
