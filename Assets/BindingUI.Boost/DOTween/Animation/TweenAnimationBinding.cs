using System;
using DG.Tweening;

namespace BindingUI.Boost.DOTween
{
    internal sealed class TweenAnimationBinding<TState> : IBinding<TState>
    {
        readonly BindingNode<TState> node;
        readonly Func<TState, ITweenAnimation> getter;

        Tween currentTween;

        public TweenAnimationBinding(BindingNode<TState> node, Func<TState, ITweenAnimation> getter)
        {
            this.node = node ?? throw new ArgumentNullException(nameof(node));
            this.getter = getter ?? throw new ArgumentNullException(nameof(getter));
        }

        public void Apply(TState state)
        {
            currentTween?.Kill();
            currentTween = null;

            var animation = getter(state);

            if (animation == null)
            {
                return;
            }

            //var target = new TweenAnimationTarget(node.GameObject);

            currentTween = animation.Play(node);

            if (currentTween == null)
            {
                return;
            }

            /*
             * Animation実装側でSetLinkしてもよいですが、
             * Binding側で保証した方が安全です。
             */
            currentTween.SetLink(node.GameObject, LinkBehaviour.KillOnDestroy);
        }
    }
}