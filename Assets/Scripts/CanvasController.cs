using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject Panel; 
    public void OpenPanel(){
   // Debug.Log("Attempting to toggle panel visibility");
    Animator animator = Panel.GetComponent<Animator>();
    if(animator != null){
        bool isOpen = animator.GetBool("isVisible");
       // Debug.Log("Panel is currently visible: " + isOpen);
        animator.SetBool("isVisible", !isOpen);
    } else {
       // Debug.Log("Animator component not found on panel");
    }
}

}
