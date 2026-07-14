using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace BindingUI.Boost.DOTween
{
    public static class BindingNodeTweenFadeGroupExtensions
    {
        public static BindingNode<TState> TweenFade<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, float duration, Ease ease = Ease.Linear)
        {
            return @this.TweenFade(valueGetter, _ => duration, _ => ease);
        }
        public static BindingNode<TState> TweenFade<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, Func<TState, float> durationGetter, Ease ease = Ease.Linear)
        {
            return @this.TweenFade(valueGetter, durationGetter, _ => ease);
        }

        public static BindingNode<TState> TweenFade<TState>(this BindingNode<TState> @this, Func<TState, float> valueGetter, Func<TState, float> durationGetter, Func<TState, Ease> easeGetter)
        {
            if (@this.GameObject.TryGetComponent<CanvasGroup>(out var canvasGroup))
            {
                @this.Add(new CanvasGroupFadeBinding<TState>(canvasGroup, valueGetter, durationGetter, easeGetter));
                return @this;
            }

            if (@this.GameObject.TryGetComponent<Image>(out var image))
            {
                @this.Add(new ImageFadeBinding<TState>(image, valueGetter, durationGetter, easeGetter));
                return @this;
            }

            throw new NotImplementedException($"TweenFade : no 'CanvasGroup' or 'Image'");
        }
    }
}
