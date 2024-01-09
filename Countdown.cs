using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownText;
    public Text gameOverText;
    public int countdownCount;
    public int defaultCountdown;
    public bool pause;

    void Start()
    {
        countdownCount = defaultCountdown;
        countdownText.text = countdownCount.ToString();
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        while (countdownCount > 0)
        {
            if (!pause)
            {
                yield return new WaitForSeconds(1f);
                countdownCount--;
                countdownText.text = countdownCount.ToString();
            } else
            {
                yield return new WaitForSeconds(0.1f);
                countdownText.text = countdownCount.ToString();
            }
        }
        gameOverText.enabled = true;
        yield return new WaitForSeconds(2f);
        gameOverText.enabled = false;
        Application.LoadLevel(Application.loadedLevel);
    }

    public int GetTime()
    {
        return defaultCountdown - countdownCount;
    }
}
