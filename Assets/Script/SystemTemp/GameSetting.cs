using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TW.GameSetting
{
    class GameSettingData
    {
        public static readonly int EffectDestroySecond = 10;
        public static readonly BuildType buildType = BuildType.Debug;

        /// <summary> これ以上タップコントローラーが動いたら走らせる </summary>
        public static readonly int runCheackAmount = 70;

        /// <summary> 回転　謎 </summary>
        public static readonly int wantedrotatespeed = 3;

        /// <summary> バトル初期化の手札数 </summary>
        public static readonly int battleHandsAmount = 5;

        /// <summary> バトル初期化の手札数 </summary>
        public static readonly int battleHandsMaxAmount = 5;

        /// <summary> 手札を補充する時間 </summary>
        public static readonly int battleHandReplenishmentTime = 3;

        public static readonly float DIALOG_EFFECT_TIME = 0.2f;

    }

    class KeyConfigSetting
    {
        public static readonly string Horizontal = "Horizontal";
        public static readonly string Vertical = "Vertical";
        public static readonly string LStickHorizontal = "Axis 1";
        public static readonly string LStickVertical = "Axis 2";
        public static readonly string RStickHorizontal = "Axis 3";
        public static readonly string RStickVertical = "Axis 4";
        public static readonly string CrossHorizontal = "Axis 11";
        public static readonly string CrossVertical = "Axis 12";
        public static readonly string OptionSetting = "Button 9";
        public static readonly string Shikaku = "DS4□";
        public static readonly string Maru = "DS4◯";
        public static readonly string Sankaku = "DS4△";
        public static readonly string L3 = "L3";
        public static readonly string Batsu = "DS4x";
    }


    public enum SceneType
    {
        None = 0,
        Battle = 1,
        Home = 2,
        Title = 3,
        InGame = 4,
        CharaDebug = 5
    }

    public enum BuildType
    {
        None = 0,
        Debug = 1,
        Release = 2
    }

    public enum PlayType
    {
        None = 0,
        Moving = 1,
        Menu = 2,
        Battle = 3,
    }

    public enum ColEventType
    {
        None = 0,
        Player = 1,
        Reseption = 2,
        ShopKeeper = 3,
        MixItem = 4,
        Equipment = 5,
        PlayerWeapon = 6,
        Enemy = 7,
        EnemyNavMesh = 8,
        EnemyWeapon = 9,
        EnemyActionCheack = 10,
        CardSetting = 11,
        Loading = 12,
        BattleSetting = 13,
        Card = 14,
        PossessionCard = 15,
        SettingCard = 16,
        AlphaLoading = 17,
        TextInput = 18,
        Home = 19,
        House = 20,
        BattleUseCardSpace = 21,
        PlayerNavMesh = 22,
        Castel,
    }

    public enum ColEventCase
    {
        None = 0,
        PlayerAttack = 1,
        OpenMenu = 2,
        FoundPlayer = 3,
        EnemyAttackStart = 4,
        EnemyAttack = 5,
        PossessionCard = 6,
        SettingCard = 7,
        EnableMove = 8,
        BattleUseCard = 9,
        FoundEnemy = 10,
    }

    class EventTypeSetting
    {
        public static bool IsPlayerCategory(ColEventType eventType)
        {
            bool returnValue = false;

            returnValue = playerCategory.Contains(eventType);
            returnValue = enemyCategory.Contains(eventType);

            return returnValue;
        }

        public static readonly List<ColEventType> playerCategory = new List<ColEventType>
        {
            ColEventType.Player, ColEventType.PlayerWeapon,ColEventType.Castel
        };

        public static readonly List<ColEventType> enemyCategory = new List<ColEventType>
        {
            ColEventType.Enemy, ColEventType.EnemyWeapon
        };

        public static readonly List<ColEventType> menuCategory = new List<ColEventType>
        {
            ColEventType.Reseption, ColEventType.ShopKeeper,
            ColEventType.MixItem, ColEventType.Equipment,ColEventType.CardSetting
        };

        public static readonly List<ColEventType> sceneCategory = new List<ColEventType>
        {
            ColEventType.Home,ColEventType.House
        };

        public static ColEventCase GetColEventCase(ColEventType a, ColEventType b)
        {
            if (a == ColEventType.Card && b == ColEventType.BattleUseCardSpace)
                return ColEventCase.BattleUseCard;

            if (a == ColEventType.PlayerWeapon && enemyCategory.Contains(b))
                return ColEventCase.PlayerAttack;

            if (a == ColEventType.EnemyWeapon && playerCategory.Contains(b))
                return ColEventCase.EnemyAttack;

            if (a == ColEventType.EnemyActionCheack && playerCategory.Contains(b))
                return ColEventCase.EnemyAttackStart;

            if (playerCategory.Contains(a) && menuCategory.Contains(b))
                return ColEventCase.OpenMenu;

            if (a == ColEventType.EnemyNavMesh && b == ColEventType.Player)
                return ColEventCase.FoundPlayer;

            if (a == ColEventType.PlayerNavMesh && b == ColEventType.Enemy)
                return ColEventCase.FoundEnemy;

            if (a == ColEventType.Card && b == ColEventType.PossessionCard)
                return ColEventCase.PossessionCard;

            if (a == ColEventType.Card && b == ColEventType.SettingCard)
                return ColEventCase.SettingCard;

            if (playerCategory.Contains(a) && sceneCategory.Contains(b))
                return ColEventCase.EnableMove;



            return ColEventCase.None;
        }
    }

    public enum QuestType
    {
        None = 0,
        Story = 1,
        Event = 2,
        Multi = 3,
    }

    public enum ItemType
    {
        None = 0,
        ConsumeItem = 1,
        EquipItem = 2,
        MaterialItem = 3
    }

    public enum ActionType
    {
        None = 0,
        Attack = 1,
        Recovery = 2,
        Buff = 3,
        DeBuff = 4,
        AttackRecovery = 5,
        Summon = 6,
    }

    public enum StatusEfectType
    {
        None = 0,
        AttackStatus = 1,
        GuardStatus = 2,
        HpRecoveryStatus = 3,
        DeckDrawSpeedStatus = 4,
        DeckChargeSpeedStatus = 5,
        SpeedStatus = 6,
        AttackRecoveryStatus = 7,
        Poison = 8,
        Paralysis = 9,
        Sleep = 10,
        HpStatus = 11,
        FireAttackStatus = 12,
        ThunderAttackStatus = 13,
        WaterAttackStatus = 14,
        SatisfyingProbabilityStatus = 15,
        SatisfyingAttackStatus = 16,


    }

    public enum CharaAttribute
    {
        None = 0,
        Player = 1,
        Enemy = 2,
        Summon = 3,

    }

    public enum CharaType
    {
        None = 0,
        elfmage = 1,
        hammer = 2,
        RabbitWarrior = 3,
    }

    public enum AnimationType
    {
        none,
        run,
        walk,
        idle,
        attack,
        damaged
    }

    public enum CharastateType
    {
        None = 0,
        Wait = 1,
        Attacking = 2,
        AttackEnd = 3,
        Run = 4,
        Walk = 5
    }

    class AnimationSetting
    {
        public static readonly List<AnimationType> attackCategory = new List<AnimationType>
        {
            AnimationType.attack
        };

        public static void AnimationInit(Animator anima)
        {
            if(anima==null) Debug.LogError("Animator がnullだ馬鹿");

            foreach (var Value in anima.parameters)
            {
                if(Value.type == AnimatorControllerParameterType.Bool)
                {
                    anima.SetBool(Value.name, false);
                }
            }

        }
    }

    public enum APIType
    {
        None = 0,
        master = 1,
        user_info = 2,
        gacha = 3,
        user_card = 4,
        request_check = 5

    }

    public enum APIDetail
    {
        None = 0,
        create = 1,
        index = 2,
        update_name = 3,
        exec = 4,
        card_data = 5,
        chara_data = 6,
        deck_index = 7,
        deck_create = 8,
        deck_edit = 9,
        quest = 10,
        quest_detail = 11,
        action,
    }

    public enum SaveType
    {
        None = 0,
        user_id = 1,
        user_name = 2,
        user_duid = 3,
        last_login_time = 4,
    }

    public enum CardDrawType
    {
        None = 0,
        CardSetting = 1,
        Battle = 2

    }

    public enum CardState
    {
        None = 0,
        Moving = 1,
        Wait,
        Discard,
    }

    public enum DeckState
    {
        None = 0,
        Create = 1,
        Edit = 2,
        Select = 3
    }

    public enum EffectType
    {
        None = 0,
        Effect1 = 1,
        Effect2 = 2,
        Effect3 = 3,
        Effect4 = 4,
        Effect5 = 5,
        Effect6 = 6,
        Effect7 = 7,
        Effect8 = 8,
        Effect9 = 9,
        Effect10 = 10,
        Effect11 = 11,
        Effect12 = 12,
        Effect13 = 13,
        Effect14 = 14,
        Effect15 = 15,
        Effect16 = 16,
        Effect17 = 17,
        Effect18 = 18,
        Effect19 = 19,
        Effect20 = 20,
        Effect21 = 21,
        Effect22 = 22,
        Effect23 = 23,
        Effect24 = 24,
        Effect25 = 25,
        Effect26 = 26,
        Effect27 = 27
    }

    public enum RangeType
    {
        None = 0,
        Self = 1,
        Stay = 2,
        TeamAll = 3,
        Enemy = 4,
        EnemyAll = 5,
        TeamRandom = 6,
        EnemyRandom = 7
    }
}

