using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Delaney.Controllers
{
    public abstract partial class Abstract : Controller
    {
        protected readonly Services.Data.Core.IUnitOfWork _unitOfWork;

        public Abstract(Services.Data.Core.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Domain
        {
            get
            {
                return Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            }
        }


        protected bool GetShowDeleted()
        {
            string s = Request.Cookies["ShowDeleted"];
            bool.TryParse(s, out bool b);
            return b;
        }

        private void ExpireAllCookies()
        {
            if (HttpContext != null)
            {
                foreach (var cookieKey in HttpContext.Request.Cookies.Keys)
                    HttpContext.Response.Cookies.Delete(cookieKey);
            }
        }
    }
}