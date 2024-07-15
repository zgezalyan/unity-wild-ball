using UnityEngine;

namespace WildBall.Inputs
{
    public class GlobalVars
    {
        #region InputWars
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string JumpButton = "Jump";
        public const KeyCode ActionCode = KeyCode.E;
        #endregion

        #region GameWars
        public const string FloorPhisicsMaterial = "FloorPhisMaterial (Instance)";
        public const string FinishName = "Finish";
        public const string DeathFallName = "DeathFall";
        public const string SpikePhisicsMaterial = "SpikePhisMaterial (Instance)";
        public const string ActivatorName = "Activator";
        public const string BallName = "Ball";
        #endregion

        #region NamesAndCaps
        public const string Level1Name = "Level 1\nIntroduction";
        public const string Level2Name = "Level 2\nJumps";
        public const string Level3Name = "Level 3\nSpikes";
        public const string Level4Name = "Level 4\nMechanisms";
        public const string Level5Name = "Level 5\nFinale";
        public const string Level6Name = "Level 6\nBonus";
        public const string Level1Cap = "GREEN FLOOR IS FINISH"; 
        public const string Level2Cap = "PRESS SPACE TO JUMP";
        public const string Level3Cap = "RED SPIKES ARE DEATH";
        public const string Level4Cap = "ORANGE FLOOR ACTIVATES MECHANISMS";
        public const string Level5Cap = "GOOD LUCK!";
        public const string Level6Cap = "GOOD LUCK!";
        #endregion

    }
}
