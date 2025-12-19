using UnityEngine;

public class DeathPlayer : Death
{
    public override void die()
    {
        GameManger.Instance.EndGame();
    }//end of die


}//end of death

