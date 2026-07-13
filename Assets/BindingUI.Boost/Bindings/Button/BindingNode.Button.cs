using R3;
using UnityEngine.UI;

namespace BindingUI.Boost
{
    public static class BindingNodeButtonExtensions
    {
        public static Observable<Unit> OnClickAsObservable<TState>(this BindingNode<TState> @this)
        {
            return @this.Get<Button>().OnClickAsObservable();
        }
    }
}
