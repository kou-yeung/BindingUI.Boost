using DG.Tweening;
using UnityEngine;

namespace BindingUI.Boost.DOTween.Sample
{
    /// <summary>
    /// Render時の
    /// </summary>
    public class TweenAnimationView : MonoBehaviour, IRenderable<DoTweenAnimationViewDisplayData>, IBindingMarker
    {
        Sequence sequence;
        public GameObject GameObject => this.gameObject;

        BindingRoot<Color> bindingRoot;
        RectTransform imageRectTransform;
        private void Start()
        {
            bindingRoot = new BindingRoot<Color>(gameObject);

            imageRectTransform = bindingRoot
                .Bind("Image")
                .Color(v => v)
                .Get<RectTransform>();
        }
        public void Render(DoTweenAnimationViewDisplayData data)
        {
            sequence?.Kill();

            sequence = DG.Tweening.DOTween.Sequence();

            sequence
                .AppendCallback(() => bindingRoot.Apply(data.Color1))
                .Append(imageRectTransform.DOLocalMoveX(200, 0.5f))
                .AppendInterval(0.25f)
                .AppendCallback(() => bindingRoot.Apply(data.Color2))
                .Append(imageRectTransform.DOLocalMoveX(-200, 0.5f))
                .AppendInterval(0.25f)
                .AppendCallback(() => bindingRoot.Apply(data.Color3))
                .Append(imageRectTransform.DOLocalMoveX(0, 0.5f));
        }
    }
}
