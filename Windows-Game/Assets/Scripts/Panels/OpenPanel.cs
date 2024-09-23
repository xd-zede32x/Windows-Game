using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ScriptsPanel
{
    public class OpenPanel : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 0.5f)] private float _animationDuration;
        [SerializeField] private GameObject _panel;
        [SerializeField] private CanvasGroup _canvasGroup;

        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            _openButton.onClick.AddListener(OpenAnimationPanel);
            _closeButton.onClick.AddListener(HideAnimationPanel);
        }

        private void OnDestroy()
        {
            _openButton.onClick.RemoveListener(OpenAnimationPanel);
            _closeButton.onClick.RemoveListener(HideAnimationPanel);
        }

        private void OpenAnimationPanel()
        {
            Debug.Log("ClickButton");

            _panel.SetActive(true);
            StartCoroutine(AnimationPanel(0f, 1f));
        }

        private void HideAnimationPanel()
        {
            StartCoroutine(AnimationPanel(1f, 0f));
            _panel.SetActive(false);
        }

        private IEnumerator AnimationPanel(float startAlpha, float endAlpha)
        {
            float time = 0f;

            while (time < _animationDuration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, endAlpha, time / _animationDuration);
                _canvasGroup.alpha = alpha;

                yield return null;
            }
        }
    }
}