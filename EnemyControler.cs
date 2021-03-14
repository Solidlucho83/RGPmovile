using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public float enemySpeed = 1;
    private Rigidbody2D enemyRigidbody;

    private bool isMoving;//saber si se esta moviendo o no

    public float timeBetweenSteps;//tiempo entre movimientos
    private float timeBetweenStepsCounter;//contador cuanto tiempo a pasado desde el ultimo movimiento

    public float timeToMakeStep;//el tiempo que pasa en hacer el paso de una celda a la siguiente
    private float timeToMakeStepCounter;//el condador de cuanto tiempo a pasado en hacer el paso

    public Vector2 directionToMakeStep;//una direccion de movimiento

    private Animator enemyAnimator;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    // Start is called before the first frame update
    void Start() 
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        timeBetweenStepsCounter = timeBetweenSteps*Random.Range(0.5f, 1.5f);//se inicialice con la informacion que le ponemos en unity
        timeToMakeStepCounter = timeToMakeStep * Random.Range(0.5f, 1.5f); //se inicialice con la informacion que le ponemos en unity

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;//descuenta el tiempo del ultimo renderisado
            enemyRigidbody.velocity = directionToMakeStep;//movemos al enemigo a la direccion

            if (timeToMakeStepCounter < 0)//si se acaba el tiempo de movimiento
            {
                isMoving = false;//pone en falso el movimiento
                timeBetweenStepsCounter = timeBetweenSteps;//reinicia el contador
                enemyRigidbody.velocity = Vector2.zero;//para el movimiento
            }
        }
        else//si no se esta moviendo
        {
            timeBetweenStepsCounter -= Time.deltaTime;//resta tiempo al contador
            if (timeBetweenStepsCounter < 0)//si se acaba el tiempo de espera para el siguiente
            {
                isMoving = true;//ponemos en true para empesar a movernos
                timeToMakeStepCounter = timeToMakeStep;//re iniciamos el contador
                directionToMakeStep = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)) * enemySpeed;//nos movemos
            }
        }

        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x);//lo movemos ya con los valores dados
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y);//lo movemos ya con los valores dados
    
}
}
