using System.Linq;
using Domain.Factories;
using Domain.Services;

namespace Domain.Infrastructure.Persistance
{
    public class ClaimRepository
        :Repositories.IClaimRepository
    {
        private readonly IWorkspace _workspace;
        private readonly ClaimFactory _claimFactory;

        public ClaimRepository(IWorkspace workspace, ClaimFactory claimFactory)
        {
            _workspace = workspace;
            _claimFactory = claimFactory;
        }

        public Claim GetById(ClaimId id)
        {
            var memento = _workspace.GetById<ClaimMemento>(id.Value);
            var claim = _claimFactory.FromMemento(memento);

            if (claim == null)
            {
                claim = new Claim(id);
                _workspace.Attach(claim.GetMemento());
            }
            return claim;
        }

        public void AddOrUpdate(Claim claim)
        {
            var memento = _workspace.GetById<ClaimMemento>(claim.Id.Value);
            
            if (memento != null)
            {
                claim.GetMemento(memento);
            }
            else
            {
                _workspace.Attach(claim.GetMemento());
            }
            
        }

        public IQueryable<ClaimMemento> GetAll()
        {
            return _workspace.GetAll<ClaimMemento>();
        }
    }
}
