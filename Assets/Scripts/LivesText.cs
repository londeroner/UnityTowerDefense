using UnityEngine;

public class LivesText : MonoBehaviour
{
    public UnityEngine.UI.Text lives;

    void Update()
    {
        lives.text = "Lives: " + PlayerStats.Lives;
    }
}
