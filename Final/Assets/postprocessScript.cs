using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postprocessScript : MonoBehaviour {
    ColorGrading ColorGradinglayer = null;
    public float minimum = -100f;
    public float maximum = 0f;
    public float T = 0.0f;
    public float duration = 5f;

    // Use this for initialization
    void Start() {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out ColorGradinglayer);
        ColorGradinglayer.saturation.value = 0f;
        T = 0.0f;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
            T = 0;
            T += Time.deltaTime / duration;
        var value = Mathf.Lerp(minimum, maximum, T);
        ColorGradinglayer.saturation.value = value;
        
    }


}
