using MelonLoader;
using Il2CppAssets.Scripts.Models.Towers;
using MadScientist;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using ScientistBuff;
using Il2Cpp;
using Il2CppAssets.Scripts.Unity.Display;
using weapondisplays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using MadScientist.Catersoncat;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using MadScientist.Catersoncat.Dogson;
using MadScientist.Catersoncat.Dogson.Lianer;
using MadScientist.Catersoncat.Dogson.Lianer.Simba;
using MadScientist.Catersoncat.Dogson.Lianer.Simba.Alex;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

[assembly: MelonInfo(typeof(MadScientist.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]






namespace weapondisplays
{
    public class BananaDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "ScientistBuffIcon");
        }
    }
}

namespace MadScientist
{
    internal class Main : BloonsMod
    {
        public class MadScientist : ModTower
        {
            public override string Name => nameof(MadScientist);


            public override string DisplayName => "The Mad Scientist";

            public override string Description => "The Mad Scientist brews potions and uses the power of Science for great destruction inventions Thanks to King Solomon for the Idea";

            public override string BaseTower => "Alchemist";

            public override int Cost => 0;

            public override int TopPathUpgrades => 5;

            public override int MiddlePathUpgrades => 5;

            public override int BottomPathUpgrades => 5;

            public override ParagonMode ParagonMode => ParagonMode.Base555;
            public override TowerSet TowerSet => TowerSet.Magic;



            public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("UltimateCrosspathing") ? true : base.IsValidCrosspath(tiers);


            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {


            }

            public override string Icon => "Base-Icon";



        }

        public class Upgrade100 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Kinematics";

            public override string Description => "creating formulas for better aim to not miss even the fastest bloons";

            public override int Cost => 180;

            public override int Path => 0;

            public override int Tier => 1;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.GetWeapon().projectile.AddBehavior(new TrackTargetModel("Track", 99999, false, false, 9999, true, 99999, true, false));

            }

            public override string Icon => "Kinematics-Icon";

