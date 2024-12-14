using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Gameplay.View.UI
{
    public class PunchAnimator : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _target;

        [SerializeField]
        private float _targetScale = 0.55f;

        [SerializeField]
        private float _duration = 0.2f;

        private Tweener _currentTweener;

        public void Animate()
        {
            _currentTweener?.Kill(true);

            _currentTweener = _target.DOPunchScale(Vector3.one * _targetScale, _duration)
                .SetEase(Ease.InOutCubic)
                .SetLink(gameObject);
        }
    }
}