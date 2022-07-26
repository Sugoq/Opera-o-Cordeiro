using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    public float yLimit; //O Y É O LIMITE VERTICAL, - É PRA BAIXO +PRA CIMA
    public float xLimit; //O X É O LIMITE HORIZONTAL, - É PRA TRAS + PRAFRENTE
    
    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Update()
    {
        //Nos temos duas Variáveis do tipo float:
        //deathHeight servirá como o limite que o player pode cair antes de resetar o level
        //xLimit é o limite que ele pode andar no eixo X antes de resetar o level

        //O objetivo é chamar a funcao ResetLevel() da classe LevelManager quando o jogador estiver alem dos limites de xLimit ou deathHeight:
        //Para chamar a funcao ResetLevel da classe LevelManager, voce pode escrever "LevelManager.instance.ResetLevel()"

        //Boa sorte!

        if (P1Controller.instance.transform.position.x > xLimit || P1Controller.instance.transform.position.x < -xLimit)
        {
            LevelManager.instance.ResetLevel();
        }
        if (P1Controller.instance.transform.position.y < yLimit)
        {
           LevelManager.instance.ResetLevel();
        }

    }



}
