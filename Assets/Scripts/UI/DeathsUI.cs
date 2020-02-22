using System.Collections;
using UnityEngine;

namespace StoneDefense
{
    public class DeathsUI : MonoBehaviour
    {
        public GameController controller;
        public GameObject deathIconPrefab;

        protected const float k_HeartIconAnchorWidth = 0.051f;

        void Start()
        {
            UpdateDeathsUi();
        }

        public void UpdateDeathsUi()
        {
            for (int i = 0; i < controller.DeathsCount; i++)
            {
                GameObject deathIcon = Instantiate (deathIconPrefab);
                deathIcon.transform.SetParent (transform);
                RectTransform deathIconRect = deathIcon.transform as RectTransform;
                deathIconRect.anchoredPosition = Vector2.zero;
                deathIconRect.anchorMin += new Vector2(k_HeartIconAnchorWidth, 0f) * i;
                deathIconRect.anchorMax += new Vector2(k_HeartIconAnchorWidth, 0f) * i;
            }
        }
    }
}