using Assets.Code.Data;
using Assets.Code.Infrastructure.Services.StaticData;
using Assets.Code.StaticData;
using UnityEngine;
using Zenject;

namespace Assets.Code.Gameplay.View
{
    public class Hat : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [Inject]
        private IStaticDataService _staticDataService;

        private void OnValidate()
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
        }

        public void SetHat(HatTypeId hatTypeId)
        {
            if (hatTypeId == HatTypeId.Unknown)
            {
                _spriteRenderer.enabled = false;
                return;
            }

            HatConfig config = _staticDataService.GetHatConfig(hatTypeId);
            _spriteRenderer.sprite = config.Sprite;
        }
    }
}