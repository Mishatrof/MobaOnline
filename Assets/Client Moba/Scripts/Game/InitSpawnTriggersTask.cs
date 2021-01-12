using UnityEngine;

namespace Client.Game
{
    public class InitSpawnTriggersTask : MonoBehaviour
    {
        public MineTeamComponent mineTeam;

        public void Execute(SpawnTriggers triggers)
        {
            triggers.gameObject.SetActive(false);

            var team = mineTeam.teamId;
            for (int i = 0; i < triggers.value.Length; i++)
                if (team != i) triggers.value[i].SetActive(false);
        }
    }
}