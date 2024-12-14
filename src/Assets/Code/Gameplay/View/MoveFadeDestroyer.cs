using UnityEngine;
using DG.Tweening;
using System;

namespace Assets.Code.Gameplay.View
{
    public class MoveFadeDestroyer : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private float _duration = 1f;

        [SerializeField]
        private float _moveDeltaY = -1f;

        public void Destroy()
        {
            Sequence sequence = DOTween.Sequence()
                .Join(Fade())
                .Join(Move())
                .OnComplete(() => Destroy(gameObject))
                .Play();
        }

        private Tween Move()
        {
            return gameObject.transform
                .DOMoveY(transform.position.y - _moveDeltaY, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }

        private Tween Fade()
        {
            return _spriteRenderer.DOFade(0, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }
    }
}