using Aids;
using Data;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using PageModels.Common;

namespace PageModels
{
    public class OccupationModel: ViewModel<Occupation, OccupationView>
    {
        public OccupationModel(IOccupationRepo r, ApplicationDbContext context) : base(r, context) { }
        public override string PageTitle => "Occupation";
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
