using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Karoushi.AI
{
    /// <summary>
    /// Basic class of an AI State 
    /// </summary>
    public class State
    {
        public class STATE
        {
            public const int IDLE = 0;
        };

        public enum EVENT
        {
            ENTER, UPDATE, EXIT
        };

        public STATE name;
        protected EVENT stage;
        protected NPC npc;
        protected Animator anim;
        protected State nextState;
        protected NavMeshAgent agent;

        public State(NPC _npc, NavMeshAgent _agent, Animator _anim)
        {
            npc = _npc;
            agent = _agent;
            anim = _anim;
            stage = EVENT.ENTER;
        }

        public virtual void Enter() { stage = EVENT.UPDATE; }
        public virtual void Update() { stage = EVENT.UPDATE; }
        public virtual void Exit() { stage = EVENT.EXIT; }

        public State Process()
        {
            if (stage == EVENT.ENTER) Enter();
            if (stage == EVENT.UPDATE) Update();
            if (stage == EVENT.EXIT)
            {
                Exit();
                return nextState;
            }
            return this;
        }
    }
}