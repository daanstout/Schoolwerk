using ResourceGatherer.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceGatherer.States {
    public interface IState {
        void Enter(BaseEntity entity);
        void Execute(BaseEntity entity);
        void Exit(BaseEntity entity);
    }
}
