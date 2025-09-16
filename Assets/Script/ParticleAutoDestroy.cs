using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy: MonoBehaviour
{
    private ParticleSystem ps;

    [Tooltip("Tempo em segundos que o efeito vai emitir partículas antes de parar")]
    public float emissionDuration = 1f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(PlayAndStopAfterSeconds());
    }

    IEnumerator PlayAndStopAfterSeconds()
    {
        ps.Play();

        yield return new WaitForSeconds(emissionDuration);

        ps.Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);

        while (ps.IsAlive(true))
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
