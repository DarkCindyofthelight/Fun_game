using UnityEngine.Events;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public RacketController enemyRacketController;

    private void OnTriggerEnter(Collider other)
    {
        enemyRacketController.score++;
        


        if (other.CompareTag("Ball"))
        {
            onTriggerEnter.Invoke();

        }

    }

}
