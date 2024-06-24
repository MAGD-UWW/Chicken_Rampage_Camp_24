using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenseEnemyMovement : MonoBehaviour
{
    [Header("Needs 'Enemy Health' script in order to be targeted by Defense Towers")]
    [Tooltip("The next node we are moving to.")]
    public GameObject target;
    public TowerDefenseEnemyMotor motor;
    public float minDistanceToAdvance = 0.1f;
    public float distanceToTarget = 100;
    [SerializeField] private List<Transform> pathNodes;

    public int currentNodeInt = 0;
    [SerializeField] int angleOffset;
    [SerializeField] private bool rotateTowardTargetNode = true;

    Transform currentNodeTransform; 

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<IMove>() is TowerDefenseEnemyMotor ?  GetComponent<TowerDefenseEnemyMotor>() : gameObject.AddComponent<TowerDefenseEnemyMotor>();
        Debug.Log("Motor: " + motor);
        motor.moveSpeed = 3;

        pathNodes = GameObject.FindObjectOfType<TowerDefensePath>().getPath();
    }
    
    void FixedUpdate()
    {
        if (pathNodes.Count == 0 || currentNodeInt >= pathNodes.Count) return;

        currentNodeTransform = pathNodes[currentNodeInt];

        if (currentNodeInt >= pathNodes.Count) return;
        currentNodeTransform = pathNodes[currentNodeInt]; 
        // var distance = Vector3.Distance(transform.position, currentNodeTransform.position);
        distanceToTarget = Vector3.Distance(transform.position, currentNodeTransform.position);
        if (distanceToTarget > minDistanceToAdvance)
        {

            var dir = currentNodeTransform.position - transform.position;
            if (rotateTowardTargetNode)
            {
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            //
            motor.Move(new Vector2(currentNodeTransform.position.x, currentNodeTransform.position.y));
        } else
        {
            currentNodeInt++;
        }
    }
}
