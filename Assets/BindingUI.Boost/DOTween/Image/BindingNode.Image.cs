using DG.Tweening;
using System;
using UnityEngine.UI;

namespace BindingUI.Boost.DOTween
{
    public static class BindingNodeTweenImageExtensions
    {
        public static BindingNode<TState> TweenFillAmount<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, float duration, Ease ease = Ease.Linear)
        {
            return @this.TweenFillAmount(valueGetter, _ => duration, _ => ease);
        }
        public static BindingNode<TState> TweenFillAmount<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, Func<TState, float> durationGetter, Ease ease = Ease.Linear)
        {
            return @this.TweenFillAmount(valueGetter, durationGetter, _ => ease);
        }

        public static BindingNode<TState> TweenFillAmount<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, Func<TState, float> durationGetter, Func<TState, Ease> easeGetter)
        {
            @this.Add(new ImageFillAmountBinding<TState>(@this.Get<Image>(), valueGetter, durationGetter, easeGetter));
            return @this;
        }
    }
}
