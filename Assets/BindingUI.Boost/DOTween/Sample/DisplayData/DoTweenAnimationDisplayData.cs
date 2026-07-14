using DG.Tweening;
using UnityEngine.UI;

namespace BindingUI.Boost.DOTween.Sample
{
    sealed class DoTweenAnimationDisplayData
    {
        public ITweenAnimation Animation { get; set; }


        public static DoTweenAnimationDisplayData Build()
        {
            return new DoTweenAnimationDisplayData
            {
                Animation = new BarTweenAnimation()
            };
        }
    }

    sealed class BarTweenAnimation : ITweenAnimation
    {
        Tween ITweenAnimation.Play<TState>(BindingNode<TState> target)
        {
            var sequence = DG.Tweening.DOTween.Sequence();

            var image = target.Get<Image>();

            sequence
                .Join(image.DOFade(1, 0))
                .Join(image.DOFillAmount(1f, 0.25f).From(0f))
                .Append(image.DOFillAmount(0f, 0.25f));

            sequence.Play();
            return sequence;
        }
    }
}
