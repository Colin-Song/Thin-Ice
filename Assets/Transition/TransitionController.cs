using UnityEngine;
using UnityEngine.UI;


public class TransitionController : MonoBehaviour
{
    private Animator _animator;
    private Image _image;
    private readonly int _circleSizeId = Shader.PropertyToID("_Circle_Size");

    public float circleSize = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.materialForRendering.SetFloat("_Circle_Size", circleSize);
    }
}
