using BindingUI;
using BindingUI.Boost;
using UnityEngine;

public class Sample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    BindingRoot<Vector3> root;
    void Start()
    {
        root = new(gameObject);
        root.Bind("Image").LocalPosition(v => v);

        root.Apply(Vector3.one * 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
