using System.Collections.Generic;
using Core;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PageModels.Common
{

    public abstract class BaseModel : PageModel, IBaseModel
    {
        [BindProperty] public IBaseEntity item { get; set; }
        public virtual string SortOrder { get; set; }
        public abstract string CurrentSort { get; }
        public virtual string CurrentFilter { get; set; }
        public virtual string SearchString { get; set; }
        public virtual bool HasPreviousPage { get; protected set; }
        public virtual bool HasNextPage { get; protected set; }
        public virtual int? PageIndex { get; set; }
        public abstract string PageTitle { get; }
        public virtual string PageUrl => PageTitle;

        public string ErrorMessage { get; protected set; }
    }

    public abstract class BaseModel<TEntity, TView> : BaseModel
        where TEntity : class, IBaseEntity, new()
        where TView : class, IBaseEntity, new()
        {
            protected readonly IRepo<TEntity> repo;
            protected readonly ApplicationDbContext _context;

            protected BaseModel(IRepo<TEntity> r, ApplicationDbContext context)
            {
                repo = r;
                _context = context;
            }

            [BindProperty]
            public new TView item
            {
                get => (TView)base.item;
                set => base.item = value;
            }

            public IList<TView> items { get; set; }
            protected internal abstract TView ToView(TEntity obj);
            protected internal abstract TEntity ToEntity(TView view);
        }
    }
