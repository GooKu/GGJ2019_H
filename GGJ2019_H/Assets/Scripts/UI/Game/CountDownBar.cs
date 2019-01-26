using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Image bar;

    void Start()
    {
        timer.OnTimeChange += onTimeChange;
    }

    private void onTimeChange()
    {
        float value = timer.Current / 1;
        bar.fillAmount = value;
        timeText.text = timer.Current.ToString("0.00");
    }
}
