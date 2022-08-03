using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeltaTime : MonoBehaviour
{
    public Text TimeField;
    public GameObject[] Hangman;
    public Text WordToFindField;
    private float time;
    private string[] WordLocal = { "Dennis", "merry", "Jhon", "Wick", "Imran", "Danish", "Bhatti", "Saif", "Sherry" };
    private string ChosenWord;
    private string HiddenWord;
    private int fails;


    // Start is called before the first frame update
    void Start()
    {
         

        ChosenWord = WordLocal[Random.Range(0, WordLocal.Length)];


        for (int i = 0; i < ChosenWord.Length; i++)
        {
            char Letter = ChosenWord[i];
            if (char.IsWhiteSpace(Letter))
            {
                HiddenWord += " ";
            }
            else
            {
                HiddenWord += " _ ";
            }
        }

        WordToFindField.text = HiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimeField.text = time.ToString();
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string PressedKey = e.keyCode.ToString();
            Debug.Log("KeyDdown Event was triggered" + PressedKey);

            if (ChosenWord.Contains(PressedKey))
            {
                int i = ChosenWord.IndexOf(PressedKey);
                while (i != -1)
                {
                    HiddenWord = HiddenWord[..i] + PressedKey + HiddenWord[(i + 1)..];
                    Debug.Log(HiddenWord);

                    ChosenWord = ChosenWord[..i] + "_" + ChosenWord[(i + 1)..];
                    Debug.Log(ChosenWord);

                    i = ChosenWord.IndexOf(PressedKey);
                }
                WordToFindField.text = HiddenWord;

            }
            else
            {
                Hangman[fails].SetActive(true);
                fails++;
            }
        }

    }
}
