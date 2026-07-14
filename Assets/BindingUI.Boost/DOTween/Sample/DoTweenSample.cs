using UnityEngine;

namespace BindingUI.Boost.DOTween.Sample
{
    public sealed class DoTweenSample : MonoBehaviour
    {
        BindingRoot<DoTweenSampleDisplayData> rootSample;
        BindingRoot<DoTweenAnimationDisplayData> rootAnimation;

        private void Start()
        {
            var resolver = new HierarchyBindingNodeResolver(gameObject);
            BuildSampleRoot(resolver);
            BuildAnimationRoot(resolver);
        }

        /// <summary>
        /// Sample for one line tween
        /// </summary>
        /// <param name="resolver"></param>
        private void BuildSampleRoot(HierarchyBindingNodeResolver resolver)
        {
            rootSample = new BindingRoot<DoTweenSampleDisplayData>(resolver);
            rootSample.Bind("Bar")
                .FillAmount(v => v.BarStartValue)                   // set the start amount
                .TweenFade(v => v.Fade, v => v.BarDuration)         // do fade animation
                .TweenFillAmount(v => v.BarEndValue, v => v.BarDuration); // do fill amount animation
        }

        public void OnBackClick()
        {
            rootSample.Apply(DoTweenSampleDisplayData.Build(DoTweenSampleDisplayData.State.Back));
        }
        public void OnNextClick()
        {
            rootSample.Apply(DoTweenSampleDisplayData.Build(DoTweenSampleDisplayData.State.Next));
        }

        /// <summary>
        /// Sample for Animation
        /// </summary>
        /// <param name="resolver"></param>
        private void BuildAnimationRoot(HierarchyBindingNodeResolver resolver)
        {
            rootAnimation = new BindingRoot<DoTweenAnimationDisplayData>(resolver);
            rootAnimation.Bind("Bar")
                .TweenAnimation(v => v.Animation);  // apply tween animation
        }
        public void OnAnimationClick()
        {
            rootAnimation.Apply(DoTweenAnimationDisplayData.Build());
        }
    }
}
