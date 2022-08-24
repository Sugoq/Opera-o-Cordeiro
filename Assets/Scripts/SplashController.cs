using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public static SplashController instance;
    private SpriteRenderer sr;
    [SerializeField] Transform surface;
    [SerializeField] float splashDuration;
    [SerializeField] float expandDuration;
    [SerializeField] float waveVelocity;
    [SerializeField] float splashDen;
    int point1Id = Shader.PropertyToID("point1");
    int point2Id = Shader.PropertyToID("point2");
    bool animating;




    Vector2 pos1, pos2;
    public float radius;

    private void Awake()
    {
        instance = this;
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void OnDestroy() => instance = null;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Splash( new Vector2(P1Controller.instance.transform.position.x, surface.position.y));
        }
    }


    public void Splash(Vector2 playerPos)
    {
        if (animating) return;
        animating = true;
        pos1 = pos2 = playerPos;

        StartCoroutine(ChangeRadiusRoutine());
    }

    IEnumerator MovePointsRoutine()
    {
        for(float t = 0; t<1; t+= Time.deltaTime/ splashDuration)
        {
            pos1 += Time.deltaTime * waveVelocity * Vector2.left;
            pos2 += Time.deltaTime * waveVelocity * Vector2.right;
            sr.material.SetVector(point1Id, pos1);
            sr.material.SetVector(point2Id, pos2);
            yield return null;
        }
    }

    IEnumerator ChangeRadiusRoutine()
    {
        sr.material.SetVector(point1Id, pos1);
        sr.material.SetVector(point2Id, pos2);
        sr.material.SetFloat("_splashDen", splashDen);

        for (float t = 0; t < 1; t += Time.deltaTime/ expandDuration)
        {
            sr.material.SetFloat("radius", Mathf.Lerp(0, radius, t));
            yield return null;
        }

        StartCoroutine(MovePointsRoutine());
        for (float t = 0; t < 1; t += Time.deltaTime / splashDuration)
        {

            sr.material.SetFloat("radius", Mathf.Lerp(radius, 0, t*t*t));
            yield return null;
        }
        sr.material.SetFloat("radius", 0);
        animating = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("P1"))Splash(new Vector2(collision.gameObject.transform.position.x,surface.position.y));
    }
}
