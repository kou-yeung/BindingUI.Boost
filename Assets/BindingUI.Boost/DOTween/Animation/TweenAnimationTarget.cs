using System;
using UnityEngine;

namespace BindingUI.Boost.DOTween
{
    public readonly struct TweenAnimationTarget
    {
        public GameObject GameObject { get; }

        public Transform Transform => GameObject.transform;

        internal TweenAnimationTarget(GameObject gameObject)
        {
            GameObject = gameObject != null
                ? gameObject
                : throw new ArgumentNullException(nameof(gameObject));
        }

        public T Get<T>() where T : Component
        {
            var component = GameObject.GetComponent<T>();

            if (component != null)
            {
                return component;
            }

            throw new MissingComponentException(
                $"Component '{typeof(T).Name}' was not found on " +
                $"'{GameObject.name}'.");
        }

        public bool TryGet<T>(out T component)
            where T : Component
        {
            return GameObject.TryGetComponent(out component);
        }
    }
}