using TMPro;
using System;
using UnityEngine;

namespace ScriptsTime
{
    public class DateTimeDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _dayText;

        private void Awake()
        {
            UpdateTime();
            UpdateDay();

            InvokeRepeating(nameof(UpdateTime), 1f, 1f);
            InvokeRepeating(nameof(UpdateDay), 86400f, 86400f);
        }

        private void UpdateTime()
        {
            var time = DateTime.Now;
            _timeText.text = $"{time.Hour}:{time.Minute}:{time.Second}";
        }

        private void UpdateDay()
        {
            var day = DateTime.Now;
            _dayText.text = $"{day.Day}:{day.Month}:{day.Year}";
        }
    }
}