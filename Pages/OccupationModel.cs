using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class OccupationModel: ViewedModel<Occupation, OccupationView>
    {
        //TODO: Concurrency pls
        public OccupationModel(IOccupationRepo r, ApplicationDbContext context) : base(r, context) { }

        protected internal override OccupationView ToView(Occupation obj)
        {
            OccupationView view = new OccupationView();
            Copy.Members(obj, view);
            return view;
        }

        protected internal override Occupation ToEntity(OccupationView view)
        {
            if (view is null) return null;
            var data = Copy.Members(view, new OccupationData());
            return new Occupation(data);
        }
    }
}
