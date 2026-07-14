using DG.Tweening;
using System;
using UnityEngine;

namespace BindingUI.Boost.DOTween
{
    public sealed class CanvasGroupFadeBinding<TState> : CanvasGroupBinding<TState, float>
    {
        readonly Func<TState, float> durationGetter;
        readonly Func<TState, Ease> easeGetter;

        Tween tween;

        public CanvasGroupFadeBinding(
            CanvasGroup target,
            Func<TState, float> valueGetter,
            Func<TState, float> durationGetter,
            Func<TState, Ease> easeGetter
            ) : base(target, valueGetter)
        {
            this.durationGetter = durationGetter;
            this.easeGetter = easeGetter;
        }

        public override void Apply(TState state)
        {
            tween?.Kill();
            tween = Target
                .DOFade(Getter(state), durationGetter(state))
                .SetEase(easeGetter(state))
                .SetLink(Target.gameObject);
        }
    }
}
