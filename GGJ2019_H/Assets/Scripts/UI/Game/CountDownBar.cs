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
        bar.fillAmount = 1;
        timeText.text = ArenaManager.Instance.ArenaTime.ToString("0.00");
    }

    private void onTimeChange()
    {
        float value = timer.Current / ArenaManager.Instance.ArenaTime;
        bar.fillAmount = value;
        timeText.text = timer.Current.ToString("0.00");
    }
}
