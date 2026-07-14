using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BindingUI.Boost.DOTween.Sample
{
    public sealed class DoTweenAnimationViewDisplayData
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
        public Color Color3 { get; set; }

        public static DoTweenAnimationViewDisplayData Build()
        {
            return new DoTweenAnimationViewDisplayData
            {
                Color1 = Color.purple,
                Color2 = Color.yellow,
                Color3 = Color.cyan,
            };
        }
    }
}
