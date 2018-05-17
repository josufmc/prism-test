using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismTest1.Infrastructure;

namespace ModuleA
{
    public class ContentAViewModel : IContentAViewModel
    {
        public ContentAViewModel(IContentAView view)
        {
            View = view;
            View.ViewModel = this;
        }

        public string Message { get; set; }
        public IView View { get; set; }
    }
}
