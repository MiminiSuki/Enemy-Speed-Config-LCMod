using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: AssemblyTitle("EnemySpeedConfig")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("EnemySpeedConfig")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("afaf5352-a47d-4dbc-a78f-0b8683eb7098")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework(".NETFramework,Version=v4.7.2", FrameworkDisplayName = ".NET Framework 4.7.2")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace EnemySpeedConfig
{
    [BepInPlugin("MiminiSusuki.EnemySpeedConfig", "Enemy Speed Config Mod", "1.0.0.0")]
    public class SpeedBase : BaseUnityPlugin
    {
        private const string modGUID = "MiminiSusuki.EnemySpeedConfig";

        private const string modName = "Enemy Speed Config Mod";

        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony("MiminiSusuki.EnemySpeedConfig");

        public static SpeedBase Instance;

        internal ManualLogSource mls;


        public ConfigEntry<float> baboonSpeedConfig;
        public ConfigEntry<float> blobSpeedConfig;
        public ConfigEntry<float> beeSpeedConfig;

        public ConfigEntry<float> brakenSpeedConfig;
        public ConfigEntry<float> brakenEnterAngerConfig;

        public ConfigEntry<float> butlerBeeDoAIIntervalConfig;
        public ConfigEntry<float> butlerSpeedConfig;

        public ConfigEntry<float> centipedeSpeedConfig;
        public ConfigEntry<float> claySurgeonSpeedConfig;

        public ConfigEntry<float> coilheadDoAIIntervalConfig;
        public ConfigEntry<float> coilheadSpeedConfig;

        public ConfigEntry<float> ghostGirlSpeedConfig;
        public ConfigEntry<float> ghostGirlBeginChasingConfig;

        public ConfigEntry<float> giantSpeedConfig;

        public ConfigEntry<float> jesterSpeedConfig;
        public ConfigEntry<float> jesterDoAIIntervalConfig;
        public ConfigEntry<float> jesterPopUpConfig;
        public ConfigEntry<float> jesterBeginCrankConfig;

        public ConfigEntry<float> lootBugSpeedConfig;
        public ConfigEntry<float> MaskedSpeedConfig;
        public ConfigEntry<float> oldBirdSpeedConfig;
        public ConfigEntry<float> blindDogSpeedConfig;

        public ConfigEntry<float> caveDwellerBabyGrowthConfig;
        public ConfigEntry<float> caveDwellerDoBabyAIIntervalConfig;
        public ConfigEntry<float> caveDwellerSpeedConfig;
        public ConfigEntry<float> caveDwellerbecomeAdultAnimationSpeedConfig;
        public ConfigEntry<float> caveDwellerNonBabySpeedConfig;

        public ConfigEntry<float> nutCrackerTurnSpeedConfig;
        public ConfigEntry<float> nutCrackerSpeedConfig;

        public ConfigEntry<float> sporeLizardSpeedConfig;

        public ConfigEntry<float> tulipSnakeLeapSpeedConfig;
        public ConfigEntry<float> tulipSnakeDoAIIntervalConfig;

        public ConfigEntry<float> spiderSpeedConfig;

        public ConfigEntry<float> thumperSpeedConfig;
        public ConfigEntry<float> thumperSpeedAccelerationEffectConfig;
        public ConfigEntry<float> thumperSpeedIncreaseRateConfig;

        public ConfigEntry<float> sandWormSpeedConfig;

        private void Awake()
        {
            if ((System.Object)(object)Instance == null)
            {
                Instance = this;
            }
            loadConfig();
            harmony.PatchAll(typeof(SpeedBase));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.LootBugPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.BeePatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.MouthDogPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.BaboonPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.BlobPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.ButlerPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.ButlerBeePatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.BabyPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.CentipedePatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.ClayPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.ThumberPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.GhostPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.BrakenPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.SnakePatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.GiantPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.JesterPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.MaskPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.NutPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.PufferPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.MechPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.SpiderPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.WormPatch));
            harmony.PatchAll(typeof(EnemySpeedConfig.Patches.CoilPatch));
        }

        private void loadConfig()
        {
            baboonSpeedConfig = Config.Bind<float>("Baboon", "Baboon Speed", 1.0f, "");
            blobSpeedConfig = Config.Bind<float>("Blob", "Blob Speed", 1.0f, "");
            beeSpeedConfig = Config.Bind<float>("Bee", "Bee Speed", 1.0f, "");

            brakenSpeedConfig = Config.Bind<float>("Braken", "Braken Speed", 1.0f, "");
            brakenEnterAngerConfig = Config.Bind<float>("Braken", "Enter Anger Mode", 1.0f, "");

            butlerBeeDoAIIntervalConfig = Config.Bind<float>("Butler", "Butler Bees Do AI Interval", 1.0f, "");
            butlerSpeedConfig = Config.Bind<float>("Butler", "Butler Speed", 1.0f, "");

            centipedeSpeedConfig = Config.Bind<float>("Centipede", "Centipede Speed", 1.0f, "");
            claySurgeonSpeedConfig = Config.Bind<float>("Clay Surgeon", "Clay Surgeon Speed", 1.0f, "");

            coilheadDoAIIntervalConfig = Config.Bind<float>("Coilhead", "Coilhead Do AI Interval", 1.0f, "");
            coilheadSpeedConfig = Config.Bind<float>("Coilhead", "Coilhead Speed", 1.0f, "");

            ghostGirlSpeedConfig = Config.Bind<float>("Ghost Girl", "Ghost Girl Speed", 1.0f, "");
            ghostGirlBeginChasingConfig = Config.Bind<float>("Ghost Girl", "Ghost Girl Begin Chasing", 1.0f, "");

            giantSpeedConfig = Config.Bind<float>("Giant", "Giant Speed", 1.0f, "");

            jesterSpeedConfig = Config.Bind<float>("Jester", "Jester Speed", 1.0f, "");
            jesterDoAIIntervalConfig = Config.Bind<float>("Jester", "Jester Do AI Interval Speed", 1.0f, "");
            jesterPopUpConfig = Config.Bind<float>("Jester", "Pop Up Speed", 1.0f, "");
            jesterBeginCrankConfig = Config.Bind<float>("Jester", "Begin Crank Speed", 1.0f, "");

            lootBugSpeedConfig = Config.Bind<float>("Loot Bug", "Loot Bug Speed", 1.0f, "");
            MaskedSpeedConfig = Config.Bind<float>("Masked", "Masked Speed", 1.0f, "");
            oldBirdSpeedConfig = Config.Bind<float>("Old Bird", "Old Bird Speed", 1.0f, "");
            blindDogSpeedConfig = Config.Bind<float>("Blind Dog", "Blind Dog Speed", 1.0f, "");

            caveDwellerBabyGrowthConfig = Config.Bind<float>("Cave Dweller", "Cave Dweller Baby Growth Speed", 1.0f, "");
            caveDwellerDoBabyAIIntervalConfig = Config.Bind<float>("Cave Dweller", "Cave Dweller Do Baby AI Interval", 1.0f, "");
            caveDwellerSpeedConfig = Config.Bind<float>("Cave Dweller", "Cave Dweller Speed", 1.0f, "");
            caveDwellerbecomeAdultAnimationSpeedConfig = Config.Bind<float>("Cave Dweller", "Cave Dweller Become Adult Animation Speed", 1.0f, "");
            caveDwellerNonBabySpeedConfig = Config.Bind<float>("Cave Dweller", "Cave Dweller Non Baby Speed", 1.0f, "");

            nutCrackerTurnSpeedConfig = Config.Bind<float>("Nut Cracker", "Nut Cracker Turn Speed", 1.0f, "");
            nutCrackerSpeedConfig = Config.Bind<float>("Nut Cracker", "Nut Cracker Speed", 1.0f, "");

            sporeLizardSpeedConfig = Config.Bind<float>("Spore Lizard", "Spore Lizard Speed", 1.0f, "");

            tulipSnakeLeapSpeedConfig = Config.Bind<float>("Tulip Snake", "Tulip Snake Leap Speed", 1.0f, "");
            tulipSnakeDoAIIntervalConfig = Config.Bind<float>("Tulip Snake", "Tulip Snake Do AI Interval", 1.0f, "");

            spiderSpeedConfig = Config.Bind<float>("Spider", "Spider Speed", 1.0f, "");

            thumperSpeedConfig = Config.Bind<float>("Thumper", "Thumper Speed", 1.0f, "");
            thumperSpeedAccelerationEffectConfig = Config.Bind<float>("Thumper", "Thumper Speed Acceleration Effect", 1.0f, "");
            thumperSpeedIncreaseRateConfig = Config.Bind<float>("Thumper", "Thumper Speed Increase Rate", 1.0f, "");

            sandWormSpeedConfig = Config.Bind<float>("Sand Worm", "Sand Worm Speed", 1.0f, "");
        }
    }
    namespace EnemySpeedConfig.Patches
    {
        [HarmonyPatch(typeof(BaboonBirdAI))]
        internal class BaboonPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void baboonPatch(ref BaboonBirdAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.baboonSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(BlobAI))]
        internal class BlobPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void blobPatch(ref BlobAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.blobSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(RedLocustBees))]
        internal class BeePatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void beePatch(ref RedLocustBees __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.beeSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(FlowermanAI))]
        internal class BrakenPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void brakPatch2(ref FlowermanAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.brakenSpeedConfig.Value;
            }

            [HarmonyPatch("EnterAngerModeClientRpc")]
            [HarmonyPostfix]
            private static void brakPatch(ref FlowermanAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.brakenEnterAngerConfig.Value;
            }
        }
        [HarmonyPatch(typeof(ButlerBeesEnemyAI))]
        internal class ButlerBeePatch
        {
            [HarmonyPatch("DoAIInterval")]
            [HarmonyPostfix]
            private static void bulterPatch(ref ButlerBeesEnemyAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.butlerBeeDoAIIntervalConfig.Value;
            }
        }
        [HarmonyPatch(typeof(ButlerEnemyAI))]
        internal class ButlerPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void bulterPatch(ref ButlerEnemyAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.butlerSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(CentipedeAI))]
        internal class CentipedePatch
        {
            [HarmonyPatch("IncreaseSpeedSlowly")]
            [HarmonyPostfix]
            private static void CentiPatch(ref CentipedeAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.centipedeSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(ClaySurgeonAI))]
        internal class ClayPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void CentiPatch(ref ClaySurgeonAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.claySurgeonSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(SpringManAI))]
        internal class CoilPatch
        {
            [HarmonyPatch("DoAIInterval")]
            [HarmonyPostfix]
            private static void coilPatch(ref SpringManAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.coilheadDoAIIntervalConfig.Value;
            }

            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void coilPatch2(ref SpringManAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.coilheadSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(DressGirlAI))]
        internal class GhostPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void ghostPatch(ref DressGirlAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.ghostGirlSpeedConfig.Value;
            }

            [HarmonyPatch("BeginChasing")]
            [HarmonyPostfix]
            private static void ghostPatch2(ref DressGirlAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.ghostGirlBeginChasingConfig.Value;
            }
        }
        [HarmonyPatch(typeof(ForestGiantAI))]
        internal class GiantPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void giantPatch(ref ForestGiantAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.giantSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(JesterAI))]
        internal class JesterPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void jesterPatch2(ref JesterAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.jesterSpeedConfig.Value;
                __instance.maxAnimSpeed *= SpeedBase.Instance.jesterSpeedConfig.Value;
            }

            [HarmonyPatch("DoAIInterval")]
            [HarmonyPostfix]
            private static void jesterPatch(ref JesterAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.jesterDoAIIntervalConfig.Value;
            }

            [HarmonyPatch("SetJesterInitialValues")]
            [HarmonyPostfix]
            private static void jesterPtach3(ref JesterAI __instance)
            {
                __instance.popUpTimer /= SpeedBase.Instance.jesterPopUpConfig.Value;
                __instance.beginCrankingTimer /= SpeedBase.Instance.jesterBeginCrankConfig.Value;
            }
        }
        [HarmonyPatch(typeof(HoarderBugAI))]
        internal class LootBugPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void lootBugPatch(ref HoarderBugAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.lootBugSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(MaskedPlayerEnemy))]
        internal class MaskPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void maskPatch(ref MaskedPlayerEnemy __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.MaskedSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(RadMechAI))]
        internal class MechPatch
        {
            [HarmonyPatch("DoFootstepCycle")]
            [HarmonyPostfix]
            private static void mechPatch(ref RadMechAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.oldBirdSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(MouthDogAI))]
        internal class MouthDogPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void mouthDogPatch(ref MouthDogAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.blindDogSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(CaveDwellerAI))]
        internal class BabyPatch
        {
            [HarmonyPatch("IncreaseBabyGrowthMeter")]
            [HarmonyPostfix]
            private static void babyPatch(ref CaveDwellerAI __instance)
            {
                __instance.growthMeter *= SpeedBase.Instance.caveDwellerBabyGrowthConfig.Value;
            }

            [HarmonyPatch("DoBabyAIInterval")]
            [HarmonyPostfix]
            private static void babyPatch2(ref CaveDwellerAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.caveDwellerDoBabyAIIntervalConfig.Value;
            }

            [HarmonyPatch("BabyUpdate")]
            [HarmonyPostfix]
            private static void babyPatch3(ref CaveDwellerAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.caveDwellerSpeedConfig.Value;
            }

            [HarmonyPatch("becomeAdultAnimation")]
            [HarmonyPostfix]
            private static void babyPatch4(ref CaveDwellerAI __instance)
            {
                __instance.leapSpeed *= SpeedBase.Instance.caveDwellerbecomeAdultAnimationSpeedConfig.Value;
            }

            [HarmonyPatch("DoNonBabyUpdateLogic")]
            [HarmonyPostfix]
            private static void babyPatch5(ref CaveDwellerAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.caveDwellerNonBabySpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(NutcrackerEnemyAI))]
        internal class NutPatch
        {
            [HarmonyPatch("TurnTorsoToTargetDegrees")]
            [HarmonyPostfix]
            private static void nutPatch(ref NutcrackerEnemyAI __instance)
            {
                __instance.torsoTurnSpeed *= SpeedBase.Instance.nutCrackerTurnSpeedConfig.Value;
            }

            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void nutPatch2(ref NutcrackerEnemyAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.nutCrackerSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(PufferAI))]
        internal class PufferPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void pufPatch(ref PufferAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.sporeLizardSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(FlowerSnakeEnemy))]
        internal class SnakePatch
        {
            [HarmonyPatch("DoLeapAndDropPhysics")]
            [HarmonyPostfix]
            private static void snakePatch(ref FlowerSnakeEnemy __instance)
            {
                __instance.leapSpeedMultiplier *= SpeedBase.Instance.tulipSnakeLeapSpeedConfig.Value;
            }

            [HarmonyPatch("DoAIInterval")]
            [HarmonyPostfix]
            private static void snakePatch2(ref FlowerSnakeEnemy __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.tulipSnakeDoAIIntervalConfig.Value;
            }
        }
        [HarmonyPatch(typeof(SandSpiderAI))]
        internal class SpiderPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void spiPatch(ref SandSpiderAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.spiderSpeedConfig.Value;
                __instance.spiderSpeed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.spiderSpeedConfig.Value;
            }
        }
        [HarmonyPatch(typeof(CrawlerAI))]
        internal class ThumberPatch
        {
            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            private static void ThumbPatch(ref CrawlerAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.thumperSpeedConfig.Value;
            }

            [HarmonyPatch("CalculateAgentSpeed")]
            [HarmonyPostfix]
            private static void ThumbPatch2(ref CrawlerAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.thumperSpeedConfig.Value;
                __instance.SpeedAccelerationEffect *= SpeedBase.Instance.thumperSpeedAccelerationEffectConfig.Value;
                __instance.SpeedIncreaseRate *= SpeedBase.Instance.thumperSpeedIncreaseRateConfig.Value;
            }
        }
        [HarmonyPatch(typeof(SandWormAI))]
        internal class WormPatch
        {
            [HarmonyPatch("DoAIInterval")]
            [HarmonyPostfix]
            private static void wormPatch(ref SandWormAI __instance)
            {
                ((EnemyAI)__instance).agent.speed = ((EnemyAI)__instance).agent.speed * SpeedBase.Instance.sandWormSpeedConfig.Value;
            }
        }
    }
}