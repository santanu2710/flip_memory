using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class icegame : MonoBehaviour
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

    int[] counter = { 1, 1, 1, 1, 1, 1, 1, 1 };
    bool[] on_off = {false, false, false, false, false, false, false, false };

    void Start()
    {
        Button[] buttons = { b1, b2, b3, b4, b5, b6, b7, b8 };
        Sprite[] water_card = { w1, w2, w1, w4, w2, w3, w3, w4 };

        Shuffle(water_card);

        buttons[0].onClick.AddListener(flip1);

    }

    // Update is called once per frame

    void Update()
    {
        //assign();
    }

    void flip1()
    {
        //counter[0] = 1;
        Image im = b1.GetComponent<Image>();
        if (b1 != null)
        {
            if (counter[0] % 2 == 1)
            {
                im.sprite = w1;
                counter[0]++;
            }
            else
            {
                im.sprite = back_texture;
                counter[0]++;
            }
        }
    }

    void flip2()
    {
        //counter[1] = 1;
        Image im = b2.GetComponent<Image>();
        if (b2 != null)
        {
            if (counter[1] % 2 == 1)
            {
                im.sprite = w2;
                counter[1]++;
            }
            else
            {
                im.sprite = back_texture;
                counter[1]++;
            }
        }
    }

    //void assign()
    //{
    //    b1.GetComponent<Image>().sprite = w1;
    //    b2.GetComponent<Image>().sprite = w2;
    //    b3.GetComponent<Image>().sprite = w3;
    //    b4.GetComponent<Image>().sprite = w4;
    //}


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
}
