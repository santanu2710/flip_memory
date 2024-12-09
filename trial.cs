using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trial : MonoBehaviour
{
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;

    public Sprite back_texture;

    public Sprite w1;
    public Sprite w2;
    public Sprite w3;
    public Sprite w4;

    public GameObject congratulationsMessage; // GameObject for the "Congratulations" message

    private int counter = 1;
    private int matchedPairs = 0;

    private Button firstButton;
    private Button secondButton;
    private Sprite firstSprite;
    private Sprite secondSprite;

    private bool isWaitingForSecondClick = false;

    void Start()
    {
        congratulationsMessage.SetActive(false); // Hide the message initially

        Button[] buttons = { b1, b2, b3, b4, b5, b6, b7, b8 };
        Sprite[] water_card = { w1, w2, w1, w4, w2, w3, w3, w4 }; // Double up the sprites for matching pairs

        // Shuffle water_card array
        Shuffle(water_card);

        // Assign listeners to buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Local copy of the index to pass to listener
            buttons[i].onClick.AddListener(() => FlipCard(buttons[index], water_card[index]));
        }
    }

    void Shuffle(Sprite[] array)
    {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Sprite value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    void FlipCard(Button button, Sprite cardSprite)
    {
        if (isWaitingForSecondClick) return; // Ignore clicks while waiting for second card flip

        Image im = button.GetComponent<Image>();
        if (button != null)
        {
            im.sprite = cardSprite; // Flip the card face up

            if (counter % 2 == 1)
            {
                // First card flipped
                firstButton = button;
                firstSprite = cardSprite;
                counter++;
            }
            else
            {
                // Second card flipped
                secondButton = button;
                secondSprite = cardSprite;
                counter++;

                // Check if the cards match
                isWaitingForSecondClick = true;
                StartCoroutine(CheckForMatch());
            }
        }
    }

    IEnumerator CheckForMatch()
    {
        // Wait a moment to let the second card appear
        yield return new WaitForSeconds(0.5f);

        if (firstSprite == secondSprite)
        {
            // Cards match, leave them face up
            firstButton.interactable = false;
            secondButton.interactable = false;

            matchedPairs++;

            // Check if all pairs are matched
            if (matchedPairs == 4) // Total number of pairs in the game
            {
                ShowCongratulationsMessage();
            }
        }
        else
        {
            // Cards don't match, flip them back
            firstButton.GetComponent<Image>().sprite = back_texture;
            secondButton.GetComponent<Image>().sprite = back_texture;
        }

        // Reset for next turn
        isWaitingForSecondClick = false;
    }

    void ShowCongratulationsMessage()
    {
        congratulationsMessage.SetActive(true); // Show the "Congratulations" message
    }
}

