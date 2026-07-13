using System;
using UnityEngine;

namespace BindingUI.Boost
{
    public static class BindingNodeRectTransformExtensions
    {
        public static BindingNode<TState> LocalPosition<TState>(this BindingNode<TState> @this, Func<TState, Vector3> getter)
        {
            @this.Add(new RectTransformLocalPositionBinding<TState>(@this.Get<RectTransform>(), getter));
            return @this;
        }
    }
}
