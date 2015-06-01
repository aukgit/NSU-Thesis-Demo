using System;
using System.Web.Mvc;
using SampleEnterprise.Models.Context;
using SampleEnterprise.Modules.Extensions.Context;
using SampleEnterprise.Modules.UserError;

namespace SampleEnterprise.Controllers {

    public abstract class GenericController<TContext> : Controller where TContext : DevDbContext, new() {
        internal ErrorCollector ErrorCollector;
        internal readonly TContext db;

        protected GenericController() {
        }

        protected GenericController(bool applicationDbContextRequried) {
            if (applicationDbContextRequried) {
                db = new TContext();
            }
        }

        protected GenericController(bool applicationDbContextRequried, bool errorCollectorRequried) {
            if (errorCollectorRequried) {
                ErrorCollector = new ErrorCollector();
            }
            if (applicationDbContextRequried) {
                db = new TContext();
            }
        }

        protected override void Dispose(bool disposing) {
            if (db != null) {
                db.Dispose();
            }
            if (ErrorCollector != null) {
                ErrorCollector.Dispose();
            }
            base.Dispose(disposing);
            GC.Collect();
        }
    }
}