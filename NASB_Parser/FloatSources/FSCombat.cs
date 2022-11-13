using System;
using System.Collections.Generic;
using System.Text;

namespace NASB_Parser.FloatSources
{
    public class FSCombat : FloatSource
    {
        public Attributes Attribute { get; set; }

        public FSCombat()
        {
        }

        internal FSCombat(BulkSerializeReader reader) : base(reader)
        {
            Attribute = (Attributes)reader.ReadInt();
        }

        public override void Write(BulkSerializeWriter writer)
        {
            base.Write(writer);
            writer.Write(Attribute);
        }

        public enum Attributes
        {
            Weight,
            Getgrabbed,
            Grabinvulnerability,
            BlockPush,
            DamageTaken,
            InvincibleBoonFrames,
            RespawnInvincibleFrames,
            Projectilelevel,
            BlockHoldVertical,
            BlockHoldHorizontal,
            LastDIType,
            LastDIIn,
            LastDIOut,
            LastBlastzone,
            CheckBlastzones,
            CheckTopBlastzone,
            LastTurn,
            LastRedirectX,
            LastRedirectY,
            LaunchedByPlayerIndex,
            LaunchedByTeam,
            LastHitType,
            LastHitDirection,
            LastHitForward,
            AlwaysLaunch,
            IsProjectile,
            LaunchedByGameTeam,
            LastHitForceJabReset,
            PreventHitstunTurn,
            PreventLaunches,
            ComboCount,
            CanGrabClang
        }
    }
}