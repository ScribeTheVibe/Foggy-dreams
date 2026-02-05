using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class attack : MonoBehaviour
{
    [SerializeField] Animator attackAnim;

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.actions["Attack"].WasPressedThisFrame())
        {
            attackAnim.SetBool("Fighting", true);
            StartCoroutine(anim());
        }
    }

    IEnumerator anim()
    {
        yield return new WaitForSeconds(0.1f);
        attackAnim.SetBool("Fighting", false);
    }
}
