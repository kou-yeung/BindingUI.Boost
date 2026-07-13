using System;
using UnityEngine;

namespace BindingUI.Boost
{
    public abstract class RectTransformBinding<TState, TValue> : ComponentBinding<TState, RectTransform, TValue>
    {
        protected RectTransformBinding(RectTransform target, Func<TState, TValue> getter) : base(target, getter)
        {
        }
    }
}
