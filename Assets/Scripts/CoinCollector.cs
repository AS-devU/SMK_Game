using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text coinText;
    public Text winText;
    public Button newLevelButton, quitButton;
    public Image progressBar;
    public int coinCounter = 0;
    public int targetCoins = 0;
    private void Update()
    {
        if (coinCounter >= targetCoins) // When we have collected all the coins . . .
        {
            winText.text = "You win!"; // Display the text! In hindsight, I could just activate the gameobject like I do with button but uhhhhh-
            newLevelButton.gameObject.active = true; // Display the restart button! It's functionality is in a separate script.
            quitButton.gameObject.active = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Coin") // If the player character touches a coin . . .
        {
            coinCounter++; // Increase coin count.
            coinText.text = "Coins: " + coinCounter + "/" + targetCoins; // Update the UI.
            Destroy(collision.gameObject); // Wipe the coin from existance.
            float progressNum = (float)coinCounter / (float)targetCoins;
            progressBar.fillAmount = progressNum;
        }
    }
    private void Start()
    {
        progressBar.fillAmount = 0;
        float progressNum = (float)coinCounter / (float)targetCoins;
        progressBar.fillAmount = progressNum;
        coinText.text = "Coins: " + coinCounter + "/" + targetCoins;
    }
}
