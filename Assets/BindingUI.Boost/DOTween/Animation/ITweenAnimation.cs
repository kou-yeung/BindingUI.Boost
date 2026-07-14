using DG.Tweening;

namespace BindingUI.Boost.DOTween
{
    /// <summary>
    /// Binding対象に対して、任意のDOTweenアニメーションを構築します。
    /// </summary>
    public interface ITweenAnimation
    {
        Tween Play<TState>(BindingNode<TState> target);
    }
}