            public override string Portrait => "Kinematics-Potrait";
        }

        public class Upgrade200 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Elastic Collision";

            public override string Description => "gains the ability to push bloons back on hit";

            public override int Cost => 440;

            public override int Path => 0;

            public override int Tier => 2;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<WindModel>().chance = 0.1f;

            }

            public override string Icon => "ElasticCollision-Icon";

            public override string Portrait => "ElasticCollision-Portrait";
        }

        public class Upgrade300 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Circular Motion";

            public override string Description => " creating Centrifugal force to allow circular with slow potion leaks ";

            public override int Cost => 780;

            public override int Path => 0;

            public override int Tier => 3;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                var projectile = attackModel.weapons[0].projectile;

                projectile.AddBehavior(new AddBonusDamagePerHitToBloonModel("a", "b", 10f, 10, 15, true, false, false));
            }

            public override string Icon => "CircularMotion-Icon";

            public override string Portrait => "CircularMotion-Portrait";
        }

        public class Upgrade400 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Electric Field";

            public override string Description => "makes bloons slower with the power of electic fields";

            public override int Cost => 9730;

            public override int Path => 0;

            public override int Tier => 4;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var weaponModel in towerModel.GetWeapons())
                {








                }
                var attackModel = towerModel.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                if (towerModel.tier < 4)
                {
                    attackModel.weapons[0].projectile.collisionPasses = new int[] { -1, 0, 1 };
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-003").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehavior<SlowModifierForTagModel>().Duplicate());
                    foreach (var beh in Game.instance.model.GetTowerFromId("GlueGunner-100").GetAttackModel().weapons[0].projectile.GetBehaviors<AddBehaviorToBloonModel>())
                    {
                        attackModel.weapons[0].projectile.AddBehavior(beh.Duplicate());
                    }
                }
            }

            public override string Icon => "ElectricField-Icon";

            public override string Portrait => "Electric-Portrait";
        }

        public class Upgrade500 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Theory of Relativity";

            public override string Description => "has powers to control time and mass allowing for a big attack speed and damage boosts";

            public override int Cost => 96690;

            public override int Path => 0;

            public override int Tier => 5;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetBehavior<AttackModel>();

                towerModel.display = new PrefabReference() { guidRef = "a2c4aa09f87dbc545978adb34e445dcc" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "a2c4aa09f87dbc545978adb34e445dcc" };
                attackModel.weapons[0].Rate = 0.5f;

            }

            public override string Icon => "TheoryOfRelativity-Icon";

            public override string Portrait => "Theory-Portrait";
        }

        public class Upgrade010 : ModUpgrade<MadScientist>
        {
            public override string DisplayName => "Materials Science ";

            public override string Description => "creating new compounds for more pierce";

            public override int Cost => 300;

            public override int Path => 1;

            public override int Tier => 1;

            public override void ApplyUpgrade(TowerModel towerModel)
            {

                towerModel.GetWeapon().projectile.pierce += 20;
            }

            public override string Icon => "MaterialsScience-Icon";

            public override string Portrait => "Material-Portrait";
        }

        public class Upgrade020 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Thermodynamics";

            public override string Description => "making his potions gain heat burning bloons over time and gives lead popping power more damage";

            public override int Cost => 1500;

            public override int Path => 1;

            public override int Tier => 2;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                var Proj = attackModel.weapons[0].projectile;


                Proj.AddBehavior(new DamageModel("DamageModel_", 20, 20, true, true, true, BloonProperties.None, BloonProperties.None));
            }

            public override string Icon => "Thermodynamics-Icon";

            public override string Portrait => "";
        }

        public class Upgrade030 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Oxidation";

            public override string Description => "oxidizing bloons in its range to make them weaker";

            public override int Cost => 1560;

            public override int Path => 1;

            public override int Tier => 3;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();

                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("IceMonkey-320").GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().layers = 999;
                attackModel.weapons[0].projectile.GetBehavior<FreezeModel>().speed = 0.2f;

            }

            public override string Icon => "Oxidation-Icon";

            public override string Portrait => "";
        }

        public class Upgrade040 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Mind Altering Substances ";

            public override string Description => "creating pills to make all towers in its range gain more attack speed and can attack every bloon";

            public override int Cost => 5120;

            public override int Path => 1;

            public override int Tier => 4;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var rateSupportModel = new RateSupportModel("RateSupportModel_Genetic", .50f, true, Id, false, 0,
                    new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
                rateSupportModel.ApplyBuffIcon<ScientistBuffIcon>();
                towerModel.AddBehavior(rateSupportModel);
                var support = new DamageTypeSupportModel("DamageTypeSupportModel_TempleBase", true, Id, BloonProperties.None,
       new Il2CppReferenceArray<TowerFilterModel>(0), "", "");
                support.ApplyBuffIcon<ScientistBuffIcon>();
                towerModel.AddBehavior(support);
            }

            public override string Icon => "MindAlteringSubstances-Icon";

            public override string Portrait => "";
        }

        public class Upgrade050 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Radioactive Decay";

            public override string Description => "with radioactive powers his fire rate is so powerfull it dissolves bloons in its range";

            public override int Cost => 18830;

            public override int Path => 1;

            public override int Tier => 5;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

                attackModel.weapons[0].Rate *= 0.2f;

            }

            public override string Icon => "RadioactiveDecay-Icon";

            public override string Portrait => "ElectricField-Portrait";
        }

        public class Upgrade001 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Better Metabolism";

            public override string Description => "optimizing its metabolism to gain more attack speed and damage";

            public override int Cost => 530;

            public override int Path => 2;

            public override int Tier => 1;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

                attackModel.weapons[0].Rate *= 0.9f;
            }

            public override string Icon => "BetterMetabolism-Icon";

            public override string Portrait => "Metabolism-Portrait";
        }

        public class Upgrade002 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Basic Animal Training ";

            public override string Description => " gains the power of animals cat = pierce and dog = damage";

            public override int Cost => 1050;

            public override int Path => 2;

            public override int Tier => 2;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModelC = towerModel.GetAttackModel();
                var farmC = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
                farmC.range = towerModel.range;
                farmC.name = "Farm_Weapon";
                farmC.weapons[0].Rate = 15f;
                farmC.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                farmC.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
                farmC.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<Caterson>().Duplicate(), 0f, true, false, false, true, true));
                towerModel.AddBehavior(farmC);
                var projectileC = attackModelC.weapons[0].projectile;
                var attackModelD = towerModel.GetAttackModel();
                var farmD = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
                farmD.range = towerModel.range;
                farmD.name = "Farm_Weapon";
                farmD.weapons[0].Rate = 15f;
                farmD.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                farmD.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
                farmD.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<Dogson>().Duplicate(), 0f, true, false, false, true, true));
                towerModel.AddBehavior(farmD);
                var projectileD = attackModelD.weapons[0].projectile;
            }

            public override string Icon => "BasicAnimalTraining-Icon";

            public override string Portrait => "";
        }

        public class Upgrade003 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Genetic Enhancement ";

            public override string Description => "accessing the DNA now gains super range and Camo detection";

            public override int Cost => 1260;

            public override int Path => 2;

            public override int Tier => 3;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.range += 30;
                towerModel.GetAttackModel().range += 30;
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);

            }

            public override string Icon => "GeneticEnhancement-Icon";

            public override string Portrait => "Genetic-Portrait";
        }

        public class Upgrade004 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Viral Diseases ";

            public override string Description => "adding dangerous viruses to its potions to make bloons ill (slowing them)";

            public override int Cost => 8020;

            public override int Path => 2;

            public override int Tier => 4;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var Weapon = towerModel.GetWeapon();
                var bloonImpact = Game.instance.model.GetTower(TowerType.BombShooter, 4);
                var slowModifierForTagModel = bloonImpact.GetDescendant<SlowModifierForTagModel>().Duplicate();
                var slowModel = bloonImpact.GetDescendant<SlowModel>().Duplicate();
                Weapon.projectile.AddBehavior(slowModifierForTagModel);
                Weapon.projectile.AddBehavior(slowModel);


            }

            public override string Icon => "ViralDiseases-Icon";

            public override string Portrait => "Viral-Portrait";
        }

        public class Upgrade005 : ModUpgrade<MadScientist>
        {

            public override string DisplayName => "Advanced Animal Training ";

            public override string Description => "training the untrainable types - lion (damage), cheetah (attack speed & pierce), eagle (pursuit)\r\n";

            public override int Cost => 122500;

            public override int Path => 2;

            public override int Tier => 5;

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModelL = towerModel.GetAttackModel();
                var farmL = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
                farmL.range = towerModel.range;
                farmL.name = "Farm_Weapon";
                farmL.weapons[0].Rate = 15f;
                farmL.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                farmL.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
                farmL.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<Lianer>().Duplicate(), 0f, true, false, false, true, true));
                towerModel.AddBehavior(farmL);
                var attackModelS = towerModel.GetAttackModel();
                var farmS = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
                farmS.range = towerModel.range;
                farmS.name = "Farm_Weapon";
                farmS.weapons[0].Rate = 15f;
                farmS.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                farmS.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
                farmS.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<Simba>().Duplicate(), 0f, true, false, false, true, true));
                towerModel.AddBehavior(farmS);
                var attackModelA = towerModel.GetAttackModel();
                var farmA = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
                farmA.range = towerModel.range;
                farmA.name = "Farm_Weapon";
                farmA.weapons[0].Rate = 15f;
                farmA.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
                farmA.weapons[0].projectile.ApplyDisplay<BananaDisplay>();
                farmA.weapons[0].projectile.AddBehavior(new CreateTowerModel("BananaFarm000place", GetTowerModel<Alex>().Duplicate(), 0f, true, false, false, true, true));
                towerModel.AddBehavior(farmA);
            }

            public override string Icon => "AdvancedAnimalTraining-Icon";

            public override string Portrait => "";
        }

        public class ParagonDisplay : ModTowerDisplay<MadScientist>
        {
            public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

            public override bool UseForTower(int[] tiers) => IsParagon(tiers);

            public class UpgradeParagon : ModParagonUpgrade<MadScientist>
            {
                public override int Cost => 414620;

                public override string Description => "combining all the science to create an atomic blast than won't affect the monkeys";

                public override string DisplayName => "Nuclear Chain Reaction";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var attackModel = towerModel.GetAttackModel();
                    var projectile = attackModel.weapons[0].projectile;


                    towerModel.range += 9999;
                    attackModel.range += 9999;

                    projectile.RemoveBehavior<DamageModel>();
                    projectile.RemoveBehavior<SetSpriteFromPierceModel>();
                    projectile.AddBehavior(new DamageModel("DamageModel_", 999999, 999999, true, true, true, BloonProperties.None, BloonProperties.None));
                    projectile.AddBehavior(new WindModel("WindModel_", 0, 200, 999999, true, null, 0));
                    projectile.GetBehavior<ArriveAtTargetModel>().timeToTake = 0f;
                    projectile.pierce = 9999999;
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Fortified", 999999, 999999, false, false) { tags = new string[] { "Fortified" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 999999, 999999, false, false) { tags = new string[] { "Ceramic" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moab", 999999, 999999, false, false) { tags = new string[] { "Moab" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Bfb", 999999, 999999, false, false) { tags = new string[] { "Bfb" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Zomg", 999999, 999999, false, false) { tags = new string[] { "Zomg" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ddt", 999999, 999999, false, false) { tags = new string[] { "Ddt" }, collisionPass = 0 });
                    attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Bad", 999999, 999999, false, false) { tags = new string[] { "Bad" }, collisionPass = 0 });

                }

                public override string Icon => "NuclearChainReaction-Icon";

                public override string Portrait => "Nuclear-Portrait";
            }
        }
    }
    namespace Catersoncat
    {
        public class Caterson : ModTower
        {
            public override string Portrait => "ScientistBuffIcon";
            public override string Name => "Caterson";
            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => TowerType.BoomerangMonkey;

            public override bool DontAddToShop => true;
            public override int Cost => 0;

            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;


            public override string DisplayName => "Caterson";
            public override string Description => "Not Really a cat but-";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                var attackModel = towerModel.GetBehavior<AttackModel>();
                towerModel.isSubTower = true;
                towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));


            }
            public class CatersonDisplay : ModTowerDisplay<Caterson>
            {
                public override float Scale => .6f;
                public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 0, 0, 0);

                public override bool UseForTower(int[] tiers)
                {
                    return true;
                }
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {

                }
            }

        }

        namespace Dogson
        {
            public class Dogson : ModTower
            {
                public override string Portrait => "ScientistBuffIcon";
                public override string Name => "Dogson";
                public override TowerSet TowerSet => TowerSet.Support;
                public override string BaseTower => "GlueGunner-005";

                public override bool DontAddToShop => true;
                public override int Cost => 0;

                public override int TopPathUpgrades => 0;
                public override int MiddlePathUpgrades => 0;
                public override int BottomPathUpgrades => 0;


                public override string DisplayName => "Dogson";
                public override string Description => "a doggy???";

                public override void ModifyBaseTowerModel(TowerModel towerModel)
                {
                    var attackModel = towerModel.GetBehavior<AttackModel>();
                    towerModel.isSubTower = true;
                    towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));


                }
                public class DogsonDisplay : ModTowerDisplay<Dogson>
                {
                    public override float Scale => .6f;
                    public override string BaseDisplay => GetDisplay(TowerType.GlueGunner, 0, 0, 5);

                    public override bool UseForTower(int[] tiers)
                    {
                        return true;
                    }
                    public override void ModifyDisplayNode(UnityDisplayNode node)
                    {

                    }
                }

            }
            namespace Lianer
            {
                public class Lianer : ModTower
                {
                    public override string Portrait => "ScientistBuffIcon";
                    public override string Name => "Lianer";
                    public override TowerSet TowerSet => TowerSet.Support;
                    public override string BaseTower => "SuperMonkey-030";

                    public override bool DontAddToShop => true;
                    public override int Cost => 0;

                    public override int TopPathUpgrades => 0;
                    public override int MiddlePathUpgrades => 0;
                    public override int BottomPathUpgrades => 0;


                    public override string DisplayName => "Lianer";
                    public override string Description => "a a a a super monkey????";

                    public override void ModifyBaseTowerModel(TowerModel towerModel)
                    {
                        var attackModel = towerModel.GetBehavior<AttackModel>();
                        towerModel.isSubTower = true;
                        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));


                    }
                    public class LianerDisplay : ModTowerDisplay<Lianer>
                    {
                        public override float Scale => 2f;
                        public override string BaseDisplay => GetDisplay(TowerType.SuperMonkey, 0, 3, 0);

                        public override bool UseForTower(int[] tiers)
                        {
                            return true;
                        }
                        public override void ModifyDisplayNode(UnityDisplayNode node)
                        {

                        }
                    }

                }
                namespace Simba
                {
                    public class Simba : ModTower
                    {
                        public override string Portrait => "ScientistBuffIcon";
                        public override string Name => "Simba";
                        public override TowerSet TowerSet => TowerSet.Support;
                        public override string BaseTower => "WizardMonkey-005";

                        public override bool DontAddToShop => true;
                        public override int Cost => 0;

                        public override int TopPathUpgrades => 0;
                        public override int MiddlePathUpgrades => 0;
                        public override int BottomPathUpgrades => 0;


                        public override string DisplayName => "Simba";
                        public override string Description => "Named by my mother :))))!";

                        public override void ModifyBaseTowerModel(TowerModel towerModel)
                        {
                            var attackModel = towerModel.GetBehavior<AttackModel>();
                            towerModel.isSubTower = true;
                            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));


                        }
                        public class SimbaDisplay : ModTowerDisplay<Simba>
                        {
                            public override float Scale => 1f;
                            public override string BaseDisplay => GetDisplay(TowerType.WizardMonkey, 0, 0, 5);

                            public override bool UseForTower(int[] tiers)
                            {
                                return true;
                            }
                            public override void ModifyDisplayNode(UnityDisplayNode node)
                            {

                            }
                        }

                    }
                    namespace Alex
                    {
                        public class Alex : ModTower
                        {
                            public override string Portrait => "ScientistBuffIcon";
                            public override string Name => "Alex";
                            public override TowerSet TowerSet => TowerSet.Support;
                            public override string BaseTower => "DartlingGunner-050";

                            public override bool DontAddToShop => true;
                            public override int Cost => 0;

                            public override int TopPathUpgrades => 0;
                            public override int MiddlePathUpgrades => 0;
                            public override int BottomPathUpgrades => 0;


                            public override string DisplayName => "Alex";
                            public override string Description => "this wasn't wasnt named by my mother but by me :)";

                            public override void ModifyBaseTowerModel(TowerModel towerModel)
                            {
                                var attackModel = towerModel.GetBehavior<AttackModel>();
                                towerModel.isSubTower = true;
                                towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 45f, 3, false, false));
                                attackModel.weapons[0].Rate = 0.2f;


                            }
                            public class AlexDisplay : ModTowerDisplay<Alex>
                            {
                                public override float Scale => 1.2f;
                                public override string BaseDisplay => GetDisplay(TowerType.Druid, 5, 0, 0);

                                public override bool UseForTower(int[] tiers)
                                {
                                    return true;
                                }
                                public override void ModifyDisplayNode(UnityDisplayNode node)
                                {

                                }
                            }

                        }

                        [HarmonyLib.HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame), "Update")]
                        public class Update_Patch
                        {
                            [HarmonyLib.HarmonyPostfix]
                            public static void Postfix()
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
