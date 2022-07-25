using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    public float deathHeight;
    public float xLimit;
    
    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Update()
    {
        //Nos temos duas Vari�veis do tipo float:
        //deathHeight servir� como o limite que o player pode cair antes de resetar o level
        //xLimit � o limite que ele pode andar no eixo X antes de resetar o level

        //O objetivo � chamar a funcao ResetLevel() da classe LevelManager quando o jogador estiver alem dos limites de xLimit ou deathHeight:
        //Para chamar a funcao ResetLevel da classe LevelManager, voce pode escrever "LevelManager.instance.ResetLevel()"

        //Boa sorte!

    }



}
