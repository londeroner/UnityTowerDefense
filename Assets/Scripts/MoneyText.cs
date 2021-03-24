using UnityEngine;

public class MoneyText : MonoBehaviour
{
    public UnityEngine.UI.Text money;

    void Update()
    {
        money.text = "$" + PlayerStats.Money;
    }
}
