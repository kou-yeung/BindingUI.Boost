using System;
using UnityEngine;

namespace BindingUI.Boost
{
    public sealed class RectTransformLocalPositionBinding<TState> : RectTransformBinding<TState, Vector3>
    {
        public RectTransformLocalPositionBinding(RectTransform target, Func<TState, Vector3> getter) : base(target, getter)
        {
        }

        public override void Apply(TState state)
        {
            Target.localPosition = Getter(state);
        }
    }
}
