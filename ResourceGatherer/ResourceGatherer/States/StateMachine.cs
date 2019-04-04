using ResourceGatherer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.States {
    public class StateMachine {
        private readonly BaseEntity owner;
        private IState state;

        public StateMachine(BaseEntity owner) => this.owner = owner;

        public StateMachine(BaseEntity owner, IState state) {
            this.owner = owner;
            this.state = state;
        }

        public void ChangeState(IState newState) {
            state.Exit(owner);
            state = newState;
            state.Enter(owner);
        }

        public void SetState(IState newState) {
            state = newState;
            state.Enter(owner);
        }

        public void Update() => state.Execute(owner);
    }
}
