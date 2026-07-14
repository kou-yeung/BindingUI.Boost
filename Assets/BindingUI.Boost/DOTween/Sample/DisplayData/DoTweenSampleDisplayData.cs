namespace BindingUI.Boost.DOTween.Sample
{
    sealed class DoTweenSampleDisplayData
    {
        public enum State
        {
            Back,
            Next,
        }

        public float BarStartValue { get; set; }
        public float BarEndValue { get; set; }
        public float BarDuration { get; set; }
        public float Fade { get; set; }


        public static DoTweenSampleDisplayData Build(State state)
        {
            return new DoTweenSampleDisplayData
            {
                BarStartValue = state == State.Next ? 0 : 1,
                BarEndValue = state == State.Next ? 1 : 0,
                BarDuration = 0.5f,
                Fade = state == State.Next ? 1 : 0,
            };
        }
    }
}
