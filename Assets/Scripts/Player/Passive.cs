using UnityEngine;

public class Passive : MonoBehaviour
{
    private PlayerBehaviour playerbehaviouor;
    private PlayerShooting playershooting;
    private EnemyBehavior enemybehavior;
    public void MysterySyringe()
    {
        playerbehaviouor.speed += 2;
    }

    public void HazmatSuit()
    {
        playerbehaviouor.health += 50;
    }

    public void Magnent()
    { 
        // pulls all xp
    }

    public void  MethFlask()
    {
        enemybehavior.methflask = true;
    }

    public void Coffee()
    {
        playershooting.shootInterval += 0.5f;
    }
    public void LosPollosHermanosChicken()
    {
        playerbehaviouor.health += 25;
    }


}
