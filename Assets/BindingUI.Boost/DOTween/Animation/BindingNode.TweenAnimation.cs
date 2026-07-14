using System;

namespace BindingUI.Boost.DOTween
{
    public static class BindingNodeTweenAnimationExtensions
    {
        public static BindingNode<TState> TweenAnimation<TState>(this BindingNode<TState> node, Func<TState, ITweenAnimation> getter)
        {
            node.Add(new TweenAnimationBinding<TState>(node, getter));
            return node;
        }
    }
}